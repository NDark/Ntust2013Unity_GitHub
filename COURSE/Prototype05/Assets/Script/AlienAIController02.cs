/**
@file AlienAIController02.cs
@author NDark
@date 20130820 . file started.
*/
using UnityEngine;

public class AlienAIController02 : MonoBehaviour 
{
	
	public GameObject m_MainCharacter = null ;

	// Use this for initialization
	void Start () 
	{
		if( null == m_MainCharacter )
		{
			InitializeMainCharacterObjectPtr() ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		AllienMovement02 movementScript = this.gameObject.GetComponent<AllienMovement02>() ;
		if( null != movementScript )
		{
			movementScript.enabled = false ;
		}
		
		FollowTheMainCharacter03 followScript = this.gameObject.GetComponent<FollowTheMainCharacter03>() ;
		if( null == followScript )
		{
			followScript = this.gameObject.AddComponent<FollowTheMainCharacter03>() ;
			followScript.m_MainCharacter = this.m_MainCharacter ;
		}
		
		Component.Destroy( this ) ;
	}

	private void InitializeMainCharacterObjectPtr()
	{
		m_MainCharacter = GameObject.FindGameObjectWithTag( "Player" ) ;
		
		if( null == m_MainCharacter )
		{
			Debug.LogError( "FollowTheMainCharacter03:InitializeMainCharacterObjectPtr() null == m_MainCharacter" ) ;
		}
		else
		{
			Debug.Log( "FollowTheMainCharacter03:InitializeMainCharacterObjectPtr() end." ) ;
		}
	}
}
