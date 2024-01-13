using System.Collections;
using System.Collections.Generic;
using Zen.Core;

// Static class to handle platform specific code.
// Should have no dependencies on other Zen modules.
// Is only implemented for windows at the moment.
public static class Platform
{
    // Initialize the platformHook into the window message loop.
    // Is automatically called by Unity upon startup.
    public static void InitializePlatform()
    {
        #if GODOT_WINDOWS
            PlatformWindows.HookIntoWin32();
        #endif
    }
    
    // Deinitialize the platformHook from  the window message loop.
    // Needs to be called manually.
    public static void DeinitializePlatform()
    {
        #if GODOT_WINDOWS
                PlatformWindows.UnhookFromWin32();
        #endif
    }
    
    // Minimize the window.
    public static void MinimizeWindow()
    {
        #if GODOT_WINDOWS
            PlatformWindows.MinimizeWindow();
        #endif
    }
    
    // Maximize or restore the window. Also consider as a toggle.
    public static void MaximizeOrRestoreWindow()
    {
        #if GODOT_WINDOWS
            if (PlatformWindows.IsWindowMaximized())
            {
                PlatformWindows.RestoreWindow();
            }
            else
            {
                PlatformWindows.MaximizeWindow();
            }
        #endif
    }

    // Return true if the window is maximized. False otherwise.
    public static bool IsWindowMaximized()
    {
        #if GODOT_WINDOWS
            return PlatformWindows.IsWindowMaximized();
        #else
            return false;
        #endif
    }
    
    // Set the window caption aka the place where the user can drag the window.
    // Normally this is the title of the window. But is a duty of the ui to enable or disable the caption.
    public static void SetCaptionForced(bool forced)
    {
        #if GODOT_WINDOWS
            PlatformWindows.SetCaptionForced(forced);
        #endif
    }
}
