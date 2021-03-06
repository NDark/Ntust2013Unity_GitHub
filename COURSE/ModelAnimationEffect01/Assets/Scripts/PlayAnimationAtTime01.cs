/*
@file PlayAnimationAtTime01.cs
@author NDark
@date 20130908 file started.
@date 20130913 by NDark . add animation.IsPlaying() at Update()
*/
using UnityEngine;

public class PlayAnimationAtTime01 : MonoBehaviour 
{
	public string m_AnimationStr = "" ;
	public float m_AnimationTime = 0.0f ;
	
	public void PlayAnimationAtSpecifiedTime() 
	{
		// Debug.Log( "PlayAnimationAtSpecifiedTime" ) ;
		if( null == this.GetComponent<Animation>()[ m_AnimationStr ] )
			return ;
		this.GetComponent<Animation>()[ m_AnimationStr ].time = m_AnimationTime ;
		this.GetComponent<Animation>()[ m_AnimationStr ].speed = 0.0f ;
		this.GetComponent<Animation>().Play( m_AnimationStr ) ;			
	}
	
	// Use this for initialization
	void Start () 
	{
			
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( true == this.GetComponent<Animation>().IsPlaying( "walk" ) )
		{
			Debug.Log( "walk is in play." ) ;
		}
	}
}
