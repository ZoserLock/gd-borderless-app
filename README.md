# Godot Borderless App Example

## About

This is an implementation for Godot of a Windows Borderless Window that is resizable have the expected snap features and also have shadow.

This code is a C# implementation of this inspired/based/copied from the excelent code of https://github.com/melak47/BorderlessWindow

This code also works in Unity with minor changes.

Currently just for **Windows**

### Features
- **Borderless**: The app window do not have borders (same as `GetWindow().Borderless = true`)
- **Resize Handles**: The app window can be resized.
- **Aero Snap**: The app window snaps to the borders while resized, snap to full screen/restore on double click and snap to full screen while dragging to top. Also restores while dragged in fullscreen.
- **Window Shadow**: The borderless window have drop shadow.

## How to Run
- Run the main scene

## How to Use
- Set the Godot Borderless Option to false in the project settings. This is a must if you want window shadow.
- Copy the scripts files into your project
- Add PlatformAutoLoader.cs as an AutoLoad Script inside godot or call:
```cs
    // Call this somewhere in your code.
    Platform.InitializePlatform();
```
- Add a control with the script **UICaptionBar** to the part of screen that is dragable. 
In the example code is just the empty section of the custom title bar. (see the main scene)


