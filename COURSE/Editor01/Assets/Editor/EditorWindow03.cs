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
	
	// the content of your window draw here.
	void OnGUI()
	{
		
	}

}
