/**
@file EditorUtility01.cs
@author NDark

http://docs.unity3d.com/Documentation/ScriptReference/EditorUtility.html

@date 20130902 . file started
*/
using UnityEngine;
using UnityEditor;

public class EditorUtility01 : MonoBehaviour 
{
	[MenuItem ("EditorUtility01/DisplayDialog")]
	static void DisplayDialog() 
	{
		if( true == EditorUtility.DisplayDialog( "TitleCowbay" , "Message" , "OK" ) )
		{
			Debug.Log( "true == EditorUtility.DisplayDialog" ) ;
		}
	}
		
	[MenuItem ("EditorUtility01/DisplayDialogComplex")]
	static void DisplayDialogComplex() 
	{
		int result = -1 ; // 0 , 1 , 2 for each button
		result = EditorUtility.DisplayDialogComplex( "Title" , "Message" , "0k" , "Cancer" , "olt" ) ;
		{
			Debug.Log( "DisplayDialogComplex() => result=" + result ) ;
		}
	}
	
	
	[MenuItem ("EditorUtility01/DisplayPopupMenu")]
	static void DisplayPopupMenu() 
	{
		Rect popupMenuRect = 
			new Rect( 500 , 400 , 200 , 200 ) ;
		
		EditorUtility.DisplayPopupMenu( popupMenuRect , 
			"Assets/" , 
			null ) ;
			
	}
	
	static float m_Progress = 0.0f ;
	[MenuItem ("EditorUtility01/DisplayProgressBarAndClear")]
	static void DisplayProgressBarAndClear() 
	{
		m_Progress += 0.3f ;
		if( m_Progress > 1.2f ) 
		{
			m_Progress = 0.0f ;
			EditorUtility.ClearProgressBar() ;
		}
		else
		{
			EditorUtility.DisplayProgressBar( "Title" , "Info" , m_Progress ) ;
		}
	}	
	
	
	[MenuItem ("EditorUtility01/OpenFilePanel")]
	static void OpenFilePanel() 
	{
		string result = EditorUtility.OpenFilePanel( 
			"Title" , 
			"Assets/Static/Materials" , 
			"mat" ) ;
		if( 0 != result.Length )
		{
			Debug.Log( result ) ;
		}
	}		
	
	[MenuItem ("EditorUtility01/OpenFolderPanel")]
	static void OpenFolderPanel() 
	{
		string result = EditorUtility.OpenFolderPanel( 
			"Title" , 
			"Assets/Static" , 
			"Materials" ) ;
		if( 0 != result.Length )
		{
			Debug.Log( result ) ;
		}
	}		
	
	static bool m_Enable = false ;
	[MenuItem ("EditorUtility01/SetObjectEnabled")]
	static void SetObjectEnabled() 
	{
		if( null != Selection.activeObject )
		{
			EditorUtility.SetObjectEnabled( 
				Selection.activeObject , 
				m_Enable ) ;
			m_Enable = ! m_Enable ;
		}
	}
	
}
