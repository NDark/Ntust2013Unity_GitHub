/**
@file ClickSceneCreateObject01Editor.cs
@author NDark

http://answers.unity3d.com/questions/17141/making-a-tilemap-editor-within-the-unity-editor.html
http://answers.unity3d.com/questions/62859/left-click-up-event-in-editor.html
http://answers.unity3d.com/questions/173950/disable-mouse-selection-in-editor-view.html

@date 20131029 . file started

*/
using UnityEngine;
using UnityEditor;

[CustomEditor ( typeof(ClickSceneCreateObject01) ) ]
public class ClickSceneCreateObject01Editor : Editor 
{
	public static int iter = 0 ;
	bool wasMouseDown = false ;
	public static string m_ObjectNamePreFix = "" ;
	
	// change layout of Inspector
    public override void OnInspectorGUI() 
	{
		EditorGUILayout.TextField( "ObjNamePreFix" , m_ObjectNamePreFix );
	}
	
	void OnSceneGUI()
	{
		if( Event.current.type == EventType.MouseDown && 
			Event.current.button == 0 ) 
		{
			// Debug.Log("Left-Mouse Down");
			wasMouseDown = true;
		}
		else if (wasMouseDown) 
		{
			// Debug.Log("Left-Mouse Up");
			wasMouseDown = false;
			RaycastHit hitInfo ;
			Ray testRat = HandleUtility.GUIPointToWorldRay( Event.current.mousePosition ) ;
			if( true == Physics.Raycast( testRat , out hitInfo ) )
			{
				// Debug.Log("true == Physics.Raycast");
				GameObject obj = new GameObject( m_ObjectNamePreFix+((iter++).ToString()) ) ;
				obj.transform.position = hitInfo.point ;
				Selection.activeObject = obj ;
			}
			else
			{
				GameObject obj = new GameObject( m_ObjectNamePreFix+((iter++).ToString()) ) ;
				// Debug.Log("false == Physics.Raycast");
				Selection.activeObject = obj ;
			}
		}
		
		HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
		
		// seem no use
		// Debug.Log("Event.current.Use");
		// Event.current.Use() ;
	}
	
}
