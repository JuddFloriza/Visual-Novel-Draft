using UnityEngine;
using System.Collections;

public class GameScene : Scene
{
    public override void initializeScene(params object[] param)
    {
        Main.CreateManager<GameManager>(this);
    }

    public override bool hasInitializeScene()
    {
        return true;
    }
}
