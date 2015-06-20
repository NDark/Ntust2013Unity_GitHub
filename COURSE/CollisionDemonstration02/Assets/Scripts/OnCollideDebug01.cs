using UnityEngine;
using System.Collections;

public class OnCollideDebug01 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter( Collider other )
	{
		Debug.Log( "OnTriggerEnter() " + other.name + " enter." ) ;
	}
	
	void OnTriggerStay( Collider other )
	{
		Debug.Log( "OnTriggerStay() " + other.name + " enter." ) ;
	}
	
	void OnTriggerExit( Collider other )
	{
		Debug.Log( "OnTriggerExit() " + other.name + " enter." ) ;
	}
	
	void OnCollisionEnter( Collision other )
	{
		Debug.Log( "OnCollisionEnter() " + other.gameObject.name + " enter." ) ;
	}
	
	void OnCollisionStay( Collision other )
	{
		Debug.Log( "OnCollisionStay() " + other.gameObject.name + " stay." ) ;
	}
	
	void OnCollisionExit( Collision other )
	{
		Debug.Log( "OnCollisionExit() " + other.gameObject.name + " exit." ) ;
	}

}







