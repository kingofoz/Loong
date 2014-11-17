/*
 * Loong 2.1
 *
 * Author: John Yingjun Li <yjli@vmware.com>
 * Copyright: Copyright (c) 2011-13 VMware, Inc. All Rights Reserved.
 * License: MIT license
 *
 * http://ldtp.freedesktop.org
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights to
 * use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 * of the Software, and to permit persons to whom the Software is furnished to do
 * so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
*/
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using CookComputing.XmlRpc;
using System.Collections.Generic;

namespace Loong
{
    public interface ILoong : IXmlRpcProxy
    {
        [XmlRpcMethod("isalive")]
        bool IsAlive();
        [XmlRpcMethod("sikuliFind")]
        int[] sikuliFind(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliFindAll")]
        int[][] sikuliFindAll(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliWait")]
        void sikuliWait(Object timeOut);
        [XmlRpcMethod("sikuliWait")]
        void sikuliWait(Object region, int timeOut);
        [XmlRpcMethod("sikuliWait")]
        int[] sikuliWait(Object region,  Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliWaitVanish")]
        bool sikuliWaitVanish(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliExists")]
        int[] sikuliExists(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliClick")]
        int sikuliClick(Object region, Object obj, int timeOut = 3, int modifiers = 0);
        [XmlRpcMethod("sikuliDoubleClick")]
        int sikuliDoubleClick(Object region, Object obj, int timeOut = 3, int modifiers = 0);
        [XmlRpcMethod("sikuliRightClick")]
        int sikuliRightClick(Object region, Object obj, int timeOut = 3, int modifiers = 0);
        [XmlRpcMethod("sikuliHighlight")]
        void sikuliHighlight(Object region, Object timeOut);
        [XmlRpcMethod("sikuliHover")]
        int sikuliHover(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliDragDrop")]
        void sikuliDragDrop(Object region, Object pointFrom, Object pointTo, int timeOut = 3, int modifiers = 0);
        [XmlRpcMethod("sikuliDrag")]
        int sikuliDrag(Object region, Object pointFrom, int timeOut = 3);
        [XmlRpcMethod("sikuliDropAt")]
        int sikuliDropAt(Object region, Object pointTo, int delay = 0, int timeOut = 3);
        [XmlRpcMethod("sikuliType")]
        int sikuliType(String text, int modifiers = 0);
        [XmlRpcMethod("sikuliType")]
        int sikuliType(Object region, Object obj, String text, int modifiers = 0, int timeOut = 3);
        [XmlRpcMethod("sikuliPaste")]
        int sikuliPaste(String text);
        [XmlRpcMethod("sikuliPaste")]
        int sikuliPaste(Object region, String text);
        [XmlRpcMethod("sikuliPaste")]
        int sikuliPaste(Object region, Object obj, String text, int timeOut = 3);
        [XmlRpcMethod("sikuliText")]
        string sikuliText(Object region);
        [XmlRpcMethod("sikuliMouseDown")]
        void sikuliMouseDown(int button);
        [XmlRpcMethod("sikuliMouseDown")]
        void sikuliMouseDown(Object region, int button);
        [XmlRpcMethod("sikuliMouseUp")]
        void sikuliMouseUp(int button = 0);
        [XmlRpcMethod("sikuliMouseUp")]
        void sikuliMouseUp(Object region, int button = 0);
        [XmlRpcMethod("sikuliMouseMove")]
        int sikuliMouseMove(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliWheel")]
        void sikuliWheel(int direction, int steps);
        [XmlRpcMethod("sikuliWheel")]
        void sikuliWheel(Object region, int direction, int steps);
        [XmlRpcMethod("sikuliWheel")]
        void sikuliWheel(Object region, Object obj, int direction, int steps, int timeOut = 3);
        [XmlRpcMethod("sikuliKeyDown")]
        void sikuliKeyDown(String text);
        [XmlRpcMethod("sikuliKeyDown")]
        void sikuliKeyDown(Object region, String text);
        [XmlRpcMethod("sikuliKeyUp")]
        void sikuliKeyUp();
        [XmlRpcMethod("sikuliKeyUp")]
        void sikuliKeyUp(String text);
        [XmlRpcMethod("sikuliKeyUp")]
        void sikuliKeyUp(Object region, String text);
        [XmlRpcMethod("sikuliGetRegionFromPSRM")]
        int[] sikuliGetRegionFromPSRM(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliGetLocationFromPSRML")]
        int[] sikuliGetLocationFromPSRML(Object region, Object obj, int timeOut = 3);
        [XmlRpcMethod("sikuliGetMinSimilarity")]
        double sikuliGetMinSimilarity();
        [XmlRpcMethod("sikuliSetMinSimilarity")]
        void sikuliSetMinSimilarity(double value);
        [XmlRpcMethod("sikuliGetCenter")]
        int[] sikuliGetCenter(Object region);
        [XmlRpcMethod("sikuliGetScreen")]
        int[] sikuliGetScreen(Object region);
        [XmlRpcMethod("sikuliOffset")]
        int[] sikuliOffset(Object region, int[] location);
        [XmlRpcMethod("sikuliNearby")]
        int[] sikuliNearby(Object region, int value);
        [XmlRpcMethod("sikuliAbove")]
        int[] sikuliAbove(Object region, int value);
        [XmlRpcMethod("sikuliBelow")]
        int[] sikuliBelow(Object region, int value);
        [XmlRpcMethod("sikuliLeft")]
        int[] sikuliLeft(Object region, int value);
        [XmlRpcMethod("sikuliRight")]
        int[] sikuliRight(Object region, int value);
        [XmlRpcMethod("sikuliGetNumberScreens")]
        int sikuliGetNumberScreens();
        [XmlRpcMethod("sikuliGetBounds")]
        int[] sikuliGetBounds(int screenId);
        [XmlRpcMethod("sikuliCapture")]
        string sikuliCapture(Object region);
        [XmlRpcMethod("sikuliCapture")]
        string sikuliCapture(int screenId, Object region);
    }
    public class Loong
    {
        ILoong proxy;
        Process ps = null;
        String serverAddr = null;
        String serverPort = null;
        private void connectToServer()
        {
            if (serverAddr == null)
                serverAddr = Environment.GetEnvironmentVariable("LOONG_SERVER_ADDR");
            if (serverAddr == null)
                serverAddr = "localhost";
            if (serverPort == null)
                serverPort = Environment.GetEnvironmentVariable("LOONG_SERVER_PORT");
            if (serverPort == null)
                serverPort = "9000";
            proxy = (ILoong)XmlRpcProxyGen.Create(typeof(ILoong));
            String url = String.Format("http://{0}:{1}/RPC2", serverAddr, serverPort);
            proxy.Url = url;
            IsAlive();
        }
        private Boolean IsAlive()
        {
            Boolean isAlive = false;
            try
            {
                isAlive = proxy.IsAlive();
            }
            catch
            {
                // Do nothing on exception
                ;
            }
            if (!isAlive)
                launchLoongProcess();
            return isAlive;
        }
        void InternalLaunchProcess(object data)
        {
            Process ps = data as Process;
            // Wait for the application to quit
            ps.WaitForExit();
            // Close the handle, so that we won't leak memory
            ps.Close();
            ps = null;
        }
        private void launchLoongProcess()
        {
            ps = new Process();
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "java";
                psi.Arguments = "org.python.util.jython -Dpython.path=" + '"' +
                    Environment.GetEnvironmentVariable("LOONG_HOME") + '"' + " -m Loongd";
                psi.UseShellExecute = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo = psi;
                ps.Start();
                Thread thread = new Thread(new ParameterizedThreadStart(
                    InternalLaunchProcess));
                // Clean up in different thread
                //thread.Start(ps);
                // Wait 5 seconds after launching
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                throw new LoongExecutionError(ex.Message);
            }
        }
        ~Loong()
        {
            if (ps != null)
            {
                try
                {
                    ps.Kill();
                }
                catch
                {
                    // Silently ignore any exception
                }
            }
        }
        public Loong(String serverAddr = "localhost", String serverPort = "9000")
        {
            this.serverAddr = serverAddr;
            this.serverPort = serverPort;
            connectToServer();
        }
        public int[] sikuliFind(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliFind(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[][] sikuliFindAll(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliFindAll(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliWait(Object timeOut)
        {
            try
            {
                proxy.sikuliWait(timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliWait(Object region, int timeOut)
        {
            try
            {
                proxy.sikuliWait(region, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliWait(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliWait(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public bool sikuliWaitVanish(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliWaitVanish(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliExists(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliExists(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliClick(Object region, Object obj, int timeOut = 3, int modifiers = 0)
        {
            try
            {
                return proxy.sikuliClick(region, obj, timeOut, modifiers);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliDoubleClick(Object region, Object obj, int timeOut = 3, int modifiers = 0)
        {
            try
            {
                return proxy.sikuliDoubleClick(region, obj, timeOut, modifiers);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliRightClick(Object region, Object obj, int timeOut = 3, int modifiers = 0)
        {
            try
            {
                return proxy.sikuliRightClick(region, obj, timeOut, modifiers);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliHighlight(Object region, Object timeOut)
        {
            try
            {
                proxy.sikuliHighlight(region, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliHover(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliHover(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliDragDrop(Object region, Object pointFrom, Object pointTo, int timeOut = 3, int modifiers = 0)
        {
            try
            {
                proxy.sikuliDragDrop(region, pointFrom, pointTo, timeOut, modifiers);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliDrag(Object region, Object pointFrom, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliDrag(region, pointFrom, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliDropAt(Object region, Object pointTo, int delay = 0, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliDropAt(region, pointTo, delay, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliType(String text, int modifiers = 0)
        {
            try
            {
                return proxy.sikuliType(text, modifiers);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliType(Object region, Object obj, String text, int modifiers = 0, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliType(region, obj, text, modifiers, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliPaste(String text)
        {
            try
            {
                return proxy.sikuliPaste(text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliPaste(Object region, String text)
        {
            try
            {
                return proxy.sikuliPaste(region, text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliPaste(Object region, Object obj, String text, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliPaste(region, obj, text, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public string sikuliText(Object region)
        {
            try
            {
                return proxy.sikuliText(region);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliMouseDown(int button)
        {
            try
            {
                proxy.sikuliMouseDown(button);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliMouseDown(Object region, int button)
        {
            try
            {
                proxy.sikuliMouseDown(region, button);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliMouseUp(int button = 0)
        {
            try
            {
                proxy.sikuliMouseUp(button);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliMouseUp(Object region, int button = 0)
        {
            try
            {
                proxy.sikuliMouseUp(region, button);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliMouseMove(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliMouseMove(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliWheel(int direction, int steps)
        {
            try
            {
                proxy.sikuliWheel(direction, steps);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliWheel(Object region, int direction, int steps)
        {
            try
            {
                proxy.sikuliWheel(region, direction, steps);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliWheel(Object region, Object obj, int direction, int steps, int timeOut = 3)
        {
            try
            {
                proxy.sikuliWheel(region, obj, direction, steps, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliKeyDown(String text)
        {
            try
            {
                proxy.sikuliKeyDown(text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliKeyDown(Object region, String text)
        {
            try
            {
                proxy.sikuliKeyDown(region, text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliKeyUp()
        {
            try
            {
                proxy.sikuliKeyUp();
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliKeyUp(String text)
        {
            try
            {
                proxy.sikuliKeyUp(text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliKeyUp(Object region, String text)
        {
            try
            {
                proxy.sikuliKeyUp(region, text);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliGetRegionFromPSRM(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliGetRegionFromPSRM(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliGetLocationFromPSRML(Object region, Object obj, int timeOut = 3)
        {
            try
            {
                return proxy.sikuliGetLocationFromPSRML(region, obj, timeOut);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public double sikuliGetMinSimilarity()
        {
            try
            {
                return proxy.sikuliGetMinSimilarity();
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public void sikuliSetMinSimilarity(double value)
        {
            try
            {
                proxy.sikuliSetMinSimilarity(value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliGetCenter(Object region)
        {
            try
            {
                return proxy.sikuliGetCenter(region);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliGetScreen(Object region)
        {
            try
            {
                return proxy.sikuliGetScreen(region);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliOffset(Object region, int[] location)
        {
            try
            {
                return proxy.sikuliOffset(region, location);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliNearby(Object region, int value)
        {
            try
            {
                return proxy.sikuliNearby(region, value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliAbove(Object region, int value)
        {
            try
            {
                return proxy.sikuliAbove(region, value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliBelow(Object region, int value)
        {
            try
            {
                return proxy.sikuliBelow(region, value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliLeft(Object region, int value)
        {
            try
            {
                return proxy.sikuliLeft(region, value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliRight(Object region, int value)
        {
            try
            {
                return proxy.sikuliRight(region, value);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int sikuliGetNumberScreens()
        {
            try
            {
                return proxy.sikuliGetNumberScreens();
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public int[] sikuliGetBounds(int screenId)
        {
            try
            {
                return proxy.sikuliGetBounds(screenId);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public string sikuliCapture(Object region)
        {
            try
            {
                return proxy.sikuliCapture(region);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
        public string sikuliCapture(int screenId, Object region)
        {
            try
            {
                return proxy.sikuliCapture(screenId, region);
            }
            catch (XmlRpcFaultException ex)
            {
                throw new LoongExecutionError(ex.FaultString);
            }
        }
    }
}
