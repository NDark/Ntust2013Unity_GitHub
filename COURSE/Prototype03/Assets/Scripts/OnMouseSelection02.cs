/*
@file OnMouseSelection02.cs
@author NDark
@date 20130804 file started.
*/
using UnityEngine;

public class OnMouseSelection02 : MonoBehaviour 
{
	static SelectionSystem02 m_SelectSystem = null ;

	// Use this for initialization
	void Start () 
	{	
		if( null == m_SelectSystem )
		{
			GameObject singleton = GameObject.Find( "GlobalSingleton" ) ;
			m_SelectSystem = singleton.GetComponent<SelectionSystem02>() ;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		if( null == m_SelectSystem )
			return ;
		
		if( m_SelectSystem.m_SelectObject == this.gameObject )
		{
			m_SelectSystem.Select( false , null ) ;
		}
		else
		{
			m_SelectSystem.Select( true , this.gameObject ) ;
		}
	}

	
	void OnMouseEnter()
	{
		if( null == m_SelectSystem )
			return ;
		m_SelectSystem.ShowCursor( true ) ;
	}

	void OnMouseExit()
	{
		if( null == m_SelectSystem )
			return ;
		m_SelectSystem.ShowCursor( false ) ;
	}	
}
