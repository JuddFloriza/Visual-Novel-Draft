using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager 
{
	public static int sceneCount = 0;
	public static Scene currentScene;
	private static List<Scene> sceneList;

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
	public static Scene CreateScene(string sceneName)
	{
		foreach(Scene scenes in sceneList)
		{
			if(scenes.getSceneName == sceneName)
				return null;
		}

		Scene scene = new Scene (sceneName);

		if(currentScene == null)
			currentScene = scene;

		sceneList.Add (scene);
		sceneCount ++;

		return scene;
	}

	public static void setCurrentSceneChild<T>() where T: Scene, new()
	{
		T scene = new T();

		if(scene != null)
		{
			currentScene = scene;
			sceneList.Add (scene);
		}
	}

	public static void replaceCurrentScene<T>() where T: Scene, new()
	{
		T scene = new T();
		currentScene.disposeScene(); //Destroy gameobject and unload resources
		sceneList.Remove(currentScene);

		if(scene != null)
		{
			currentScene = scene;
			sceneList.Add(scene);
		}
	}

	// Use this for initialization
	protected virtual void initializeScene () 
	{
	
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
