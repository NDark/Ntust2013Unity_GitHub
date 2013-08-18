using UnityEngine;
using System.Collections;

public class PlatformerPushBodiesCS : MonoBehaviour {
	
		// How hard the player can push
	public float pushPower = 0.5f ;
	
	// Which layers the player can push
	// This is useful to make unpushable rigidbodies
	public LayerMask pushLayers = -1;
	
	// pointer to the player so we can get values from it quickly
	private PlatformerControllerCS controller = null ;
	
		
	// Use this for initialization
	void Start () {
		controller = GetComponent<PlatformerControllerCS>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnControllerColliderHit ( ControllerColliderHit hit ) 
	{
		Rigidbody body = hit.collider.attachedRigidbody ;
		
		// no rigidbody
		if (body == null || body.isKinematic)
			return;
	
		// Only push rigidbodies in the right layers
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0)
			return;
			
		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) 
			return;
		
		// Calculate push direction from move direction, we only push objects to the sides
		// never up and down
		Vector3 pushDir = new Vector3 (hit.moveDirection.x, 0, hit.moveDirection.z);
		
		// push with move speed but never more than walkspeed
		body.velocity = pushDir * pushPower * Mathf.Min (controller.GetSpeed (), controller.movement.walkSpeed);
	}
	
}
