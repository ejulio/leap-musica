using UnityEngine;
using System.Collections;
using Leap;

public class KeyboardController : MonoBehaviour {

	const float HandKeyboardYDistance = 0.070f;
	const float HandKeyboardZDistance = 0.15f;
	const float HandMaxY = 0.4f;
	const float KeyboardMaxZ = 0.05f;
	const float KeyboardMinZ = 0.02f;

	Controller controller;
	Frame currentFrame;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentFrame = LeapController.GetFrame();
		gameObject.transform.localPosition = CalculatePositionBasedOnHands();
		UpdateScale();
	}

	private void UpdateScale()
	{
		float iterationPoint = currentFrame.Hands[0].PalmPosition.ToUnityScaled().y / HandMaxY;
		float zScale = KeyboardMinZ + (KeyboardMaxZ - KeyboardMinZ) * iterationPoint;
		Vector3 scale = new Vector3 (gameObject.transform.localScale.x, gameObject.transform.localScale.y, zScale);
		gameObject.transform.localScale = scale;
	}

	Vector3 CalculatePositionBasedOnHands()
	{
		if (currentFrame.Hands.Count == 1)
			return CalculateVectorForHand();

		return CalculateVectorBetweenHands();
	}

	Vector3 CalculateVectorForHand()
	{
		var handPosition = currentFrame.Hands[0].PalmPosition.ToUnityScaled();
		handPosition.x = gameObject.transform.localPosition.x;
		handPosition.y -= HandKeyboardYDistance;
		handPosition.z += HandKeyboardZDistance;
		return handPosition;
	}

	Vector3 CalculateVectorBetweenHands()
	{
		var leftHandPosition = currentFrame.Hands.Leftmost.PalmPosition.ToUnityScaled();
		var rightHandPosition = currentFrame.Hands.Rightmost.PalmPosition.ToUnityScaled();
		var vectorBetweenHands = Vector3.Lerp(leftHandPosition, rightHandPosition, 0.5f);

		vectorBetweenHands.x = 0;
		vectorBetweenHands.y -= HandKeyboardYDistance;
		vectorBetweenHands.z += HandKeyboardZDistance;

		return vectorBetweenHands;
	}
}
