/**
@file AlienAIController01.cs
@author NDark
@date 20130820 . file started.
*/
using UnityEngine;
using System.Collections;

public class AlienAIController01 : MonoBehaviour 
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
		Vector3 mainCharacterForward = m_MainCharacter.transform.forward ;
		Vector3 toMainCharacter = m_MainCharacter.transform.position - this.gameObject.transform.position ;
		
		FollowTheMainCharacter03 script = this.gameObject.GetComponent<FollowTheMainCharacter03>() ;
		
		float angle = Vector3.Angle( mainCharacterForward , toMainCharacter ) ;
		if( angle > 90 )
		{
			if( null == script )
			{
				script = this.gameObject.AddComponent<FollowTheMainCharacter03>() ;
				script.m_MainCharacter = this.m_MainCharacter ;
			}
			script.enabled = true ;
		}
		else
		{
			if( null != script )
				script.enabled = false ;
		}
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
