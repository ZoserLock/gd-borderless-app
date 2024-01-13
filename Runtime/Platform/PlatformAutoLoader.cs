using Godot;

public partial class PlatformAutoLoader : Node
{
    public override void _Ready()
    {
        base._Ready();
        
        if (GetWindow().Borderless == true)
        {
            //ZenLog.Error("[Platform Auto Loader]: Please disable borderless mode in Project Settings -> Window -> Window Mode");
            return;
        }
        // Initialize Platform (Win/OSX/Linux) specific stuff
        Platform.InitializePlatform();
    }
}
