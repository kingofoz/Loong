# Loong 2.2

# Author: Yingjun Li <yjli@vmware.com>
# Copyright: Copyright (c) 2011-14 VMware, Inc. All Rights Reserved.
# License: MIT license

# http://ldtp.freedesktop.org

# Permission is hereby granted, free of charge, to any person obtaining a copy
# of this software and associated documentation files (the "Software"), to deal
# in the Software without restriction, including without limitation the rights to
# use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
# of the Software, and to permit persons to whom the Software is furnished to do
# so, subject to the following conditions:

# The above copyright notice and this permission notice shall be included in all
# copies or substantial portions of the Software.

# THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
# IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
# FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
# AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
# LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
# OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
# SOFTWARE.

import os
import atexit
import xmlrpclib
import threading
import subprocess

class LoongClient:
    def startDaemon(self):
        javahome = os.getenv('JAVA_HOME')
        javapath = '%s%sbin%s' % (javahome, os.sep, os.sep) if javahome else ''
        jycmd = ['%sjava' % javapath, 'org.python.util.jython',
                 '-Dpython.path=' + os.environ['LOONG_HOME'],
                 '-m', 'loongd']
        self._daemon = subprocess.Popen(jycmd, stdin = subprocess.PIPE, stdout = subprocess.PIPE, \
                                        stderr = subprocess.STDOUT, shell = False)
        self._event = threading.Event()
        log = threading.Thread(target = self.writeLog)
        log.daemon = True
        log.start()
        self._event.wait()
        if not self._loaded:
            raise RuntimeError('Loading failed, please refer to HOWTO.txt.')

    def stopDaemon(self):
        try:
            self._daemon.kill()
        except:
            pass

    def writeLog(self):
        self._debug = 0
        self._loaded = False
        while True:
            output = self._daemon.stdout.readline().rstrip()
            if not self._loaded:
                if output.startswith('Listening on port'):
                    self._loaded = True
                    self._event.set()
                elif output:
                    print(output)
                else:
                    self._event.set()
                    break
            elif self._debug:
                print(output)

    def debug(self, level):
        self._debug = level

def populateNamespace(d):
    for method in _loong.system.listMethods():
        if method.startswith('system.'):
            continue
        if method in d:
            local_name = '_remote_' + method
        else:
            local_name = method
        d[local_name] = getattr(_loong, method)
        d[local_name].__doc__ = 'Loong APIs'
        # methodHelp() is slow, need further investigation. Just comment it for now
        #d[local_name].__doc__ = loong.system.methodHelp(method)
    d['debug'] = _client.debug

_client = LoongClient()
_client.startDaemon()
atexit.register(_client.stopDaemon)
if 'LOONG_SERVER_ADDR' in os.environ:
    _loong_server_addr = os.environ['LOONG_SERVER_ADDR']
else:
    _loong_server_addr = 'localhost'
if 'LOONG_SERVER_PORT' in os.environ:
    _loong_server_port = int(os.environ['LOONG_SERVER_PORT'])
else:
    _loong_server_port = 9000
_loong = xmlrpclib.ServerProxy('http://%s:%s/' % (_loong_server_addr, _loong_server_port), \
                               allow_none = True)
populateNamespace(globals())
