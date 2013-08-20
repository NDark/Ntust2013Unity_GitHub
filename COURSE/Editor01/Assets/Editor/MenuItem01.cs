/**
@file MenuItem01.cs
@author NDark
@date 20130820 . file started
*/
using UnityEngine;
using UnityEditor;

public class MenuItem01 : MonoBehaviour 
{
	[MenuItem ("MyMenu/Do Anything") ]
	static void DoSomething() 
	{
		Debug.Log ("DoSomething.");
	}
	
	[MenuItem ("MyMenu/How many child object?") ]
	static void HowManyChildGameObject () 
	{
		if( null != Selection.activeTransform )
		{
			Transform[] transforms = Selection.activeTransform.gameObject.GetComponentsInChildren<Transform>() ;
			if( null != transforms )
			{
				Debug.Log ("Selected GameObject has " + transforms.Length + " children (include self).");
			}
		}
	}
	
	// The menu item will be disabled if this function returns false.
	[MenuItem ("MyMenu/The GameObject has rigidbody? %g" )]
	static void HasRigidbody () 
	{
		Rigidbody rigidbody = null ;
		if( null != Selection.activeTransform )
		{
			rigidbody = Selection.activeTransform.gameObject.GetComponentInChildren<Rigidbody>() ;
			if( null != rigidbody )
			{
				Debug.Log ("The GameObject has rigidbody.");
			}
			
		}
	}	
	
	// The menu item will be disabled if this function returns false.
	[MenuItem ("MyMenu/Attach basic Unit component" )]
	static void AttachBasicUnitComponent () 
	{
		if( null != Selection.activeTransform )
		{
			GameObject obj = Selection.activeTransform.gameObject ;
			if( null == obj.GetComponent( "GameUnitData02" ) )
				obj.AddComponent( "GameUnitData02" ) ;
			if( null == obj.GetComponent( "RegisterToMainUpdate03" ) )
				obj.AddComponent( "RegisterToMainUpdate03" ) ;
			if( null == obj.GetComponent( "GUI_UnitHP01" ) )
				obj.AddComponent( "GUI_UnitHP01" ) ;
			
		}
	}	
	
	// The menu item will be disabled if this function returns false.
	[MenuItem ("MyMenu/Clean All Components" )]
	static void CleanAllComponents () 
	{
		if( null != Selection.activeTransform )
		{
			GameObject obj = Selection.activeTransform.gameObject ;
			Component [] allComponents = obj.GetComponents<Component>() ;
			foreach( Component component in allComponents )
			{
				// can't use this
				// Component.Destroy( component ) ;
				Component.DestroyImmediate( component ) ;
			}
		}
	}		
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
