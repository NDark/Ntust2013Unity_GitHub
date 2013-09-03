/**
@file LookAtPoint04Editor.cs
@author NDark

OnPreviewGUI doesn't work.
 
read this link
http://forum.unity3d.com/threads/71070-Unable-to-get-OnPreviewGUI-to-fire

"This is actually an error in the documentation. 
The previews are intentionally designed to work only with persistent object editors 
for the time being, but the docs don't mention that. 
They have already been updated but the full release isn't ready yet 
so you won't see the changes immediately. 

"Please note that, 
according to the documentation, 
inspector previews are limited to the primary editor of persistent objects: 
GameObjectInspector, MaterialEditor, TextureInspector. 
This means that it is currently not possible for a component to have its own inspector preview. 
Here is an example:"

@date 20130819 . file started
*/
#define UNDERCONSTRUCTION
using UnityEngine;
using UnityEditor;

#if UNDERCONSTRUCTION
// Attention!!! un-mark this line to see the change of m_BallTransform
[CustomEditor (typeof(LookAtPoint04)), CanEditMultipleObjects ]
public class LookAtPoint04Editor : Editor {

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
		
		// OnPreviewGUI(new Rect(0,0,300,300), new GUIStyle());
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
	
	/*

	 */
	public override void OnPreviewGUI( Rect r, GUIStyle background )
	{
        EditorGUILayout.HelpBox( "XD" , MessageType.Error ) ;
		EditorGUILayout.LabelField ("XD") ;
	}
}

#endif