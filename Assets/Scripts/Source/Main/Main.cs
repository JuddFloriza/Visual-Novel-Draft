using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour 
{
	//Singleton Method
	private static Main s_instance
	{
		get
		{
			return s_instance;
		}
		set
		{
			s_instance = this;
		}
	}

	// Use this for initialization
	private void Start () 
	{
	
	}

	// Update is called once per frame
	private void Update () 
	{
	
	}
}
