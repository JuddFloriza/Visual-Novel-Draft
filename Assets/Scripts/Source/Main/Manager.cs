using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager 
{
	protected Manager localParent;
	protected List<Manager> children;

	#region gettersetter

	public Manager parent
	{
		get
		{
			return localParent;
		}
	}

	#endregion // gettersetter

	#region inheritables

	protected virtual void initializeManager(params object[] param)
	{

		//initialize variables etc. param is used to transfer stuff between scenes
	}

	protected virtual void hasInitializeManager(bool hasInitialized)
	{
		//flag if initialization is done
	}

	protected virtual void updateManager(float dt)
	{
		//do real time processes here
	}

	protected virtual void pauseManager()
	{
		//pause the scene (stop update, turn off running processes.)
	}

	protected virtual void unpauseManager()
	{
		//unpause the scene (run processes, reload objects)
	}

	protected virtual void disposeManager()
	{
		//unload objects, destroy shit
	}

	#endregion // inheritables

	#region private methods

	public void Initialize(params object[] param)
	{
		initializeManager(param);
	}

	public void Update(float dt)
	{
		updateManager(dt);
	}

	public void Pause()
	{
		pauseManager();
	}

	public void Unpause()
	{
		unpauseManager();
	}

	public void Dispose()
	{
		disposeManager();
	}
	#endregion // private methods

	#region methods

	public void setParent(Manager parent)
	{
		this.localParent = parent;
	}

	#endregion // methods
}
