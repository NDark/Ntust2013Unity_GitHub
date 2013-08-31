/**
@file LookAtPoint04Editor.cs
@author NDark
@date 20130819 . file started
*/
using UnityEngine;
using UnityEditor;

#if UNDERCONSTRUCTION
// Attention!!! un-mark this line to see the change of m_BallTransform
[CustomEditor (typeof(LookAtPoint04)), CanEditMultipleObjects ]
public class LookAtPoint04Editor : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// change layout of Inspector
    public override void OnInspectorGUI() 
	{
		LookAtPoint04 finalTarget = (LookAtPoint04)target ;
		Vector3 onePos = 
				EditorGUILayout.Vector3Field( "Look At Point" , 
											   finalTarget.m_TargetPosition );
			
		foreach( Object tar in targets )
		{
			// Debug.Log( tar.name ) ;
			// target is the class of ExecuteInEditMode01
			LookAtPoint04 targetWithType = (LookAtPoint04)tar ;
			
			targetWithType.m_TargetPosition = onePos ;
	        if( GUI.changed )
			{
	            EditorUtility.SetDirty ( targetWithType );
			}			
		}
		
    }		
	
	// try modify your value of targetPosition
    public void OnSceneGUI () 
	{
		
		LookAtPoint04 finalTarget = (LookAtPoint04)target ;
		finalTarget.m_TargetPosition = 
			Handles.PositionHandle( finalTarget.m_TargetPosition , 
				Quaternion.identity );
					
        if( GUI.changed )
		{
            EditorUtility.SetDirty ( finalTarget );
		}			
    }
	
	public override void OnPreviewGUI( Rect r, GUIStyle background )
	{
        EditorGUILayout.HelpBox( "XD" , MessageType.Error ) ;
		EditorGUILayout.LabelField ("XD") ;
	}
}

#endif