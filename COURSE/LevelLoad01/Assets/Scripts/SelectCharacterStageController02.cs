/*
@file SelectCharacterStageController02.cs
@author NDark
@date 20130813 file started.
*/
using UnityEngine;

public class SelectCharacterStageController02 : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RotateByAngular05 rotateScript = this.gameObject.GetComponent<RotateByAngular05>() ;
		if( null == rotateScript )
		{
			if( 1 == Input.GetAxis( "Horizontal" ) )
			{
				rotateScript = this.gameObject.AddComponent<RotateByAngular05>() ;
				rotateScript.m_TargetAngle.y = 60 ;
			}
			else if( -1 == Input.GetAxis( "Horizontal" ) )
			{
				rotateScript = this.gameObject.AddComponent<RotateByAngular05>() ;
				rotateScript.m_TargetAngle.y = -60 ;
			}	
			
		}
	}
}
