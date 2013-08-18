using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody) , typeof(AudioSource) ) ]	
public class SpaceshipCS : MonoBehaviour 
{
	public Vector3 forwardDirection = new Vector3 (0.0f, 1.0f, 0.0f);
	
	[System.Serializable]
	public class MovementSettings {
		// What is the maximum speed of this movement?
		public float maxSpeed ;
		
		// What's the acceleration in the positive and negative directions associated with this movement?
		public float positiveAcceleration ;
		public float negativeAcceleration ;
		
		// How much drag should we apply when there isn't input for this movement?
		public float dragWhileCoasting ;
		
		// How much drag should we apply to slow down the movement for speeds above maxSpeed?
		public float dragWhileBeyondMaxSpeed ;
		
		// When neither of the above drag factors are in play, how much drag should there normally be?  (Usually very small.)
		public float dragWhileAcceleratingNormally ;
		
		// This function determines which drag variable to use and returns one.
		public float ComputeDrag ( float input , Vector3 velocity ) 
		{
			//Is the input not zero (the 0.01 allows for some error since we're working with floats and they aren't completely precise)
			if (Mathf.Abs (input) > 0.01f) {
				// Are we greater or less than our max speed? Then return the appropriate drag.
				if (velocity.magnitude > maxSpeed)
					return dragWhileBeyondMaxSpeed;
				else
					return dragWhileAcceleratingNormally;
			} else
				//If the input is zero, use dragWhileCoasting
				return dragWhileCoasting;
		}
	}	
		
	[System.Serializable]
	public class SpecialEffects {
		// There are four possible special effects that can be assigned.
		public GameObject positiveThrustEffect ;
		public GameObject negativeThrustEffect ;
		public GameObject positiveTurnEffect ;
		public GameObject negativeTurnEffect ;
		
		public float collisionVolume = 0.01f;
	}
		
	public MovementSettings positionalMovement = new MovementSettings() ;
	
	public MovementSettings rotationalMovement = new MovementSettings() ;
	
	public SpecialEffects specialEffects = new SpecialEffects() ;

	public bool canControl = true ;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Collecting appropriate input.
		float thrust = Input.GetAxisRaw ("Vertical");
		float turn = Input.GetAxisRaw ("Horizontal");
		
		if (!canControl) {
			thrust = 0.0f;
			turn = 0.0f;
		}
		
		// If the thrust effect slots aren't null in the inspector, send a message.
		// The message will be received by the component SpecialEffectHandler
		// If the boolean statement is true, (e.g. (thrust > 0.01)) then the special effects will be enabled.
		if (specialEffects.positiveThrustEffect)
			specialEffects.positiveThrustEffect.SendMessage ("SetSpecialEffectActive", (thrust > 0.01));
	
		if (specialEffects.negativeThrustEffect)
			specialEffects.negativeThrustEffect.SendMessage ("SetSpecialEffectActive", (thrust < -0.01));
	
		if (specialEffects.positiveTurnEffect)
			specialEffects.positiveTurnEffect.SendMessage ("SetSpecialEffectActive", (turn > 0.01));
	
		if (specialEffects.negativeTurnEffect)
			specialEffects.negativeTurnEffect.SendMessage ("SetSpecialEffectActive", (turn < -0.01));	
	}
	
	
	//FixedUpdate () is advantageous over Update () for working with rigidbody physics.
	void FixedUpdate () 
	{
		// Retrieve input.  Note the use of GetAxisRaw (), which in this case helps responsiveness of the controls.
		// GetAxisRaw () bypasses Unity's builtin control smoothing.
		float thrust = Input.GetAxisRaw ("Vertical");
		float turn = Input.GetAxisRaw ("Horizontal");
		
		if (!canControl) {
			thrust = 0.0f;
			turn = 0.0f;
		}
		
		//Use the MovementSettings class to determine which drag constant should be used for the positional movement.
		//Remember the MovementSettings class is a helper class we defined ourselves. See the top of this script.
		rigidbody.drag = positionalMovement.ComputeDrag (thrust, rigidbody.velocity);
	
		//Then determine which drag constant should be used for the angular movement.
		rigidbody.angularDrag = rotationalMovement.ComputeDrag (turn, rigidbody.angularVelocity);
		
		//Determines which direction the positional and rotational motion is occurring, and then modifies thrust/turn with the given accelerations. 
		//If you are not familiar with the ?: conditional, it is basically shorthand for an "if..else" statement pair.  See http://www.javascriptkit.com/jsref/conditionals.shtml
		thrust *= (thrust > 0.0f) ? positionalMovement.positiveAcceleration : positionalMovement.negativeAcceleration;
		turn *= (turn > 0.0f) ? rotationalMovement.positiveAcceleration : rotationalMovement.negativeAcceleration;
		
		// Add torque and force to the rigidbody.  Torque will rotate the body and force will move it.
		// Always modify your forces by Time.deltaTime in FixedUpdate (), so if you ever need to change your Time.fixedTime setting,
		// your setup won't break.
	 	rigidbody.AddRelativeTorque ( new Vector3 (0.0f, 0.0f, -1.0f) * turn * Time.deltaTime, 
										ForceMode.VelocityChange);
		rigidbody.AddRelativeForce (forwardDirection * thrust * Time.deltaTime, ForceMode.VelocityChange);
	}


	public void SetControllable ( bool controllable )
	{
		canControl = controllable;
	}
		
	void OnCollisionEnter ( Collision collision ) 
	{
		CollisionSoundEffectCS collisionSoundEffect = collision.gameObject.GetComponent<CollisionSoundEffectCS>() ;
	
		// If collisionSoundEffect isn't null, get the audio clip, set the volume, and play.
		if (collisionSoundEffect) {
			audio.clip = collisionSoundEffect.audioClip;
			// By multiplying by collision.relativeVelocity.sqrMagnitude, the sound will be louder for faster impacts.
			audio.volume = collisionSoundEffect.volumeModifier * collision.relativeVelocity.sqrMagnitude * specialEffects.collisionVolume;
			audio.Play ();		
		}
	}	
	
	public void Reset () 
	{
		// Set some nice default values for our MovementSettings.
		// Of course, it is always best to tweak these for your specific game.
		positionalMovement.maxSpeed = 3.0f;
		positionalMovement.dragWhileCoasting = 3.0f;
		positionalMovement.dragWhileBeyondMaxSpeed = 4.0f;
		positionalMovement.dragWhileAcceleratingNormally = 0.01f;
		positionalMovement.positiveAcceleration = 50.0f;
		
		// By default, we don't have reverse thrusters.
		positionalMovement.negativeAcceleration = 0.0f;
		
		rotationalMovement.maxSpeed = 2.0f;
		rotationalMovement.dragWhileCoasting = 32.0f;
		rotationalMovement.dragWhileBeyondMaxSpeed = 16.0f;
		rotationalMovement.dragWhileAcceleratingNormally = 0.1f;
	
		// For rotation, acceleration is usually the same in both directions.
		// It could make for interesting unique gameplay if it were significantly
		// different, however!
		rotationalMovement.positiveAcceleration = 50.0f;
		rotationalMovement.negativeAcceleration = 50.0f;
	}	
}
