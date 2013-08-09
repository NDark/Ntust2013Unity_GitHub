using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
	public GameObject targetObj = null ;
	// Use this for initialization
	void Start () 
	{
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<NavMeshAgent>().SetDestination( targetObj.transform.position ) ;
	
	}
}
