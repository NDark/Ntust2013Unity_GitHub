using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TetrixController : MonoBehaviour 
{
	const int INIT_HEIGHT = 25 ;
	const int MAP_HEIGHT = 20 ;
	const int MAP_WIDTH = 4 ;

	public GameObject m_SampleBlock = null ;
	public List<GameObject> m_CurrentBlock = new List<GameObject>() ;
	
	public List<GameObject> m_QueuedBlocks = new List<GameObject>() ;

	bool IsValidPositionX( float x )
	{
		if (x < 0 || x >= MAP_WIDTH) 
		{
			return false;
		}

		return true;
	}

	void TryMoveLeft()
	{
		foreach( var obj in m_CurrentBlock )
		{
			Vector3 pos = obj.transform.position ;
			if( pos.x - 1 < 0 )
			{
				return;
			}
		}

		if (false == CanThisBlockGoLeft (m_CurrentBlock)) 
		{
			return;
		}

		foreach( var obj in m_CurrentBlock )
		{
			Vector3 pos = obj.transform.position ;
			pos.x -= 1 ;
			obj.transform.position = pos ;
		}
		
	}
	
	void TryMoveRight()
	{
		bool allowtoMove = true ;
		foreach( var obj in m_CurrentBlock )
		{
			Vector3 pos = obj.transform.position ;
			if( pos.x + 1 >= MAP_WIDTH )
			{
				return;
			}
		}

		if (false == CanThisBlockGoRight (m_CurrentBlock)) 
		{
			return;
		}
		
		foreach( var obj in m_CurrentBlock )
		{
			Vector3 pos = obj.transform.position ;
			pos.x += 1 ;
			obj.transform.position = pos ;
		}
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( true  == m_IsGameOver )
		{
			return ;
		}

		CheckInput() ;
		
		if( Time.time < m_NextCount )
		{
			return ;
		}
		
		m_NextCount = Time.time + m_CountInterval ;
		
		CheckBlockHasReachTheEnd() ;
		
		CheckRemoveALineOfBlocks() ;
		
		
		UpdateBlockDownward() ;

		CheckBlockHasReachTheTop() ;


	}
	
	void UpdateBlockDownward()
	{
		if( null == m_CurrentBlock 
		   || m_CurrentBlock.Count <= 0 )
		{
			return ;
		}

		foreach( var obj in m_CurrentBlock )
		{
			Vector3 pos = obj.transform.position ;
			pos.y -= 1 ;
			obj.transform.position = pos ;
		}

		
	}
	
	void CheckBlockHasReachTheEnd()
	{
		if( null == m_CurrentBlock || m_CurrentBlock.Count <= 0 )
		{
			m_CurrentBlock = GenerateANewBlock() ;

			return ;
		}
		
		if( this.CanThisBlockGoDown( m_CurrentBlock ) )
		{
			return ;
		}
		
		foreach( var obj in m_CurrentBlock )
		{
			m_QueuedBlocks.Add( obj ) ;
		}
		
		m_CurrentBlock.Clear() ;
		
		m_CurrentBlock = GenerateANewBlock() ;

	}
	
	List<GameObject> GenerateANewBlock()
	{
		List<GameObject> ret = null ;

		int random = Random.Range( 0 , 3 ) ;
		switch( random )
		{
		case 0 : ret = GenerateStraightLBlocks() ; break;
		case 1 : ret = GenerateStraightLBlocks() ; break;
		case 2 : ret = GenerateStraightLBlocks() ; break;
		}
		return ret ;
	}

	List<GameObject> Generate1x1Blocks()
	{
		List<GameObject> ret = new List<GameObject>() ;
		var obj = GameObject.Instantiate( m_SampleBlock ) ;
		var pos = obj.transform.position ;
		pos.y = 5 ;
		obj.transform.position = pos ;
		ret.Add( obj ) ;
		return ret ;
	}

	List<GameObject> GenerateStraightLBlocks()
	{
		List<GameObject> ret = new List<GameObject>() ;

		var firstObj = GameObject.Instantiate( m_SampleBlock ) ;
		var firstPos = firstObj.transform.position ;
		firstPos.y = INIT_HEIGHT ;
		firstObj.transform.position = firstPos ;
		ret.Add( firstObj ) ;

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 2 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 2 ;
			pos.x += 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		return ret ;
	}

	List<GameObject> GenerateStraight2x2Blocks()
	{
		List<GameObject> ret = new List<GameObject>() ;

		var firstObj = GameObject.Instantiate( m_SampleBlock ) ;
		var firstPos = firstObj.transform.position ;
		firstPos.y = INIT_HEIGHT ;
		firstObj.transform.position = firstPos ;
		ret.Add( firstObj ) ;

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.x += 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 1 ;
			pos.x += 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		return ret ;
	}

	List<GameObject> GenerateStraight4Blocks()
	{
		List<GameObject> ret = new List<GameObject>() ;

		var firstObj = GameObject.Instantiate( m_SampleBlock ) ;
		var firstPos = firstObj.transform.position ;
		firstPos.y = INIT_HEIGHT ;
		firstObj.transform.position = firstPos ;
		ret.Add( firstObj ) ;

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 1 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}

		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 2 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		{
			var obj = GameObject.Instantiate( m_SampleBlock ) ;
			obj.transform.position = firstPos ;
			var pos = obj.transform.position ;
			pos.y -= 3 ;
			obj.transform.position = pos ;
			ret.Add( obj ) ;
		}
		return ret ;
	}

	bool CanThisBlockGoWithQueueBlocks( Vector3 testPos )
	{
		bool isOccupiedDownward = false ;

		foreach( var obj in m_QueuedBlocks )
		{
			if( testPos.y == obj.transform.position.y 
				&& testPos.x == obj.transform.position.x 
			)
			{
				return false;
			}
		}

		return true ;// valid
	}

	bool CanThisBlockGoDown( GameObject _TestBlock )
	{
		bool isReachBottom = false ;
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
				break ;
			}
		}
		if( _TestBlock.transform.position.y <= 0 )
		{
			isReachBottom = true ;
			return false ;
		}
		
		if( isOccupiedDownward || isReachBottom )
		{
			return false ;
		}
		
		return true ;
		
	}


	bool CanThisBlockGoLeft( List<GameObject> _TestBlock )
	{
		foreach( var testBlock in _TestBlock )
		{
			Vector3 left = testBlock.transform.position;
			left.x -= 1;
			if( false == this.CanThisBlockGoWithQueueBlocks( left ) ) 
			{
				return false ;
			}
		}
		return true ;
	}

	bool CanThisBlockGoRight( List<GameObject> _TestBlock )
	{
		foreach( var testBlock in _TestBlock )
		{
			Vector3 left = testBlock.transform.position;
			left.x += 1;
			if( false == this.CanThisBlockGoWithQueueBlocks( left ) ) 
			{
				return false ;
			}
		}
		return true ;
	}


	bool CanThisBlockGoDown( List<GameObject> _TestBlock )
	{
		foreach( var testBlock in _TestBlock )
		{
			if( false == this.CanThisBlockGoDown( testBlock ) ) 
			{
				return false ;
			}
		}
		
		return true ;
		
	}

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


	void CheckBlockHasReachTheTop()
	{


		foreach( var obj in this.m_QueuedBlocks )
		{
			int x = (int) obj.transform.position.x ;
			if( obj.transform.position.y == MAP_HEIGHT - 1 )
			{
				m_IsGameOver = true ;
				return; 
			}
		}

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

		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			TryTurnCurrentBlock() ;
		}
	}

	void TryTurnCurrentBlock()
	{
		if( 0 == m_CurrentBlock.Count )
		{
			return ;
		}

		Vector3 firstPos = m_CurrentBlock[ 0 ].transform.position ;

		List<Vector3> finalPosArray = new List<Vector3> ();
		finalPosArray.Add( firstPos ) ;

		float tmp = 0 ;
		for( int i = 1 ; i < m_CurrentBlock.Count ; ++i )
		{
			Vector3 pos = m_CurrentBlock[ i ].transform.position ;
			Vector3 diffVec = pos - firstPos ;
			tmp = diffVec.x ;
			diffVec.x = -diffVec.y ;
			diffVec.y = tmp ;
			Vector3 finalPos = firstPos + diffVec;
			if (!IsValidPositionX (finalPos.x)) 
			{
				return;
			}
			finalPosArray.Add( finalPos ) ;
		}

		for( int i = 0 ; i < m_CurrentBlock.Count ; ++i )
		{
			m_CurrentBlock[ i ].transform.position = finalPosArray[i] ;
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

	bool m_IsGameOver = false ;

}
