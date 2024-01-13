using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class WinDwm32
{
    [DllImport("dwmapi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref W32Margins pMarInset);
    
    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, IntPtr pMarIn, IntPtr pMarOut);
    
    [DllImport("dwmapi.dll")]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

}
