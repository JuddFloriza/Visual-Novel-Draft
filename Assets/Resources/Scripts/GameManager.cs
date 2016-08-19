using UnityEngine;
using System.Collections;

public class GameManager : Manager
{
    GameObject vNObj = null;
    Canvas canvas = null;

    protected override void initializeManager(params object[] param)
    {
       vNObj = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Scene"));
       canvas = vNObj.transform.FindChild("Canvas").GetComponent<Canvas>();
       canvas.renderMode = RenderMode.ScreenSpaceCamera;
       canvas.worldCamera = Camera.main;
    }
}
