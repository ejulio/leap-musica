using UnityEngine;
using System.Collections;
using Leap;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

public class SceneController : MonoBehaviour {

	const int MaximumYDiference = 50;

	public GameObject keyboard;
	Frame currentFrame;

	// Use this for initialization
	void Start () 
	{
		keyboard.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentFrame = LeapController.GetFrame ();
		keyboard.SetActive (ShowKeyboard());
	}

	bool ShowKeyboard()
	{
		var handCount = currentFrame.Hands.Count;
		if (handCount == 0) 
		{
			return false;
		} 
		else if (handCount == 1) 
		{
			return true;
		}
		
		return HandsAreParallelInY();
	}
	
	bool HandsAreParallelInY()
	{
		var position1 = currentFrame.Hands[0].PalmPosition;
		var position2 = currentFrame.Hands[1].PalmPosition;
		
		var yDistance = Mathf.Abs(position1.y - position2.y);
		
		return yDistance < MaximumYDiference;
	}
}
