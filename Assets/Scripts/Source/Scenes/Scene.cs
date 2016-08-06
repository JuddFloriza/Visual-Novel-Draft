﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene: Manager
{
	private string sceneName;
	private GameObject sceneObject;
	private Transform transform;

	public Scene()
	{
		createObject(this);
	}

	public Scene(string sceneName)
	{
		this.sceneName = sceneName;
		createObject(this);
	}

	public string getSceneName
	{
		get
		{
			return sceneName;
		}
	}

	public Transform getTransform
	{
		get
		{
			return transform;
		}
	}

	public void createObject(Scene child)
	{
		GameObject obj = null;
		if(child != null && sceneName != null)
		{
			obj = new GameObject(sceneName);
		}
		else if(child != null)
		{
			obj = new GameObject(child.ToString());
		}
		
		sceneObject = GameObject.Instantiate(obj);
		transform = sceneObject.transform;
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
