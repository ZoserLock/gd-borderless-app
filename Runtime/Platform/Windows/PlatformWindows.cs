using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Godot;
using Zen.Core;

#if GODOT_WINDOWS

namespace Zen.Core
{
    public class PlatformWindows
    {
        private static WndProcDelegate _newWndProc;
        private static IntPtr _newWndProcPtr;
        private static IntPtr _oldWndProcPtr;

        private static IntPtr _windowHandle;

        private static bool _hookedIntoWin32;

        private static bool _captionForced = false;

        public static void SetCaptionForced(bool forced)
        {
            _captionForced = forced;
        }
        
        public static void HookIntoWin32()
        {
            if (!_hookedIntoWin32)
            {
                var handle = DisplayServer.WindowGetNativeHandle(DisplayServer.HandleType.WindowHandle, 0);
                var hWnd = new IntPtr(handle);
                
                WinUser32.GetWindowThreadProcessId(hWnd, out var processId);

                _windowHandle = hWnd;

                _newWndProc = WndProc;
                _newWndProcPtr = Marshal.GetFunctionPointerForDelegate(_newWndProc);

                _oldWndProcPtr = WinUser32.SetWindowLongPtr(_windowHandle, W32Consts.GWLP_WNDPROC, _newWndProcPtr);

                WinUser32.SetWindowLong(_windowHandle, W32Consts.GWL_STYLE,
                    W32Consts.WS_POPUP | W32Consts.WS_THICKFRAME | W32Consts.WS_CAPTION | W32Consts.WS_SYSMENU | W32Consts.WS_MAXIMIZEBOX | W32Consts.WS_MINIMIZEBOX);

                // ENABLE SHADOW BEGIN
                var margins = new W32Margins()
                {
                    cxLeftWidth = 1,
                    cxRightWidth = 1,
                    cyTopHeight = 1,
                    cyBottomHeight = 1
                };

                WinDwm32.DwmExtendFrameIntoClientArea(_windowHandle, ref margins);
                // ENABLE SHADOW END

                // Window Force redraw 
                WinUser32.SetWindowPos(_windowHandle, 0, 0, 0, 0, 0, W32Consts.SWP_FRAMECHANGED | W32Consts.SWP_NOMOVE | W32Consts.SWP_NOSIZE | W32Consts.SWP_NOZORDER | W32Consts.SWP_NOOWNERZORDER);

                WinUser32.ShowWindow(_windowHandle, W32Consts.SW_SHOW);
                
                _hookedIntoWin32 = true;
            }
        }

        public static void UnhookFromWin32()
        {
            if (_hookedIntoWin32)
            {
                WinUser32.SetWindowLongPtr(_windowHandle, W32Consts.GWLP_WNDPROC, _oldWndProcPtr);
                _hookedIntoWin32 = false;
            }
        }

        public static bool IsWindowMaximized()
        {
            var placement = new W32WindowPlacement();

            if (!WinUser32.GetWindowPlacement(_windowHandle, ref placement))
            {
                return false;
            }

            return placement.showCmd == W32Consts.SW_MAXIMIZE;
        }

        private static bool IsMaximized(IntPtr hWnd)
        {
            var placement = new W32WindowPlacement();

            if (!WinUser32.GetWindowPlacement(hWnd, ref placement))
            {
                return false;
            }

            return placement.showCmd == W32Consts.SW_MAXIMIZE;
        }

        private static void AdjustMaximizedClientRect(IntPtr hWnd, ref W32Rect rect)
        {
            if (!IsMaximized(hWnd))
            {
                return;
            }

            var monitor = WinUser32.MonitorFromWindow(hWnd, 0);
            if (monitor == IntPtr.Zero)
            {
                monitor = WinUser32.MonitorFromRect(ref rect, 2);
            }

            var monitor_info = new W32MonitorInfoEx();
            monitor_info.cbSize = Marshal.SizeOf(typeof(W32MonitorInfoEx));

            if (!WinUser32.GetMonitorInfoW(monitor, ref monitor_info))
            {
                return;
            }

            rect = monitor_info.rcWork;
        }

        private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case W32Consts.WM_NCHITTEST:

                    if (_captionForced)
                    {
                        return (IntPtr)W32Consts.HTCAPTION;
                    }

                    var windowRect32 = new W32Rect();
                    WinUser32.GetWindowRect(_windowHandle, ref windowRect32);

                    var windowRect = new Rect2(windowRect32.left, windowRect32.top, windowRect32.right - windowRect32.left, windowRect32.bottom - windowRect32.top);

                    var x = Win32Macros.GET_X_LPARAM(lParam);
                    var y = Win32Macros.GET_Y_LPARAM(lParam);

                    var inset = windowRect.Inset(WinUser32.GetSystemMetrics(W32Consts.SM_CXBORDER) + WinUser32.GetSystemMetrics(W32Consts.SM_CXPADDEDBORDER),
                        WinUser32.GetSystemMetrics(W32Consts.SM_CYBORDER) + WinUser32.GetSystemMetrics(W32Consts.SM_CYPADDEDBORDER));

                    var position = new Vector2(x, y);
                    if (windowRect.HasPoint(position) && !inset.HasPoint(position))
                    {
                        var direction = inset.GetPointDirection(position);

                        return (IntPtr)direction.ToWin32();
                    }

                    if (!windowRect.HasPoint(position))
                    {
                        return (IntPtr)W32Consts.HTNOWHERE;
                    }

                    break;

                case W32Consts.WM_NCCALCSIZE:
                    if (wParam.ToInt32() == 1)
                    {
                        var calsSizeParams = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(lParam, typeof(NCCALCSIZE_PARAMS));

                        AdjustMaximizedClientRect(_windowHandle, ref calsSizeParams.rgrc0);

                        Marshal.StructureToPtr(calsSizeParams, lParam, false);
                        WinUser32.SetWindowPos(_windowHandle, 0, 0, 0, 0, 0, W32Consts.SWP_FRAMECHANGED | W32Consts.SWP_NOMOVE | W32Consts.SWP_NOSIZE);
                        return (IntPtr)0;
                    }

                    break;
            }

            return WinUser32.CallWindowProc(_oldWndProcPtr, hWnd, msg, wParam, lParam);
        }

        public static void MinimizeWindow()
        {
            WinUser32.ShowWindow(_windowHandle, W32Consts.SW_MINIMIZE);
        }

        public static void MaximizeWindow()
        {
            WinUser32.ShowWindow(_windowHandle, W32Consts.SW_MAXIMIZE);
        }

        public static void RestoreWindow()
        {
            WinUser32.ShowWindow(_windowHandle, W32Consts.SW_RESTORE);
        }
    }
}
#endif