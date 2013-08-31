/*
@file EditorWindow03.cs
@author NDark

Attention!!!!
Script must be placed in the folder called "Editor" in Assets

@date 20130820 file started.
*/
using UnityEngine;
using UnityEditor ; // add this for editor
	
// You don't have to put script on GameObject
public class EditorWindow03 : EditorWindow 
{
	[MenuItem ("Window/My Window 3")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<EditorWindow03>() ;
    }		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	private bool m_Toggle1 = false ;
	private float m_Value = 0 ;
	// the content of your window draw here.
	void OnGUI()
	{
		m_Toggle1 = EditorGUI.Toggle( new Rect( 0 , 0 , 15 , 15 ) , m_Toggle1 ) ;
		if( true == m_Toggle1 )
		{
			if( null != Selection.activeObject &&
				typeof( Texture2D ) == 
					Selection.activeObject.GetType() )
			{
				Texture selectTexure = (Texture) Selection.activeObject ;
				Rect drawTextureRect = new Rect( 15 , 15 , 
												 selectTexure.width , 
												 selectTexure.height ) ;
				// EditorGUILayout
				EditorGUI.DrawPreviewTexture( drawTextureRect , 
											  selectTexure ) ;
			}
		}
		
		m_Value = EditorGUI.Slider( new Rect( 0 , 30 , 150 , 20 ) , 
									m_Value , 
									0 , 
									100 ) ;
		
		// EditorGUILayout
		EditorGUI.ProgressBar( new Rect( 0 , 70 , 150 , 50 ) , 
							   m_Value * 0.01f , 
							   "ProgressBar" ) ;
		
	}

}
