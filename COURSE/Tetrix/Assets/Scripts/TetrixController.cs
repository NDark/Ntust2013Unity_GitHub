using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TetrixController : MonoBehaviour 
{
	public GameObject m_SampleBlock = null ;
	public GameObject m_CurrentBlock = null ;
	
	public List<GameObject> m_QueuedBlocks = new List<GameObject>() ;
	
	void TryMoveLeft()
	{
		
		Vector3 pos = m_CurrentBlock.transform.position ;
		pos.x -= 1 ;
		if( pos.x < 0 )
		{
			pos.x = 0 ;
		}
		m_CurrentBlock.transform.position = pos ;
		
	}
	
	void TryMoveRight()
	{
		
		Vector3 pos = m_CurrentBlock.transform.position ;
		pos.x += 1 ;
		if( pos.x >= MAP_WIDTH )
		{
			pos.x = MAP_WIDTH - 1 ;
		}
		m_CurrentBlock.transform.position = pos ;
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckInput() ;
		
		if( Time.time < m_NextCount )
		{
			return ;
		}
		
		m_NextCount = Time.time + m_CountInterval ;
		
		CheckBlockHasReachTheEnd() ;
		
		CheckRemoveALineOfBlocks() ;
		
		
		UpdateBlockDownward() ;
		
	}
	
	void UpdateBlockDownward()
	{
		if( null == m_CurrentBlock )
		{
			return ;
		}
		
		Vector3 pos = m_CurrentBlock.transform.position ;
		pos.y -= 1 ;
		m_CurrentBlock.transform.position = pos ;
		
		
	}
	
	void CheckBlockHasReachTheEnd()
	{
		if( null == m_CurrentBlock )
		{
			return ;
		}
		
		Vector3 pos = m_CurrentBlock.transform.position ;
		if( this.CanThisBlockGoDown( m_CurrentBlock ) )
		{
			return ;
		}
		
		m_QueuedBlocks.Add( m_CurrentBlock ) ;
		
		m_CurrentBlock = null ;
		
		m_CurrentBlock = GenerateANewBlock() ;
	}
	
	GameObject GenerateANewBlock()
	{
		GameObject ret = null ;
		ret = GameObject.Instantiate( m_SampleBlock ) ;
		var pos = ret.transform.position ;
		pos.y = 5 ;
		ret.transform.position = pos ;
		return ret ;
	}
	
	bool CanThisBlockGoDown( GameObject _TestBlock )
	{
		bool isOccupiedDownward = false ;
		foreach( var obj in m_QueuedBlocks )
		{
			if( _TestBlock == obj )
			{
				continue ;
			}
			
			if( _TestBlock.transform.position.y - 1 == obj.transform.position.y 
			   && _TestBlock.transform.position.x == obj.transform.position.x 
			)
			{
				isOccupiedDownward = true ;
			}
		}
		
		if( isOccupiedDownward )
		{
			return false ;
		}
		
		return ( _TestBlock.transform.position.y > 0 ) ;
		
	}
	
	const int MAP_HEIGHT = 10 ;
	const int MAP_WIDTH = 3 ;
	bool [] tempOccupied = new bool[MAP_WIDTH] ;
	void CheckRemoveALineOfBlocks()
	{
		for( int h = 0 ; h < MAP_HEIGHT ; ++h )
		{
			for( int w = 0 ; w < MAP_WIDTH ; ++w )
			{
				tempOccupied[w] = false ;
			}
			
			foreach( var obj in this.m_QueuedBlocks )
			{
				int x = (int) obj.transform.position.x ;
				if( obj.transform.position.y == h )
				{
					tempOccupied[ x ] = true ;
				}
			}
			
			bool removeLine = true ;
			for( int w = 0 ; w < MAP_WIDTH ; ++w )
			{
				if( false == tempOccupied[ w ] )
				{
					// next line 
					removeLine = false ;
				}
			}
			
			if( true == removeLine )
			{
				RemoveLine( h ) ;
			}
		}
		
		UpdateQueueBlockDownward() ;
		
	}
	
	void RemoveLine( int _Y )
	{
		List<GameObject> removingObjs = new List<GameObject>() ;
		foreach( var obj in this.m_QueuedBlocks )
		{
			if( obj.transform.position.y == _Y )
			{
				removingObjs.Add( obj ) ;
			}
		}
		
		foreach( var obj in removingObjs )
		{
			GameObject.Destroy( obj ) ;
			m_QueuedBlocks.Remove( obj ) ;
		}
		removingObjs.Clear() ;
		
	}

	void CheckInput()
	{
		if( Input.GetKeyDown( KeyCode.LeftArrow ) )
		{
			TryMoveLeft() ;
		}
		
		if( Input.GetKeyDown( KeyCode.RightArrow ) )
		{
			TryMoveRight() ;
		}
	}
	
	void UpdateQueueBlockDownward()
	{
		for( int h = 0 ; h < MAP_HEIGHT ; ++h )
		{
			foreach( var obj in this.m_QueuedBlocks )
			{
				if( obj.transform.position.y != h )
				{
					continue ;
				}
				
				while( CanThisBlockGoDown( obj ) )
				{
					var pos = obj.transform.position ;
					pos.y -= 1 ;
					obj.transform.position = pos ;
					
				}
			}
		}
		
	}
	
	float m_NextCount = 0.0f ;
	float m_CountInterval = 1.0f ;
}
