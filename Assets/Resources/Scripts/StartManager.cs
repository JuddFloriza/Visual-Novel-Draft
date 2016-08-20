using UnityEngine;
using System.Collections;

public class StartManager : Manager
{
    private GameObject startPrefab;
    private Canvas canvas;

    protected override void initializeManager(params object[] param)
    {
        startPrefab = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/StartPrefab"));
        startPrefab.transform.SetParent(SceneManager.currentScene.getTransform);
        
        canvas = startPrefab.transform.FindChild("Canvas").GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
    }

    protected override bool hasInitializeManager()
    {
        return true;
    }

    protected override void updateManager(float dt)
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.replaceCurrentScene<GameScene>();
        }
    }
}
