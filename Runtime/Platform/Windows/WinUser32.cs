using System;
using System.Runtime.InteropServices;

public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

public static class Win32Macros
{
    public static int GET_X_LPARAM(IntPtr lParam)
    {
        return (int)(short)LOWORD(lParam);
    }

    public static int GET_Y_LPARAM(IntPtr lParam)
    {
        return (int)(short)HIWORD(lParam);
    }

    private static int LOWORD(IntPtr lParam)
    {
        return (int)(lParam.ToInt64() & 0xffff);
    }

    private static int HIWORD(IntPtr lParam)
    {
        return (int)(lParam.ToInt64() >> 16) & 0xffff;
    }
}

public static class WinUser32
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool EmptyClipboard();
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetClipboardData(uint uFormat);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseClipboard();
    
    [DllImport("User32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);
    
    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern bool GetMonitorInfoW(IntPtr hMonitor, ref W32MonitorInfoEx lpmi);
    
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
    [DllImport("user32.dll")]
    public static extern IntPtr FindWindow(string className, string windowName);
    
    [DllImport("user32.dll")]
    public static extern bool GetWindowPlacement(IntPtr hWnd, ref W32WindowPlacement lpwndpl);
    
    // https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getactivewindow
    [DllImport("user32.dll")]
    public static extern IntPtr GetActiveWindow();
    
    [DllImport("user32.dll")]
    public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);
    
    [DllImport("user32.dll")]
    public static extern IntPtr MonitorFromRect(ref W32Rect lprc, uint dwFlags);
    
    [DllImport("user32.dll")]
    public static extern int GetWindowLong(int hWnd, int nIndex);
    
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowLongPtr(int hWnd, int nIndex);
    
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    
    [DllImport("user32.dll")]
    public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    
    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    
    [DllImport("user32.dll")]
    public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);
    
    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref W32Rect rectangle);
    
    [DllImport("user32.dll")]
    public static extern IntPtr CallWindowProc(
        IntPtr lpPrevWndFunc,
        IntPtr hWnd,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam);
    
    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int nIndex);
    
    
    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);
    
    [DllImport("user32.dll")]
    public static extern IntPtr SetCursor(IntPtr hCursor);
    
    
}
