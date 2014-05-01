using UnityEngine;
using System.Collections;

public class GUI_ClickFastForward : MonoBehaviour 
{
	float m_StartPhyTime = 0.0f ;

	// Use this for initialization
	void Start () 
	{
		m_StartPhyTime = Time.fixedDeltaTime ;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Time.timeScale = 10 ;
		Time.fixedDeltaTime = m_StartPhyTime * Time.timeScale;
	}
}
