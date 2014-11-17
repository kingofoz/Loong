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
import inspect
from sikuli.Sikuli import *
from SimpleXMLRPCServer import (SimpleXMLRPCServer, list_public_methods)

def createRegion(region):
    if region == 'Screen':
        return Screen(0)
    x = int(region[0])
    y = int(region[1])
    width = int(region[2])
    height = int(region[3])
    return Region(x, y, width, height)

def createLocation(location):
    x = int(location[0])
    y = int(location[1])
    return Location(x, y)

def createScreen(screenId):
    return Screen(screenId)

def createPattern(pattern):
    return Pattern(pattern[0]).similar(pattern[1])

def getRegion(region):
    return [region.getX(), region.getY(), region.getW(), region.getH()]

def getLocation(location):
    return [int(location.getX()), int(location.getY())]

def getRect(rect):
    return [int(rect.getX()), int(rect.getY()), int(rect.getWidth()), int(rect.getHeight())]

def getTarget(match):
    target = match.getTarget()
    return [int(target.getX()), int(target.getY())]

class LoongService:
    def _listMethods(self):
        return list_public_methods(self)

    def _methodHelp(self, method):
        f = getattr(self, method)
        return inspect.getdoc(f)

    def version(self):
        return 'Loong 2.2'

    def find(self, region, obj, timeOut = 3):
        if isinstance(obj, list) and isinstance(obj[0], str):
            obj = createPattern(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        match = getTarget(region.find(obj))
        return match

    def findAll(self, region, obj, timeOut = 3):
        if isinstance(obj, list) and isinstance(obj[0], str):
            obj = createPattern(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        objList = region.findAll(obj)
        locationList = []
        for obj in objList:
            locationList.append(getTarget(obj))
        return locationList

    def wait(self, region, obj = None, timeOut = 3):
        if isinstance(region, int) or isinstance(region, float):
            timeOut = region
            return wait(timeOut)
        region = createRegion(region)
        if isinstance(obj, int) or isinstance(obj, float):
            timeOut = obj
            return region.wait(timeOut)
        elif isinstance(obj, list) and isinstance(obj[0], str):
            obj = createPattern(obj)
        match = getTarget(region.wait(obj, timeOut))
        return match

    def waitVanish(self, region, obj, timeOut = 3):
        if isinstance(obj, list) and isinstance(obj[0], str):
            obj = createPattern(obj)
        return createRegion(region).waitVanish(obj, timeOut)

    def exists(self, region, obj, timeOut = 3):
        if isinstance(obj, list) and isinstance(obj[0], str):
            obj = createPattern(obj)
        match = createRegion(region).exists(obj, timeOut)
        if match:
            return getTarget(match)
        else:
            return []

    def click(self, region, obj, timeOut = 3, modifiers = 0):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.click(obj, modifiers)
        return result

    def doubleClick(self, region, obj, timeOut = 3, modifiers = 0):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.doubleClick(obj, modifiers)
        return result

    def rightClick(self, region, obj, timeOut = 3, modifiers = 0):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.rightClick(obj, modifiers)
        return result

    def highlight(self, region, timeOut):
        createRegion(region).highlight(timeOut)

    def hover(self, region, obj, timeOut = 3):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.hover(obj)
        return result

    def dragDrop(self, region, pointFrom, pointTo, timeOut = 3):
        if isinstance(pointFrom, list):
            if isinstance(pointFrom[0], str):
                pointFrom = createPattern(pointFrom)
            elif len(pointFrom) == 2:
                pointFrom = createLocation(pointFrom)
            elif len(pointFrom) == 4:
                pointFrom = createRegion(pointFrom)
        if isinstance(pointTo, list):
            if isinstance(pointTo[0], str):
                pointTo = createPattern(pointTo)
            elif len(pointTo) == 2:
                pointTo = createLocation(pointTo)
            elif len(pointTo) == 4:
                pointTo = createRegion(pointTo)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        region.dragDrop(pointFrom, pointTo)

    def drag(self, region, pointFrom, timeOut = 3):
        if isinstance(pointFrom, list):
            if isinstance(pointFrom[0], str):
                pointFrom = createPattern(pointFrom)
            elif len(pointFrom) == 2:
                pointFrom = createLocation(pointFrom)
            elif len(pointFrom) == 4:
                pointFrom = createRegion(pointFrom)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.drag(pointFrom)
        return result

    def dropAt(self, region, pointTo, timeOut = 3):
        if isinstance(pointTo, list):
            if isinstance(pointTo[0], str):
                pointTo = createPattern(pointTo)
            elif len(pointTo) == 2:
                pointTo = createLocation(pointTo)
            elif len(pointTo) == 4:
                pointTo = createRegion(pointTo)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.dropAt(pointTo)
        return result

    def type(self, region, obj = None, text = None, modifiers = 0, timeOut = 3):
        if obj is None:
            text = region
            result = type(text, modifiers)
            return result
        elif isinstance(obj, int):
            text = region
            modifiers = obj
            result = type(text, modifiers)
            return result
        elif isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.type(obj, text, modifiers)
        return result

    def paste(self, region, obj = None, text = None, timeOut = 3):
        if obj is None:
            text = region
            return paste(text)
        elif isinstance(obj, str) and text is None:
            text = obj
            obj = None
        elif isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.paste(obj, text)
        return result

    def text(self, region):
        return createRegion(region).text()

    def mouseDown(self, region, button = None):
        if button is None:
            button = region
            mouseDown(button)
        else:
            createRegion(region).mouseDown(button)

    def mouseUp(self, region = 0, button = 0):
        if isinstance(region, int):
            button = region
            mouseUp(button)
        else:
            createRegion(region).mouseUp(button)

    def mouseMove(self, region, obj, timeOut = 3):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = region.mouseMove(obj)
        return result

    def wheel(self, region, obj, direction = None, steps = None, timeOut = 3):
        if direction is None:
            direction = region
            steps = obj
            wheel(direction, steps)
            return
        elif steps is None:
            steps = direction
            direction = obj
            obj = None
        elif isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        region.wheel(obj, direction, steps)

    def keyDown(self, region, keys = None):
        if keys is None:
            keys = region
            keyDown(keys)
        else:
            createRegion(region).keyDown(keys)

    def keyUp(self, region = None, keys = None):
        if region is None:
            keyUp()
        elif keys is None:
            keys = region
            keyUp(keys)
        else:
            createRegion(region).keyUp(keys)

    def getRegionFromPSRM(self, region, obj, timeOut = 3):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif (len(obj) == 4):
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = getRegion(region.getRegionFromPSRM(obj))
        return result

    def getLocationFromPSRML(self, region, obj, timeOut = 3):
        if isinstance(obj, list):
            if isinstance(obj[0], str):
                obj = createPattern(obj)
            elif len(obj) == 2:
                obj = createLocation(obj)
            elif len(obj) == 4:
                obj = createRegion(obj)
        region = createRegion(region)
        region.setAutoWaitTimeout(timeOut)
        result = getLocation(region.getLocationFromPSRML(obj))
        return result

    def getMinSimilarity(self):
        return Settings.MinSimilarity

    def setMinSimilarity(self, value):
        Settings.MinSimilarity = value

    def getTextSearch(self):
        return Settings.OcrTextSearch

    def setTextSearch(self, value):
        Settings.OcrTextSearch = value

    def getTextRead(self):
        return Settings.OcrTextRead

    def setTextRead(self, value):
        Settings.OcrTextRead = value

    def getCenter(self, region):
        return getLocation(createRegion(region).getCenter())

    def getScreen(self, region):
        return getRect(createRegion(region).getScreen().getBounds())

    def offset(self, region, location):
        return getRegion(createRegion(region).offset(createLocation(location)))

    def nearby(self, region, value):
        return getRegion(createRegion(region).nearby(value))

    def above(self, region, value):
        return getRegion(createRegion(region).above(value))

    def below(self, region, value):
        return getRegion(createRegion(region).below(value))

    def left(self, region, value):
        return getRegion(createRegion(region).left(value))

    def right(self, region, value):
        return getRegion(createRegion(region).right(value))

    def getNumberScreens(self):
        return getNumberScreens()

    def getBounds(self, screenId):
        return getRect(createScreen(screenId).getBounds())

    def capture(self, screenId, region = None):
        if region is None:
            region = screenId
            screenId = 0
        return createScreen(screenId).capture(createRegion(region))

_loongService = LoongService()
if 'LOONG_SERVER_PORT' in os.environ:
    _loong_server_port = int(os.environ['LOONG_SERVER_PORT'])
else:
    _loong_server_port = 9000
_server = SimpleXMLRPCServer(('localhost', _loong_server_port), allow_none = True)
_server.register_introspection_functions()
_server.register_instance(_loongService)
print 'Listening on port %s' % _loong_server_port
_server.serve_forever()
