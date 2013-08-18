using UnityEngine;
using System.Collections;

public class DeathTriggerCS : MonoBehaviour 
{
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter( Collider other )
	{
		other.gameObject.SendMessage ("OnDeath", SendMessageOptions.DontRequireReceiver);
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawIcon (transform.position, "Skull And Crossbones Icon.tif");
	}
	
}
