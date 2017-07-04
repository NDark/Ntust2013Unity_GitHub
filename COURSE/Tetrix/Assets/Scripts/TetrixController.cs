using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TetrixController : MonoBehaviour 
{
	public GameObject m_Block = null ;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Time.time < m_NextCount )
		{
			return ;
		}
		
		m_NextCount = Time.time + m_CountInterval ;
		
		UpdateBlockDownward() ;
		
	}
	
	void UpdateBlockDownward()
	{
		Vector3 pos = m_Block.transform.position ;
		pos.y -= 1 ;
		m_Block.transform.position = pos ;
	}
	
	float m_NextCount = 0.0f ;
	float m_CountInterval = 1.0f ;
}
