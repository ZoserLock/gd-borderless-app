using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct W32Rect
{
    public int left;
    public int top;
    public int right; 
    public int bottom;

    public override string ToString()
    {
        return $"Left: {left}, Top: {top}, Right: {right}, Bottom: {bottom}";
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct NCCALCSIZE_PARAMS
{
    public W32Rect rgrc0, rgrc1, rgrc2;
    public IntPtr lppos;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct W32MonitorInfoEx
{
    public int cbSize;
    public W32Rect rcMonitor;
    public W32Rect rcWork;
    public int dwFlags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string szDevice;
}

[StructLayout(LayoutKind.Sequential)]
public struct W32WindowPlacement
{
    public int length;
    public int flags;
    public int showCmd;
    public System.Drawing.Point ptMinPosition;
    public System.Drawing.Point ptMaxPosition;
    public W32Rect rcNormalPosition;
}

[StructLayout(LayoutKind.Sequential)]
public struct W32Margins
{
    public int cxLeftWidth;
    public int cxRightWidth;
    public int cyTopHeight;
    public int cyBottomHeight;
    
    public W32Margins(int left, int top, int right, int bottom)
    {
        cxLeftWidth = left;
        cyTopHeight = top;
        cxRightWidth = right;
        cyBottomHeight = bottom;
    }
}