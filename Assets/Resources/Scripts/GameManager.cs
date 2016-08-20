using UnityEngine;
using System.Collections;

public class GameManager : Manager
{
    private GameObject vNObj = null;
    private Canvas canvas = null;

    protected override void initializeManager(params object[] param)
    {
       vNObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Scene"));
       vNObj.transform.parent = SceneManager.currentScene.getTransform;
       canvas = vNObj.transform.FindChild("Canvas").GetComponent<Canvas>();
       canvas.renderMode = RenderMode.ScreenSpaceCamera;
       canvas.worldCamera = Camera.main;
    }
}
