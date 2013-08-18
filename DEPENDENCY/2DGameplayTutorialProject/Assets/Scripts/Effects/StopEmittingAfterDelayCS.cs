using UnityEngine;
using System.Collections;

public class StopEmittingAfterDelayCS : MonoBehaviour {
	

	public float delay = 0.1f;	// The pause to take. 

	
	
	// Use this for initialization
	void Start () 
	{
		Example() ;
		particleEmitter.emit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
    IEnumerator Example() {
        yield return new WaitForSeconds(delay);
    }
}
