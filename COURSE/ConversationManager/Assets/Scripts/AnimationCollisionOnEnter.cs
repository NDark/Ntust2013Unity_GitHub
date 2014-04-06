/**
 * @file AnimationCollisionOnEnter.cs
 * @author NDark
 * @date 20140406 file started.
 */
using UnityEngine;
using System.Collections;

public class AnimationCollisionOnEnter : MonoBehaviour 
{
	public string m_ParentName = "" ;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		// Debug.Log( "other" + other.name  ) ;
		if( other.name != m_ParentName )
		{
			GameObject.Destroy(this.gameObject);
		}

	}
}
