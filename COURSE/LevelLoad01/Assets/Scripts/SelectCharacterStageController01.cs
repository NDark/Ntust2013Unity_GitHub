/*
@file SelectCharacterStageController01.cs
@author NDark
@date 20130813 file started.
*/
using UnityEngine;

public class SelectCharacterStageController01 : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RotateByAngular04 rotateScript = this.gameObject.GetComponent<RotateByAngular04>() ;
		if( null == rotateScript )
		{
			if( 1 == Input.GetAxis( "Horizontal" ) )
			{
				rotateScript = this.gameObject.AddComponent<RotateByAngular04>() ;
				rotateScript.m_TargetAngle.y = 60 ;
				rotateScript.m_AngleSpeed = 1.0f ;
			}
			else if( -1 == Input.GetAxis( "Horizontal" ) )
			{
				rotateScript = this.gameObject.AddComponent<RotateByAngular04>() ;
				rotateScript.m_TargetAngle.y = -60 ;
				rotateScript.m_AngleSpeed = -1.0f ;
			}	
			
		}
	}
}
