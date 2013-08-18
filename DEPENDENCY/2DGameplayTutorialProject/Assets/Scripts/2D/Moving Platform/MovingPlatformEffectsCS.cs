using UnityEngine;
using System.Collections;


[AddComponentMenu("2D Platformer/Moving Platform/Moving Platform Effects")]
public class MovingPlatformEffectsCS : MonoBehaviour 
{
	public float horizontalSpeedToEnableEmitters = 1.0f ;

	private bool areEmittersOn = false ;

	private Vector3 oldPosition = Vector3.zero ;
	private Vector3 currentVelocity = Vector3.zero ;
		
	// Use this for initialization
	void Start () 
	{
		oldPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool wereEmittersOn = areEmittersOn;
		
		areEmittersOn = (currentVelocity.y > 0) || 
						(Mathf.Abs(currentVelocity.x) > horizontalSpeedToEnableEmitters);
		
		if (wereEmittersOn != areEmittersOn) 
		{
			foreach( ParticleEmitter emitter in GetComponentsInChildren<ParticleEmitter>() ) 
			{
				emitter.emit = areEmittersOn ;
			}
		}		
	}
	

	void LateUpdate () 
	{
		currentVelocity = transform.position - oldPosition;
		oldPosition = transform.position;
	}	
		
}
