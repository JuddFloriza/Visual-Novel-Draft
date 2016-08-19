using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : Manager
{
	public static int sceneCount = 0;
	public static Scene currentScene;
	private static List<Scene> sceneList;
	protected SceneManager instance;

	/// <summary>
	/// Creates an instance of SceneManager
	/// </summary>
	public SceneManager()
	{
		sceneList = new List<Scene>();
	}

	/// <summary>
	/// Gets scene at int index from list of scenes.
	/// </summary>
	/// <param name="index">Index to be looked for.</param>
	/// <returns>Returns scene at int index.</returns>
	public static Scene getSceneAt (int index)
	{
		Scene scene;
		scene = sceneList[index];

		return scene;
	}

	/// <summary>
	/// Creates a scene and sets it as the Current Scene if it is not the current scene.
	/// </summary>
	/// <param name="sceneName">The name of your scene.</param>
	/// <returns>The scene instance</returns>
	public static T setCurrentSceneChild<T>() where T: Scene, new()
	{
		T scene = new T();

		if(scene != null)
		{
			currentScene = scene;
			sceneList.Add (scene);
		}
		return scene;
	}

	public static T replaceCurrentScene<T>() where T: Scene, new()
	{
		T scene = new T();

		if(currentScene != null)
		{
			scene.setParent(currentScene.parent);
			currentScene.Dispose(); //Destroy gameobject and unload resources
			sceneList.Remove(currentScene);
		}
		if(scene != null)
		{
			currentScene = scene;
			sceneList.Add(scene);
		}

        scene.initializeScene();
		return scene;
	}

    protected override void initializeManager(params object[] param)
    {
        initializeScene();
    }

    // Use this for initialization
    protected virtual void initializeScene () 
	{
        if(currentScene != null)
        {
            currentScene.initializeScene();
        }
	}

	protected virtual void hasInitializeScene ()
	{
		
	}
	
	// Update is called once per frame
	protected virtual void updateScene () 
	{
	
	}

	protected virtual void disposeScene ()
	{

	}

}
