using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager 
{
	protected Manager localParent;
	protected List<Manager> children = new List<Manager>();

	#region gettersetter

	public Manager parent
	{
		get
		{
			return localParent;
		}
	}

    public List<Manager> managerChildren
    {
        get
        {
            return children;
        }
    }

	#endregion // gettersetter

	#region inheritables

	protected virtual void initializeManager(params object[] param)
	{

		//initialize variables etc. param is used to transfer stuff between scenes
	}

	protected virtual bool hasInitializeManager()
	{
		return false;
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
		if(children == null)
		{
			children = new List<Manager>();
		}
		for(int i = 0; i < children.Count; i++)
		{
			if(children != null)
				if(children[i] != null)
					children[i].Update(dt);
		}
	}

	public void Pause()
	{
		pauseManager();
		for(int i = 0; i < children.Count; i++)
		{
			if(children != null)
				if(children[i] != null)
					children[i].Pause();
		}
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
