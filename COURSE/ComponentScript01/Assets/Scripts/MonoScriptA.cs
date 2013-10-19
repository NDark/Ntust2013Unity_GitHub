using UnityEngine;
using System.Collections;

public class MonoScriptA : MonoBehaviour 
{
	MyClass a = new MyClass() ;
	// Use this for initialization
	void Start () 
	{
		a.CallFunc() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
