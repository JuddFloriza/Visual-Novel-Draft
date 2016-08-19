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

    #region setfirstscene

    private void setFirstScene()
    {
        SceneManager.replaceCurrentScene<GameScene>();
    }

    #endregion // setfirstscene


    //Reference Variables
    private Manager mainManager = null;

	private void initializeMain()
	{
		mainManager = new Manager();
		CreateManager<Manager>(mainManager);
        CreateManager<SceneManager>(mainManager);
	}

	private void hasInitializeMain()
	{

	}

	// Use this for initialization
	private void Start () 
	{
		initializeMain();
        setFirstScene();
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
