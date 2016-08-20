using UnityEngine;
using System.Collections;

public class StartScene : Scene
{
    public override void initializeScene(params object[] param)
    {
        Main.CreateManager<StartManager>(this);
    }

    public override bool hasInitializeScene()
    {
        return true;
    }
}
