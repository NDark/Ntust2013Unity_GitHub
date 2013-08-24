/**
@file AlienAIController01.cs
@author NDark
@date 20130820 . file started.
*/
using UnityEngine;

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
		Vector3 mainCharacterForward = 
			m_MainCharacter.transform.forward ;
		
		Vector3 toMainCharacter = 
			m_MainCharacter.transform.position - this.gameObject.transform.position ;
		
		AlienAIController01 script = this.gameObject.GetComponent<AlienAIController01>() ;
		
		float angle = Vector3.Angle( mainCharacterForward , toMainCharacter ) ;
		if( angle < 90 )
		{
			if( null == script )
			{
				script = this.gameObject.AddComponent<AlienAIController01>() ;
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
			Debug.LogError( "AlienAIController01:InitializeMainCharacterObjectPtr() null == m_MainCharacter" ) ;
		}
		else
		{
			Debug.Log( "AlienAIController01:InitializeMainCharacterObjectPtr() end." ) ;
		}
	}
}
