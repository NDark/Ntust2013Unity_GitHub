using UnityEngine;
using System.Collections;

public class OnCollideSuicide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter( Collider other )
	{
		// Debug.Log( other.gameObject.name ) ;
		if( -1 != other.gameObject.name.IndexOf( "Alien" ) )
		{
			GameObject.Destroy( this.gameObject ) ;
		}
	}
	
}
