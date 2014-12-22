using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		var scale = gameObject.transform.localScale;
		var pivot = new Vector3(0, 0, scale.z * 0.5f);
		var collisionPosition = collision.collider.transform.position;
		gameObject.transform.RotateAround(pivot, Vector3.left, 5);
	}

	void OnCollisionExit(Collision collision)
	{
		var scale = gameObject.transform.localScale;
		var pivot = new Vector3(0, 0, scale.z * 0.5f);
		var collisionPosition = collision.collider.transform.position;
		gameObject.transform.RotateAround(pivot, Vector3.left, -5);
	}
}
