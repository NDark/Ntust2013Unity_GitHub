using UnityEngine;
using System.Collections;

public class CameraTargetAttributesCS : MonoBehaviour 
{
	/*
	 * Camera Height from target
	 */
	public float heightOffset = 0.0f ; 

	/*
	 * Camera distance from target
	 */	
	public float distanceModifier = 1.0f ;
	
	/*
	 * when target has velocity , how long (ratio) distance we should look ahead 
	 */	
	public float velocityLookAhead = 0.15f ;
	
	/*
	 * limit of velocityLookAhead
	 */		
	public Vector2 maxLookAhead = new Vector2 (3.0f, 3.0f);	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
