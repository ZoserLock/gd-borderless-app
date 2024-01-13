using Godot;
using System;
using Zen.Core;

namespace Zen.UI
{
    public partial class UICaptionBar : MarginContainer
    {
        const int kMarginTop = 4;
        
        [Export]
        private Control _filler;
        
        public override void _Ready()
        {
            AddThemeConstantOverride("margin_top", kMarginTop);
        }
        
        public override void _Process(double delta)
        {
            base._Process(delta);
            
            // Convert global mouse position to control's local space
            var localMousePosition = GetGlobalMousePosition() - _filler.GetGlobalRect().Position;

            // Check if the local mouse position is inside the control's rect
            if (GetRect().HasPoint(localMousePosition))
            {
                Platform.SetCaptionForced(true);
            }
            else
            {
                Platform.SetCaptionForced(false);
            }

            if (PlatformWindows.IsWindowMaximized())
            {
                AddThemeConstantOverride("margin_top", kMarginTop);
            }
            else
            {
                AddThemeConstantOverride("margin_top", kMarginTop);
            }
        }
    }
}