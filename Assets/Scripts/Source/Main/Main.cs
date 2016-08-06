using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
	//Singleton Method
	private static Main s_instance;
	private void Awake()
	{
		s_instance = this;
	}
	private static Main instance
	{
		get
		{
			return s_instance;
		}
	}


	//Reference Variables
	private bool hasInitialized = false;
	private Manager mainManager = null;

	private void initializeMain()
	{
		mainManager = new Manager();
		CreateManager<Manager>(mainManager);
	}

	private void hasInitializeMain()
	{

	}

	// Use this for initialization
	private void Start () 
	{
		initializeMain();
	}

	// Update is called once per frame
	private void Update () 
	{
	
	}

	#region methods

	public static T CreateManager<T>(Manager parent) where T: Manager, new()
	{
		if(parent == null)
			return null;

		T manager = new T();

		manager.Initialize();
		manager.setParent(parent);

		return manager;
	}

	#endregion // methods
}
