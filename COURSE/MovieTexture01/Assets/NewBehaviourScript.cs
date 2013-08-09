using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		MovieTexture mt = (MovieTexture) renderer.material.mainTexture ;
		mt.Play() ;
		this.audio.Play() ;
	}
}
