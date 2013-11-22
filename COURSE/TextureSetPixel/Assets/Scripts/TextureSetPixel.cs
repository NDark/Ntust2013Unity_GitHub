/*
@file TextureSetPixel.cs
@author NDark
@date 20131121 file started.
*/
using UnityEngine;

public class TextureSetPixel : MonoBehaviour 
{
	public int m_Index = 0 ;
	public Texture2D m_Tex2D = null ;
	public Color m_SetColor = Color.white ;
	// Use this for initialization
	void Start () 
	{
		m_Tex2D = (Texture2D) this.guiTexture.texture ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_Tex2D )
			return ;
		
		GetNextIndex() ;
		for( int i = 0 ; i < m_Tex2D.width ; ++i )
		{
			m_Tex2D.SetPixel( i , m_Index  , m_SetColor ) ;
		}
		m_Tex2D.Apply() ; 
	}
	
	void GetNextIndex()
	{
		if( null == m_Tex2D )
			return ;
		++m_Index ;
		if( m_Index >= m_Tex2D.height ) 
		{
			m_Index = 0 ;
			m_SetColor = new Color( Random.Range( 0.0f , 1.0f )	,
									Random.Range( 0.0f , 1.0f )	,
									Random.Range( 0.0f , 1.0f )	) ;
		}
	}
}
