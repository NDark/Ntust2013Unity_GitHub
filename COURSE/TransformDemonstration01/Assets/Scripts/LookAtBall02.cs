/**
 * @file LookAtBall02.cs
 * @author NDark
 * 
 * Demonstration of Quaternion.LookRotation()
 * 
 * @date 20130712 . file started.
 */
using UnityEngine;
using System.Collections;

public class LookAtBall02 : MonoBehaviour 
{
	GameObject m_Ball = null ;
	// Use this for initialization
	void Start () 
	{
		if( null == m_Ball )
		{
			InitializeBall() ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_Ball )
			return ;
		
		Vector3 toBall = m_Ball.transform.position - this.gameObject.transform.position ;
		
		// set rotation from a vector
		this.gameObject.transform.rotation = Quaternion.LookRotation( toBall ) ;
	}
	
	private void InitializeBall()
	{
		m_Ball = GameObject.Find( "Ball" ) ;
		if( null == m_Ball )
		{
			Debug.LogError( "LookAtBall02::InitializeBall() null == m_Ball" ) ;
		}
		else
		{
			Debug.Log( "LookAtBall02::InitializeBall() end." ) ;
		}		
	}
}
