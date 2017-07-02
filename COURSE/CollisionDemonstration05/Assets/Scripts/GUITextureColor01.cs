/**
@file GUITextureColor01.cs
@author NDark
@date 20130801 file started.
*/
using UnityEngine;

public class GUITextureColor01 : MonoBehaviour 
{
	public float m_ElapsedSec = 1.0f ;
	public float m_StartTime = 0.0f ;
	public float m_EndTime = 0.0f ;
	
	public GUITexture m_TargetGUITexture = null ;
	
	public Color m_OrgColor = new Color() ;
	public Color m_TargetColor = Color.red ;
	public float m_FadeSpeed = 0.1f ; 
	
	// Use this for initialization
	void Start () 
	{
		m_StartTime = Time.timeSinceLevelLoad ;
		m_EndTime = m_StartTime + m_ElapsedSec ;
		m_TargetGUITexture = this.GetComponent<GUITexture>() ;
		m_OrgColor = m_TargetGUITexture.color ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Time.timeSinceLevelLoad > m_EndTime )
		{
			EndFade() ;
			Component.Destroy( this ) ;
		}
		else
		{
			Fading() ;
		}
	}
	
	private void EndFade()
	{
		m_TargetGUITexture.color = m_OrgColor ;
	}
	
	private void Fading()
	{
		m_TargetGUITexture.color = Color.Lerp( m_TargetGUITexture.color , m_TargetColor , m_FadeSpeed ) ;
	}	
}
