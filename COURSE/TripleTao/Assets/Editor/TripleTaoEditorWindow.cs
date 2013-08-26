/*
@file TripleTaoEditorWindow.cs
@author NDark
@date 20130826 file started.
*/
using UnityEngine;
using UnityEditor ; // add this for editor
using System.Collections.Generic;

public class TripleTaoEditorWindow : EditorWindow 
{
	[MenuItem ("Triple Tao/Manager Window 1")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<TripleTaoEditorWindow>() ;
    }		
	
	public GameObject m_GlobalSingleton = null ;
	
	public GameObject m_StageParent = null ;
	public List<GameObject> m_StageBoards = new List<GameObject>() ;
	
	public Vector3 m_StartPos = Vector3.zero ;
	public Vector3 m_SpaceOfBoards = new Vector3( 1.1f , 0 , 1.1f )  ;
	public int m_WidthNum = 1 ;
	public int m_HeightNum = 1 ;
	void OnGUI()
	{
		m_StartPos = EditorGUILayout.Vector3Field( "StartPos" , m_StartPos ) ;
		m_SpaceOfBoards = EditorGUILayout.Vector3Field( "Space between board" , m_SpaceOfBoards ) ;
		m_WidthNum = EditorGUILayout.IntField( "WidthNum" , m_WidthNum ) ;
		m_HeightNum= EditorGUILayout.IntField( "HeightNum" , m_HeightNum ) ;
		if( true == GUILayout.Button( "CreateStageBoard" ) )
		{
			RecreateStageBoard() ;
		}
	}
	
	private void RecreateStageBoard()
	{
		ClearAllStageBoards() ;
		
		if( null == m_StageParent )
		{
			m_StageParent = new GameObject("StageBoardParent") ;

		}
		for( int j = 0 ; j < m_HeightNum ; ++j )
		{
			for( int i = 0 ; i < m_WidthNum ; ++i )
			{
				Object prefab = Resources.Load( "StageBoard" ) ;
				if( null == prefab )
				{
					Debug.LogError( "null == prefab" ) ;
				}
				else 
				{
					GameObject obj = (GameObject) GameObject.Instantiate( prefab ) ;
					obj.name = "StageBoard:" + i + "," + j ;
					obj.transform.position = new Vector3( m_StartPos.x + i * m_SpaceOfBoards.x ,
						m_StartPos.y , 
						m_StartPos.z + j * m_SpaceOfBoards.z );
					
					if( i == m_WidthNum / 2 &&
						j == m_HeightNum / 2 )
					{
						Camera.mainCamera.transform.position = 
							new Vector3( obj.transform.position.x ,
									 	 obj.transform.position.y + 10 ,
										 obj.transform.position.z ) ;	
						if( m_WidthNum > m_HeightNum )
							Camera.mainCamera.orthographicSize = m_WidthNum / 2.0f ;
						else 
							Camera.mainCamera.orthographicSize = m_HeightNum / 2.0f ;
					}
					
					UnitData script = obj.AddComponent<UnitData>() ;
					script.m_IndexI = i ;
					script.m_IndexJ = j ;
					
					obj.AddComponent<OnMouseDownDropUnit>() ;
					
					obj.transform.parent = m_StageParent.transform ;					
					m_StageBoards.Add( obj ) ;
				}
			}
		}
		
		if( null == m_GlobalSingleton )
		{
			m_GlobalSingleton = GameObject.Find( "GlobalSingleton" ) ;
		}
		TripleTaoManager manager = m_GlobalSingleton.GetComponent<TripleTaoManager>() ;
		manager.m_WidthNum = this.m_WidthNum ;
		manager.m_HeightNum = this.m_HeightNum ;
		// set parameter to manager
		
		
	}
	
	private void ClearAllStageBoards()
	{
		foreach( GameObject obj in m_StageBoards )
		{
			// can't use Destroy
			GameObject.DestroyImmediate( obj ) ;
		}
		
		m_StageBoards.Clear() ;
	}
}
