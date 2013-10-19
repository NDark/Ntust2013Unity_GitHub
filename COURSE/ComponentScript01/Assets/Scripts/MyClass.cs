using UnityEngine;
using System.Collections;

public class MyClass 
{
	public void CallFunc()
	{
		Debug.Log( "XD" ) ;
		GameObject obj = GameObject.Find( "GlobalSingleton" );
		if( null != obj )
		{
			Debug.Log( obj ) ;
		}
	}

}