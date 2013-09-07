/*
@file WWW05.cs
@author NDark

// Under construction
@date 20130821 file started.
*/
using UnityEngine;
using System.Collections;

// Under construction
// Under construction
// Under construction
public class WWW05 : MonoBehaviour 
{
	public string m_Unity3DURL = "kobayashi.gadgetapp.net/KobayashiMaruCommander.unity3d" ;
	public string m_SceneNameInBundle = "Warning" ;
	WWW m_WWWObj ;
	// Use this for initialization
	void Start () 
	{
		m_WWWObj = WWW.LoadFromCacheOrDownload( m_Unity3DURL , 0 ) ;
		StartCoroutine( wwwCallbackFunction() ) ;

	}
	
	public IEnumerator wwwCallbackFunction()
	{
		yield return m_WWWObj ;
		Debug.Log( "wwwCallbackFunction" ) ;
		if( null == m_WWWObj )
		{
			Debug.LogError( "null == download" ) ;
		}
		else
		{
			
            AssetBundle assetBundle = null ;
			
			// Try mark this line, you will find you can't load the scene.
			assetBundle = m_WWWObj.assetBundle;
			
			if( null == assetBundle )
			{
				Debug.Log( "null == assetBundle" ) ;
			}
			else
			{
				Debug.Log( "null != assetBundle" ) ;
				Application.LoadLevel( m_SceneNameInBundle ) ;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_WWWObj )
		{
			m_ProgressNow = m_WWWObj.progress ;
		}		
	
	}
	
	
	public Rect m_ProgressBarRect = new Rect( 200 , 20 , 600 , 50 ) ;
	public float m_ProgressNow = 0 ;
	void OnGUI()
	{
		// Debug.Log( m_ProgressNow ) ;
		GUI.HorizontalSlider( m_ProgressBarRect , m_ProgressNow * 100 , 0 , 100 ) ;
	}	
}
