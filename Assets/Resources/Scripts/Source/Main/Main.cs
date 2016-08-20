using UnityEngine;
using UnityEditor;
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

    #region globals

    private static Vector3 scale;
    //private static float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;

    //public static Vector3 localScale
    //{
    //    get
    //    {
    //        return new Vector3(width / 9.0f, width / 9.0f, width / 9.0f); ;
    //    }
    //}


    #endregion // globals

    #region setfirstscene

    private void setFirstScene()
    {
        SceneManager.replaceCurrentScene<StartScene>();
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
        mainManager.Update(Time.deltaTime);
	}

	#region methods

	public static T CreateManager<T>(Manager parent) where T: Manager, new()
	{
		if(parent == null)
			return null;

		T manager = new T();

		manager.Initialize();
		manager.setParent(parent);
        parent.managerChildren.Add(manager);

		return manager;
	}

	#endregion // methods
}
