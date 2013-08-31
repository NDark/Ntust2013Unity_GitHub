/*
@file TripleTaoEditorWindow.cs
@author NDark
@date 20130826 file started.
@date 20130831 rename class member m_StageParent to m_StageParent
*/
using UnityEngine;
using UnityEditor ; // add this for editor
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TripleTaoEditorWindow : EditorWindow 
{
	[MenuItem ("Triple Tao/Manager Window 1")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<TripleTaoEditorWindow>() ;
    }
	
	// GameObject GlobalSingleton
	public GameObject m_GlobalSingleton = null ;
	
	// GameObject StageBoardParent
	public GameObject m_StageBoardParent = null ;
	
	// each StageBoard with collider
	public List<GameObject> m_StageBoards = new List<GameObject>() ;
	
	// start position of first stage board
	public Vector3 m_StartPos = Vector3.zero ;
	
	// space of 2 stage board
	public Vector3 m_SpaceOfBoards = new Vector3( 1.1f , 0 , 1.1f )  ;
	public int m_WidthNum = 1 ;
	public int m_HeightNum = 1 ;
	// index of boards will be j * m_HeightNum + i .
	
	// all materials corresponding to UnitType
	public Material[] m_Materials = new Material[ 1 ] ;
	public bool m_ToggleMaterial = false ;
	
	// preserve index i and j
	public int m_PreserveIndexI = 0 ;
	public int m_PreserveIndexJ = 0 ;
	
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
		
		
		if( true == GUILayout.Button( "CreateStageBoard" ) )
		{
			RecreateStageBoard() ;
		}
		
		// materials assign
		m_ToggleMaterial = EditorGUILayout.Toggle( "Materials" , 
												   m_ToggleMaterial ) ;
		int matNum = EditorGUILayout.IntField( "Material Num" , 
											   m_Materials.Length ) ;
		if( m_Materials.Length != matNum )
		{
			m_Materials = new Material[ matNum ] ;
		}
		
		// show m_Materials[]
		if( true == m_ToggleMaterial && 
			null != m_Materials )
		{
			for( int i = 0 ; i < m_Materials.Length ; ++i )
			{
				m_Materials[ i ] = 
					(Material) EditorGUILayout.ObjectField( m_Materials[ i ] , 
															typeof( Material ) , 
															false ) ;
			}
		}
		
		// save materials information to Assets/Resources/MaterialDoc.txt
		if( true == GUILayout.Button( "Set Material" ) )
		{
			SetMaterial() ;
		}
		
		// preserve index i , j
		m_PreserveIndexI = EditorGUILayout.IntField( "Preserve Index I" , 
													 m_PreserveIndexI ) ;
		m_PreserveIndexJ = EditorGUILayout.IntField( "Preserve Index J" , 
													 m_PreserveIndexJ ) ;
	}
	
	private void RecreateStageBoard()
	{
		// destroy old stage boards
		ClearAllStageBoards() ;
		
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
				string prefabName = "StageBoard" ;
				if( m_PreserveIndexI == i && 
					m_PreserveIndexJ == j )
					prefabName = "StageBoardPreserve" ;
				
				
				Object prefab = Resources.Load( prefabName ) ;
				if( null == prefab )
				{
					Debug.LogError( "null == prefab" ) ;
				}
				else 
				{
					GameObject obj = (GameObject) GameObject.Instantiate( prefab ) ;
					obj.name = "StageBoard:" + i + "," + j ;
					
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
					
					
					// add basic script UnitData to stage board ( for index i,j )
					UnitData script = obj.AddComponent<UnitData>() ;
					script.m_IndexI = i ;
					script.m_IndexJ = j ;
					
					// add basic script collide for drop test
					obj.AddComponent<OnMouseDownDropUnit>() ;
					
					// parent is m_StageBoardParent
					obj.transform.parent = m_StageBoardParent.transform ;					
					
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
		
		TripleTaoManager manager = m_GlobalSingleton.GetComponent<TripleTaoManager>() ;
		if( null == manager )
		{
			
		}
		else
		{
			manager.m_WidthNum = this.m_WidthNum ;
			manager.m_HeightNum = this.m_HeightNum ;
			manager.m_PreserveIndex = m_PreserveIndexJ * m_HeightNum + m_PreserveIndexI ;
		}
		
	}
	
	private void ClearAllStageBoards()
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
			for( int j = 0 ; j < m_HeightNum ; ++j )
			{
				for( int i = 0 ; i < m_WidthNum ; ++i )
				{
					string objName = "StageBoard:" + i + "," + j ;					
					Transform trans = m_StageBoardParent.transform.FindChild( objName ) ;
					if( null != trans )
					{
						GameObject.DestroyImmediate( trans.gameObject ) ;
					}
				}
			}
		}
		

	}
	
	// save material data to a file
	private void SetMaterial()
	{
		StreamWriter sw = new StreamWriter( "Assets/Resources/MaterialDoc.txt" ) ;
		if( null == sw )
			return ;
		string content = "" ;
		for( int i = 0 ; i < m_Materials.Length ; ++i )
		{
			content = content + "," + m_Materials[ i ].name.ToString()  ;
			
		}
		sw.Write( content ) ;
		sw.Close() ;
		Debug.Log( "content" + content ) ;
	}
	
}
