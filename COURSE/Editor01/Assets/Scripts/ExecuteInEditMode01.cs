/**
@file ExecuteInEditMode01.cs
@author NDark
@date 20130819 . file started and derived from LookAtBall01
*/
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ExecuteInEditMode01 : MonoBehaviour 
{
	public Transform m_BallTransform = null ;
	
	// Use this for initialization
	void Start () 
	{
		if( null == m_BallTransform )
		{
			InitializeBall() ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_BallTransform )
			return ;
	
		this.gameObject.transform.LookAt( m_BallTransform ) ;
	}
	
	private void InitializeBall()
	{
		GameObject obj = GameObject.Find( "Ball" ) ;
		if( null == obj )
		{
			Debug.LogError( "ExecuteInEditMode01::InitializeBall() null == m_Ball" ) ;
		}
		else
		{
			m_BallTransform  = obj.transform ;
			Debug.Log( "ExecuteInEditMode01::InitializeBall() end." ) ;
		}		
	}
	
}
