/**
@file AlienAIController03.cs
@author NDark
@date 20130823 . file started.
*/
using UnityEngine;

public class AlienAIController03 : MonoBehaviour 
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
		

		
		int randomValue = Random.Range( 0 , 2 ) ;
		Debug.Log( randomValue ) ;
		switch ( randomValue )
		{
		case 0 :
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
			}
			break ;
		case 1 :
			{
				FireOneBullet01 fireScript = this.gameObject.GetComponent<FireOneBullet01>() ;
				if( null == fireScript )
				{
					fireScript = this.gameObject.AddComponent<FireOneBullet01>() ;				
				}			
			}
			break ;
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


