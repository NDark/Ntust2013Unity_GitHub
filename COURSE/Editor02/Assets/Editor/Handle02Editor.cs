/**
@file Handle02Editor.cs
@author NDark
@date 20130905 . file started
*/
using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor ( typeof(Handle02) ) ]
public class Handle02Editor : Editor 
{
	public enum HandleDemonstration
	{
		DrawLine ,
		DrawPolyLine ,
		DrawAntiAliasedPolygonLine ,
		DrawSolidRectangleWithOutline ,
		DrawBezier ,
	}
	
	static HandleDemonstration m_Switch = HandleDemonstration.DrawLine ;
	static Texture2D m_AATexture = null ;
	static float m_ScaleSize = 1.0f ;
	static Color m_Color1 = Color.white ;
	static Color m_Color2 = Color.white ;
	
    public override void OnInspectorGUI() 
	{
		Handle02 targetWithType = (Handle02)target ;
		
		
		m_Switch = (HandleDemonstration)EditorGUILayout.EnumPopup( "Switch" , m_Switch ) ;
		
		targetWithType.m_StartPoint = (Transform)
			EditorGUILayout.ObjectField( "StartPoint" , targetWithType.m_StartPoint , 
										 typeof( Transform ) , true ) ;
		targetWithType.m_EndPoint = (Transform)
			EditorGUILayout.ObjectField( "EndPoint" ,targetWithType.m_EndPoint , 
										 typeof( Transform ) , true ) ;
		
		targetWithType.m_ControlPoint0 = (Transform)
			EditorGUILayout.ObjectField(  "ControlPoint0" ,targetWithType.m_ControlPoint0 , 
										 typeof( Transform ) , true ) ;
		targetWithType.m_ControlPoint1 = (Transform)
			EditorGUILayout.ObjectField(  "ControlPoint1" ,targetWithType.m_ControlPoint1 , 
										 typeof( Transform ) , true ) ;
		
		m_AATexture = (Texture2D)
			EditorGUILayout.ObjectField(  "AATexture" , m_AATexture , 
										 typeof( Texture2D ) , false ) ;

		m_ScaleSize = EditorGUILayout.FloatField(  "ScaleSize" , m_ScaleSize ) ;

		m_Color1 = EditorGUILayout.ColorField(  "Color1" , m_Color1 ) ;
		m_Color2 = EditorGUILayout.ColorField(  "Color" , m_Color2 ) ;
		
        if (GUI.changed)
		{
            EditorUtility.SetDirty (targetWithType);
		}
	}
	
    public void OnSceneGUI () 
	{
		Handle02 targetWithType = (Handle02)target ;
		
		switch( m_Switch )
		{
		case HandleDemonstration.DrawLine :
			Handles.DrawLine( targetWithType.m_StartPoint.position , 
						  	  targetWithType.m_EndPoint.position ) ;
			break ;
			
		case HandleDemonstration.DrawPolyLine :
			Vector3 [] vec1s = { 
				targetWithType.m_StartPoint.position , 
				targetWithType.m_ControlPoint0.position ,
				targetWithType.m_ControlPoint1.position ,
				targetWithType.m_EndPoint.position
			} ;
			Handles.DrawPolyLine( vec1s ) ;
			break ;		
			
		case HandleDemonstration.DrawAntiAliasedPolygonLine :
			Vector3 [] vec2s = { 
				targetWithType.m_StartPoint.position , 
				targetWithType.m_ControlPoint0.position ,
				targetWithType.m_ControlPoint1.position ,
				targetWithType.m_EndPoint.position
			} ;
			
			if( null != m_AATexture )
				Handles.DrawAAPolyLine( m_AATexture , m_ScaleSize , vec2s ) ;
			else
				Handles.DrawAAPolyLine( m_ScaleSize , vec2s ) ;
			break ;			
			
		case HandleDemonstration.DrawSolidRectangleWithOutline :
			Vector3 [] vec3s = { 
				targetWithType.m_StartPoint.position , 
				targetWithType.m_ControlPoint0.position ,
				targetWithType.m_ControlPoint1.position ,
				targetWithType.m_EndPoint.position
			} ;
			
			Handles.DrawSolidRectangleWithOutline( vec3s , m_Color1 , m_Color2 ) ;
			break ;						
			
		case HandleDemonstration.DrawBezier :
			Vector3 tangent0 = targetWithType.m_ControlPoint0.position - targetWithType.m_StartPoint.position ; 
			Vector3 tangent1 = targetWithType.m_ControlPoint1.position - targetWithType.m_EndPoint.position ;
			
			targetWithType.m_ControlPoint0.position = 
				Handles.PositionHandle( targetWithType.m_ControlPoint0.position , 
										targetWithType.m_ControlPoint0.rotation ) ;
			targetWithType.m_ControlPoint1.position = 
				Handles.PositionHandle( targetWithType.m_ControlPoint1.position , 
										targetWithType.m_ControlPoint1.rotation ) ;			
			
			Handles.DrawBezier( targetWithType.m_StartPoint.position
								, targetWithType.m_EndPoint.position 
								, tangent0 
								, tangent1 , 
								m_Color1 , m_AATexture , m_ScaleSize ) ;
			break ;				
		}
		// */
        if (GUI.changed)
		{
            EditorUtility.SetDirty (targetWithType);
		}		
	}
}
