/*
@file ClickGUITextureAndShowGUITexture01.cs
@author NDark
@date 20130725 file started.
*/
using UnityEngine;

public class ClickGUITextureAndShowGUITexture01 : MonoBehaviour 
{
	public GameObject m_AnotherObject = null ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		Debug.Log( "OnMouseDown()" ) ;
		if( null != m_AnotherObject )
		{
			GUITexture guiTexture = m_AnotherObject.GetComponent<GUITexture>() ;
			if( null != guiTexture )
				guiTexture.enabled = true ;
		}
	}		
}
