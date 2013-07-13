/*
 * @file FindAverageFromObjects02.cs
 * @author NDark
 * @date 20130712 . file started.
 */
using UnityEngine;
using System.Collections;

public class FindAverageFromObjects02 : MonoBehaviour 
{
	GameObject m_BallParent = null ;
	
	GameObject [] m_Balls = null ;
	// Use this for initialization
	void Start () 
	{
		InitializedBallParent() ;
		InitializedBalls() ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_Balls )
			return ;
		
		int count = 0 ;
		Vector3 sumPos = Vector3.zero ;
		for( int i = 0 ; i < m_Balls.Length ; ++i )
		{
			if( null != m_Balls[ i ] )
			{
				sumPos += m_Balls[ i ].transform.position ;
				++count ;
			}
		}
		
		// average from sum of positions
		this.transform.position = ( sumPos / count ) ;
	}
	
	private void InitializedBallParent()
	{
		m_BallParent = GameObject.Find( "BallParent" ) ;
		if( null == m_BallParent )
		{
			Debug.LogError( "FindAverageFromObjects02::InitializedBallParent() null == m_BallParent" ) ;
		}
		else
		{
			Debug.Log( "FindAverageFromObjects02::InitializedBallParent() end." ) ;
		}
	}	
	
	private void InitializedBalls()
	{
		if( null == m_BallParent )
			return ;
		
		// use m_BallParent to find its children Ball0 to Ball9, if they exist
		Transform trans = null ;
		m_Balls = new GameObject[10] ;
		for( int i = 0 ; i < m_Balls.Length ; ++i )
		{
			trans = m_BallParent.transform.FindChild( "Ball" + i.ToString() ) ;
			if( null != trans )
			{
				m_Balls[ i ] = trans.gameObject ;
			}
			else
			{
				m_Balls[ i ] = null ;
			}
		}
	}
}
