/*
@file KandyCrusherEditorWindow.cs
@author NDark
@date 20130906 file started.
@date 20130908 by NDark . add code of UnitData at RecreateEmptyBoard()

*/
using UnityEngine;
using UnityEditor ; // add this for editor
using System.Collections;
using System.Collections.Generic;


public class KandyCrusherEditorWindow : EditorWindow 
{
	[MenuItem ("KandyCrusher/Manager Window 1")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<KandyCrusherEditorWindow>() ;
    }
	
	// GameObject GlobalSingleton
	public GameObject m_GlobalSingleton = null ;
	
	// GameObject StageBoardParent
	public GameObject m_StageBoardParent = null ;
	
	// each StageBoard with collider
	public List<GameObject> m_StageBoards = new List<GameObject>() ;
	
	// start position of first stage board
	static public Vector3 m_StartPos = Vector3.zero ;
	
	// space of 2 stage board
	static public Vector3 m_SpaceOfBoards = new Vector3( 1.1f , 0 , 1.1f )  ;
	static public int m_WidthNum = 1 ;
	static public int m_HeightNum = 1 ;
	// index of boards will be j * m_HeightNum + i .
	
		
	void OnGUI()
	{
		// stage board layout
		m_StartPos = EditorGUILayout.Vector3Field( "StartPos" , 
												   m_StartPos ) ;
		m_SpaceOfBoards = EditorGUILayout.Vector3Field( "Space between board" , 
														m_SpaceOfBoards ) ;
		m_WidthNum = EditorGUILayout.IntField( "WidthNum" , 
											   m_WidthNum ) ;
		m_HeightNum= EditorGUILayout.IntField( "HeightNum" , 
											   m_HeightNum ) ;
		
		
		if( true == GUILayout.Button( "RecreateEmptyBoard" ) )
		{
			RecreateEmptyBoard() ;
			
		}
		if( true == GUILayout.Button( "InvisibleAllEmptyBoards" ) )
		{
			Invisible() ;
		}
		
	}
	
	private void RecreateEmptyBoard()
	{
		// destroy old stage boards
		ClearAllEmptyBoards() ;
		
		// create stage board parent
		m_StageBoardParent = GameObject.Find( "StageBoardParent" ) ;
		if( null == m_StageBoardParent )
		{
			m_StageBoardParent = new GameObject("StageBoardParent") ;
		}
		
		// create stage board by i and j
		for( int j = 0 ; j < m_HeightNum ; ++j )
		{
			for( int i = 0 ; i < m_WidthNum ; ++i )
			{
				// preserver or not
				string prefabName = "EmptyUnit" ;
				
				Object prefab = Resources.Load( prefabName ) ;
				if( null == prefab )
				{
					Debug.LogError( "null == prefab" ) ;
				}
				else 
				{
					GameObject obj = (GameObject) GameObject.Instantiate( prefab ) ;
					obj.name = "EmptyUnit:" + i + "," + j ;
					
					// start pos + ( i * width , j * height )
					obj.transform.position = 
						new Vector3( m_StartPos.x + i * m_SpaceOfBoards.x ,
									 m_StartPos.y , 
									 m_StartPos.z + j * m_SpaceOfBoards.z );
					
					// set up Camera pos by the center stage board
					// only execute once
					if( i == m_WidthNum / 2 &&
						j == m_HeightNum / 2 )
					{
						Vector3 shiftVec = Vector3.zero ;
						
						// even or odd ( shift half board )
						if( 0 == m_WidthNum % 2 )
						{
							shiftVec.x = m_SpaceOfBoards.x / 2.0f ;
						}
						if( 0 == m_HeightNum % 2 )
						{
							shiftVec.z = m_SpaceOfBoards.z / 2.0f ;
						}
						
						// center board pos - shift
						Camera.mainCamera.transform.position = 
							new Vector3( obj.transform.position.x - shiftVec.x ,
									 	 obj.transform.position.y + 10 ,
										 obj.transform.position.z - shiftVec.z ) ;	
						
						// orthogonal size by max of width and height
						if( m_WidthNum > m_HeightNum )
							Camera.mainCamera.orthographicSize = m_WidthNum / 2.0f ;
						else 
							Camera.mainCamera.orthographicSize = m_HeightNum / 2.0f ;
					}
					
					UnitData unitData = obj.AddComponent<UnitData>() ;
					unitData.m_IndexI = i ;
					unitData.m_IndexJ = j ;
					// parent is m_StageBoardParent
					obj.transform.parent = m_StageBoardParent.transform ;	
					
					obj.AddComponent<CheckInput>() ;
					
					// clear to list
					m_StageBoards.Add( obj ) ;
				}// end of for i
			}// end of for j
		}
		
		// set width, height, and preserver index to TripleTaoManager
		if( null == m_GlobalSingleton )
		{
			m_GlobalSingleton = GameObject.Find( "GlobalSingleton" ) ;
		}
		
		
		KandyCrusherManager manager = m_GlobalSingleton.GetComponent<KandyCrusherManager>() ;
		if( null == manager )
		{
			
		}
		else
		{
			manager.m_WidthNum = m_WidthNum ;
			manager.m_HeightNum = m_HeightNum ;
			manager.m_EmptyBoards = m_StageBoards ;
		}
	}
	
	private void ClearAllEmptyBoards()
	{
		foreach( GameObject obj in m_StageBoards )
		{
			// can't use Destroy
			GameObject.DestroyImmediate( obj ) ;
		}
		m_StageBoards.Clear() ;
		
		
		// in case this window show up first time
		m_StageBoardParent = GameObject.Find( "StageBoardParent" ) ;
		if( null != m_StageBoardParent )
		{
			GameObject.DestroyImmediate( m_StageBoardParent ) ;
		}

	}
	
	
	
	private void Invisible()
	{
		foreach( GameObject obj in m_StageBoards )
		{
			// can't use Destroy
			obj.renderer.enabled = false ;
		}
		
		
		

	}	
	
}
