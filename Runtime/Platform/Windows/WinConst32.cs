
// https://learn.microsoft.com/en-us/windows/win32/menurc/wm-syscommand

class W32Consts
{
    public const int SWP_NOSIZE = 0x0001;
    public const int SWP_NOMOVE = 0x0002;
    public const int SWP_NOZORDER = 0x0004;
    public const int SWP_FRAMECHANGED = 0x0020;
    public const int SWP_SHOWWINDOW = 0x0040;
    public const int SWP_NOOWNERZORDER = 0x0200;
    
    public const int SW_SHOW = 5;
    public const int SW_MINIMIZE = 6;
    public const int SW_MAXIMIZE = 3;
    public const int SW_RESTORE = 9;
    
    public const uint WS_VISIBLE = 0x10000000;    
    public const uint WS_POPUP = 0x80000000;
    public const uint WS_BORDER = 0x00800000;
    public const uint WS_OVERLAPPED = 0x00000000;
    public const uint WS_CAPTION = 0x00C00000;
    public const uint WS_SYSMENU = 0x00080000;
    public const uint WS_THICKFRAME = 0x00040000;
    public const uint WS_MINIMIZEBOX = 0x00020000;
    public const uint WS_MAXIMIZEBOX = 0x00010000;
    public const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
    
    public const int GWLP_WNDPROC = -4;
    public const int GWLP_HINSTANCE = -6;
    public const int GWLP_ID = -12;
    public const int GWL_STYLE = -16;
    public const int GWL_EXSTYLE = -20;
    public const int GWLP_USERDATA = -21;
    
    public const uint WM_PAINT = 0x000F;
    public const uint WM_NCCALCSIZE = 0x0083;
    public const uint WM_NCHITTEST = 0x0084;
    public const uint WM_CREATE = 0x0001;
    public const uint WM_INITDIALOG = 0x0110;
    public const uint WM_SYSCOMMAND = 0x0112;

    public const uint WM_MOUSEMOVE = 0x0200;
    public const uint WM_LBUTTONDOWN = 0x0201;
    public const uint WM_LBUTTONUP = 0x0202;
    
    public const int SM_CXBORDER = 0x20;
    public const int SM_CYBORDER = 0x21;
    public const int SM_CXPADDEDBORDER = 0x92;
    public const int SM_CYPADDEDBORDER = 0x93;
    
    public const int HTLEFT = 10;
    public const int HTRIGHT = 11;
    public const int HTTOP = 12;
    public const int HTTOPLEFT = 13;
    public const int HTTOPRIGHT = 14;
    public const int HTBOTTOM = 15;
    public const int HTBOTTOMLEFT = 16;
    public const int HTBOTTOMRIGHT = 17;
    public const int HTNOWHERE = 0;
    public const int HTCLIENT = 1;
    public const int HTCAPTION = 2;
    
    public const uint SC_MOVE = 0xF010;
    public const uint SC_RESTORE = 0xF120;
    public const uint SC_MINIMIZE = 0xF020;
    public const uint SC_MAXIMIZE = 0xF030;
    
    public const int WH_JOURNALRECORD = 0;
    public const int WH_JOURNALPLAYBACK = 1;
    public const int WH_KEYBOARD = 2;
    public const int WH_GETMESSAGE = 3;
    public const int WH_CALLWNDPROC = 4;
    public const int WH_CBT = 5;
    public const int WH_SYSMSGFILTER = 6;
    public const int WH_MOUSE = 7;
    public const int WH_HARDWARE = 8;
    public const int WH_DEBUG = 9;
    public const int WH_SHELL = 10;
    public const int WH_FOREGROUNDIDLE = 11;
    public const int WH_CALLWNDPROCRET = 12;
    public const int WH_KEYBOARD_LL = 13;
    public const int WH_MOUSE_LL = 14;
    
    public const int CF_DIB = 8;
    public const int CF_UNICODETEXT = 13;
    
    
    public const int BI_RGB = 0x0000;
    public const int BI_RLE8 = 0x0001;
    public const int BI_RLE4 = 0x0002;
    public const int BI_BITFIELDS = 0x0003;
    public const int BI_JPEG = 0x0004;
    public const int BI_PNG = 0x0005;
    public const int BI_CMYK = 0x000B;
    public const int BI_CMYKRLE8 = 0x000C;
    public const int BI_CMYKRLE4 = 0x000D;
}

public enum WM_SYSCOMMAND
{
    SC_SIZE = 0xF000,
    SC_MOVE = 0xF010,
    SC_MINIMIZE = 0xF020,
    SC_MAXIMIZE = 0xF030,
    SC_NEXTWINDOW = 0xF040,
    SC_PREVWINDOW = 0xF050,
    SC_CLOSE = 0xF060,
    SC_VSCROLL = 0xF070,
    SC_HSCROLL = 0xF080,
    SC_MOUSEMENU = 0xF090,
    SC_KEYMENU = 0xF100,
    SC_ARRANGE = 0xF110,
    SC_RESTORE = 0xF120,
    SC_TASKLIST = 0xF130,
    SC_SCREENSAVE = 0xF140,
    SC_HOTKEY = 0xF150,
    SC_DEFAULT = 0xF160,
    SC_MONITORPOWER = 0xF170,
    SC_CONTEXTHELP = 0xF180
}