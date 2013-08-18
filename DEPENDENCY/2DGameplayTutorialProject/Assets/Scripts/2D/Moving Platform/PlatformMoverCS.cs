using UnityEngine;
using System.Collections;

public class PlatformMoverCS : MonoBehaviour 
{
	public GameObject targetA = null;
	public GameObject targetB = null;

	public float speed = 0.1f ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () 
	{
		float weight = Mathf.Cos(Time.time * speed * 2 * Mathf.PI) * 0.5f + 0.5f;
		transform.position = targetA.transform.position * weight
							+ targetB.transform.position * (1-weight);
	}	
}
