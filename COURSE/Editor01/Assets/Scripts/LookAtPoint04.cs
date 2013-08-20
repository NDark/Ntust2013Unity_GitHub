/**
@file LookAtPoint04.cs
@author NDark
@date 20130820 . file started and derived from LookAtBall01
*/
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LookAtPoint04 : MonoBehaviour 
{
	public Vector3 m_TargetPosition = Vector3.zero ;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
		this.gameObject.transform.LookAt( m_TargetPosition ) ;
	}
	
	
}
