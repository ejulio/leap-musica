using Leap;
using System;
public static class LeapController
{
	private static Controller instance;

	public static Controller GetInstance() 
	{
		if (instance == null) 
		{
			instance = new Controller ();
		}

		return instance;
	}

	public static Frame GetFrame()
	{
		return GetInstance().Frame();
	}
}