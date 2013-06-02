/**
 * @file CameraFieldManager02.cs
 * @author NDark
 * @date 20130602 . file started.
 */
using UnityEngine;
using System.Collections;

public class CameraFieldManager02 : MonoBehaviour 
{
	GameObject[] m_LiftFieldObjects = null ;
	GameObject[] m_CameraPositionObjects = null ;
	
	public Vector3 GetLightFieldVec( Vector3 _TestPosition )
	{
		Vector3 distVec = Vector3.zero ;
		Vector3 ret = Vector3.zero ;
		float minSqrMagnitude = 9999999.999999f ;
		for( int i = 0 ; i < m_LiftFieldObjects.Length ; ++i )
		{
			distVec = m_LiftFieldObjects[ i ].transform.position - _TestPosition ;
			if( distVec.sqrMagnitude < minSqrMagnitude )
			{
				ret = m_LiftFieldObjects[ i ].transform.forward ;
				minSqrMagnitude = distVec.sqrMagnitude ;
			}
		}
		return ret ;
	}
	
	public GameObject GetLightFieldPoseGameObject( Vector3 _TestPosition )
	{
		Vector3 distVec = Vector3.zero ;
		GameObject ret = null ;
		float minSqrMagnitude = 9999999.999999f ;
		for( int i = 0 ; i < m_LiftFieldObjects.Length ; ++i )
		{
			distVec = m_LiftFieldObjects[ i ].transform.position - _TestPosition ;
			if( distVec.sqrMagnitude < minSqrMagnitude )
			{
				ret = m_CameraPositionObjects[ i ] ;
				minSqrMagnitude = distVec.sqrMagnitude ;
			}
		}
		return ret ;
	}
	
	// Use this for initialization
	void Start () 
	{
		if( null == m_LiftFieldObjects )
			InitilaizeCameraFieldObjects() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void InitilaizeCameraFieldObjects()
	{
		m_LiftFieldObjects = new GameObject[2] ;
		m_LiftFieldObjects[ 0 ] = GameObject.Find( "CameraFieldProbe0" ) ;
		m_LiftFieldObjects[ 1 ] = GameObject.Find( "CameraFieldProbe1" ) ;		
		
		m_CameraPositionObjects = new GameObject[2] ;
		m_CameraPositionObjects[ 0 ] = GameObject.Find( "CameraFieldPosition0" ) ;
		m_CameraPositionObjects[ 1 ] = GameObject.Find( "CameraFieldPosition1" ) ;				
	}
	
}
