/*
 * @file RotateAroundGlobalX.cs
 * @author NDark
 * 
 * Demonstration of transform.Rotate()
 * 
 * @date 20130712 . file started.
 */
using UnityEngine;
using System.Collections;

public class RotateAroundGlobalX : MonoBehaviour 
{
	Vector3 m_Right = new Vector3( 1 , 0 , 0 ) ;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate( m_Right , 
							   1 , 
							   Space.World ) ;
	}
}
 