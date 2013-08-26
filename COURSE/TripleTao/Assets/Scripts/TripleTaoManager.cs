/*
@file TripleTaoManager.cs
@author NDark
@date 20130826 file started.
*/
using UnityEngine;
using System.Collections.Generic;

public class TripleTaoManager : MonoBehaviour 
{
	Dictionary<int,GameObject> m_Units = new Dictionary<int, GameObject>() ;
	public GameObject m_HoldUnit = null ;
	public float m_HoldHeight = 1; 
	// Use this for initialization
	void Start () 
	{
		m_HoldUnit = GenerateAUnit() ;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_HoldUnit )
		{
			Vector3 worldPos = Camera.mainCamera.ScreenToWorldPoint( Input.mousePosition ) ;
			worldPos.y = m_HoldHeight ;
			m_HoldUnit.transform.position = worldPos ;
		}
	}
	
	private GameObject GenerateAUnit()
	{
		GameObject ret = null ;
		Object prefab = Resources.Load( "UnitBush" ) ;
		if( null == prefab )
		{
			Debug.LogError( prefab ) ;
		}
		else
		{
			ret = (GameObject)GameObject.Instantiate( prefab ) ;
			
		}
		
		return ret ;
	}
}
