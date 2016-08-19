using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene: Manager
{
	private string sceneName = null;
	private GameObject sceneObject;
	private Transform transform;

	#region constructors

	public Scene()
	{
	    createObject(this);
        sceneName = this.ToString();
	}

	#endregion // constructors

	#region getters

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

	#endregion // getters

	#region methods

	public void createObject(Scene child)
	{
		GameObject obj = null;
		if(child != null && sceneName != null)
		{
			obj = new GameObject(sceneName);
            sceneObject = obj;
        }
		else if(child != null)
		{
			obj = new GameObject(child.ToString());
            sceneObject = obj;
		}
		
		//sceneObject = GameObject.Instantiate(obj);
		transform = sceneObject.transform;
	}

	#endregion // methods

	private bool hasInitializedScene = false;

	#region virtual methods
	// Use this for initialization
	public virtual void initializeScene (params object[] param) 
	{
        
    }

	public virtual bool hasInitializeScene ()
	{
		return hasInitializedScene;
	}

	// Update is called once per frame
	protected virtual void updateScene () 
	{

	}

	protected virtual void pauseScene () 
	{
		
	}

	protected virtual void unpauseScene () 
	{
		
	}

	protected virtual void disposeScene ()
	{

	}

	#endregion // virtual methods

	#region inherited methods

	protected sealed override void initializeManager (params object[] param)
	{
        initializeScene();
	}

	protected sealed override bool hasInitializeManager ()
	{
		return hasInitializedScene;
	}

	protected override void updateManager (float dt)
	{

	}

	protected override void pauseManager ()
	{

	}

	protected override void unpauseManager ()
	{

	}

	protected override void disposeManager ()
	{

	}

	#endregion // inherited methods
}
