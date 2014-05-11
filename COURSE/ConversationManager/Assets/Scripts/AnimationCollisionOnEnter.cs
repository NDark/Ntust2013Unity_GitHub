/**
@file AnimationCollisionOnEnter.cs
@author NDark
@date 20140406 file started.
@date 20140412 by NDark . 修改 m_TargetPlayer 與 other.name 不相同的錯誤.
@date 20140504 by NDark . 修改移除 target player 的設定
 */
using UnityEngine;
using System.Collections.Generic;

public class AnimationCollisionOnEnter : MonoBehaviour 
{
	public string m_ParentName = "" ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log( "OnTriggerEnter2D() , other=" + other.name  ) ;
		if( other.name != m_ParentName )
		{
			GlobalSingleton.GetDamageSystem().Encounter( this.gameObject , other.gameObject ) ;
			


			
		}

	}
}
