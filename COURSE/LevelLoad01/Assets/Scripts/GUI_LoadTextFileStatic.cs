/*
IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 

By downloading, copying, installing or using the software you agree to this license.
If you do not agree to this license, do not download, install, copy or use the software.

    License Agreement For Kobayashi Maru Commander Open Source

Copyright (C) 2013, Chih-Jen Teng(NDark) and Koguyue Entertainment, 
all rights reserved. Third party copyrights are property of their respective owners. 

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

  * Redistribution's of source code must retain the above copyright notice,
    this list of conditions and the following disclaimer.

  * Redistribution's in binary form must reproduce the above copyright notice,
    this list of conditions and the following disclaimer in the documentation
    and/or other materials provided with the distribution.

  * The name of Koguyue or all authors may not be used to endorse or promote products
    derived from this software without specific prior written permission.

This software is provided by the copyright holders and contributors "as is" and
any express or implied warranties, including, but not limited to, the implied
warranties of merchantability and fitness for a particular purpose are disclaimed.
In no event shall the Koguyue or all authors or contributors be liable for any direct,
indirect, incidental, special, exemplary, or consequential damages
(including, but not limited to, procurement of substitute goods or services;
loss of use, data, or profits; or business interruption) however caused
and on any theory of liability, whether in contract, strict liability,
or tort (including negligence or otherwise) arising in any way out of
the use of this software, even if advised of the possibility of such damage.  
*/
/*
@file GUI_LoadTextFileStatic.cs
@author NDark

讀檔並顯示檔案內的字串
注意,顯示了之後此物件不會隨著關卡讀取而消失.

@date 20130814 file started. and derived from GUI_DisplayVersionInfo of Kobayashi Maru Commander Open Project

*/
using UnityEngine;

public class GUI_LoadTextFileStatic : MonoBehaviour 
{
	public bool m_DontDestroy = true ;
	public string m_Filepath = "" ;
	
	// Use this for initialization
	void Start () 
	{
		if( 0 == m_Filepath.Length )
			return ;
		
		string content = LoadToString( m_Filepath ) ;
		
		if( null != this.GetComponent<GUIText>() )
		{
			this.GetComponent<GUIText>().text = content ;
		}
		
		// @todo This object should not be created twice
		if( true == m_DontDestroy )
		{
			Object.DontDestroyOnLoad( this.gameObject ) ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	public static string LoadToString( string _Filepath )
	{
		string ret = "" ;
		if( 0 == _Filepath.Length )
			return ret ;
		
		TextAsset textAsset = (TextAsset) Resources.Load( _Filepath ) ;
		if( null != textAsset )
		{
			ret = textAsset.text ;
		}
		return ret;
	}		
}
