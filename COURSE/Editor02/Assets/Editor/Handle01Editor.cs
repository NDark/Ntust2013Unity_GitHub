/**
@file Handle01Editor.cs
@author NDark
@date 20130819 . file started
*/
using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof(Handle01) ) ]
public class Handle01Editor : Editor 
{
	public enum HandleDemonstration
	{
		PositionHandle ,
		RotationHandle ,
		ScaleHandle ,
		RadiusHandle ,
		FreeMoveHandle ,
		FreeRotateHandle ,
		ScaleValueHandle ,
		ArrowCap ,
		BeginGUI ,
	}
	
	
	static public HandleDemonstration m_Switch = HandleDemonstration.PositionHandle ;
	
	static public Color m_HandlesColor = Color.white ;
	static public float m_ScaleSize = 1.0f ;
	
	static public Vector3 m_FreeMoveVec = Vector3.zero ;
	static public float m_RectangleSize = 1.0f ;
	
	static public Quaternion m_FreeMoveRotation = Quaternion.identity ;
	
	static public Rect m_BeginGUIAtScene = new Rect( 50 , 50 , 100 , 200 ) ;
	static public GUIStyle m_Style1 = new GUIStyle() ;
	static public Texture2D m_BackgroundTexture = null ;
	
	// change layout of Inspector
    public override void OnInspectorGUI() 
	{
		// target is the class of ExecuteInEditMode01
		Handle01 targetWithType = (Handle01)target ;
		
		m_Switch = (HandleDemonstration) EditorGUILayout.EnumPopup( "Choose Enum" , m_Switch ) ;
		
		m_HandlesColor = EditorGUILayout.ColorField( "Handles.color" , m_HandlesColor ) ;
		
		
		switch( m_Switch )
		{
		case HandleDemonstration.ScaleHandle :
			m_ScaleSize = EditorGUILayout.FloatField( "ScaleSize" , m_ScaleSize ) ;
			break;
			
		case HandleDemonstration.FreeMoveHandle :
			m_RectangleSize = EditorGUILayout.FloatField( "SnapSize" , m_RectangleSize ) ;
			break;		
			
		case HandleDemonstration.ArrowCap :
			m_ScaleSize = EditorGUILayout.FloatField( "SnapSize" , m_ScaleSize ) ;
			break;		
			
		case HandleDemonstration.BeginGUI :
			m_BeginGUIAtScene = EditorGUILayout.RectField( "BeginGUIAtScene" , m_BeginGUIAtScene ) ;
			m_BackgroundTexture = (Texture2D)
				EditorGUILayout.ObjectField( "Background Texture " , 
					m_BackgroundTexture , 
					typeof( Texture2D ) , false ) ;
			m_Style1.fontSize = EditorGUILayout.IntField( "FontSize" , m_Style1.fontSize ) ;
			
			m_Style1.normal.textColor = m_HandlesColor ;
			m_Style1.normal.background = m_BackgroundTexture ;
				
			break;				
		}
		
		
        if( GUI.changed )
		{
			EditorUtility.SetDirty( targetWithType );
		}
    }	
	
    public void OnSceneGUI () 
	{
		Handle01 targetWithType = (Handle01)target ;
		
		Handles.color = m_HandlesColor ;
		switch( m_Switch )
		{
		case HandleDemonstration.PositionHandle :
			Vector3 tmpPos = 
				Handles.PositionHandle( targetWithType.gameObject.transform.position + Vector3.up , 
									targetWithType.gameObject.transform.rotation ) ;
			targetWithType.gameObject.transform.position = tmpPos - Vector3.up ;
			break;
		case HandleDemonstration.RotationHandle :
			targetWithType.gameObject.transform.rotation = 
				Handles.RotationHandle( targetWithType.gameObject.transform.rotation ,
									targetWithType.gameObject.transform.position + Vector3.forward ) ;
			break;
			
		case HandleDemonstration.ScaleHandle :
			targetWithType.gameObject.transform.localScale = Handles.ScaleHandle( targetWithType.gameObject.transform.localScale ,
								 targetWithType.gameObject.transform.position + Vector3.right , 
								 targetWithType.gameObject.transform.rotation , 
								 m_ScaleSize ) ;
			break;
			
		case HandleDemonstration.RadiusHandle :
			m_ScaleSize = Handles.RadiusHandle( targetWithType.gameObject.transform.rotation , 
								 targetWithType.gameObject.transform.position + Vector3.up , 
								 m_ScaleSize ) ;
			break;		
		case HandleDemonstration.FreeMoveHandle :
			m_FreeMoveVec = Handles.FreeMoveHandle( m_FreeMoveVec , 
													Quaternion.identity ,
												 	m_RectangleSize , 
													Vector3.zero , 
													Handles.RectangleCap ) ;
			targetWithType.gameObject.transform.position = m_FreeMoveVec ;
			break;
			
		case HandleDemonstration.FreeRotateHandle :
			m_FreeMoveRotation = Handles.FreeRotateHandle( m_FreeMoveRotation , 
													Vector3.zero ,
												 	m_RectangleSize  ) ;
			targetWithType.gameObject.transform.rotation = m_FreeMoveRotation ;
			break;
			
		case HandleDemonstration.ScaleValueHandle :
			m_ScaleSize = Handles.ScaleValueHandle( m_ScaleSize ,
													targetWithType.gameObject.transform.position , 
													targetWithType.gameObject.transform.rotation ,
													30 , 
													Handles.RectangleCap ,
													1.0f ) ;
			targetWithType.gameObject.transform.localScale = 
				new Vector3( m_ScaleSize , m_ScaleSize , m_ScaleSize ) ;
			
			break;			
			
		case HandleDemonstration.ArrowCap :
			Handles.ArrowCap( 0 , 
				targetWithType.gameObject.transform.position + 
					targetWithType.gameObject.transform.forward * 3 , 
				targetWithType.gameObject.transform.rotation ,
				m_ScaleSize ) ;
			
			break;	
			
		case HandleDemonstration.BeginGUI :
			{
				Handles.BeginGUI() ;
					GUI.Box( m_BeginGUIAtScene , "This is " + targetWithType.gameObject.name , m_Style1 ) ;
				Handles.EndGUI() ;
			}
			break;				
			
		}
		
        if (GUI.changed)
		{
            EditorUtility.SetDirty (targetWithType);
		}
    }		
}

