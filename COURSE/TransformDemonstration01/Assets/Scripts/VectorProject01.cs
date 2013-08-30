/*
@file VectorProject01.cs
@author NDark

http://docs.unity3d.com/Documentation/ScriptReference/Vector3.Project.html

@date 20130831 . file started.
 */
using UnityEngine;

public class VectorProject01 : MonoBehaviour 
{
	public Vector3 m_ThisVec = Vector3.zero ;
	public GameObject m_Ladder = null ;
	public GameObject m_ProjectSphere = null ;
	// Use this for initialization
	void Start () 
	{
		m_Ladder = GameObject.Find("Ladder") ;
		m_ProjectSphere = GameObject.Find("ProjectSphere") ;		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null != m_ProjectSphere && 
			null != m_Ladder )
		{
			m_ThisVec = this.gameObject.transform.position - m_Ladder.transform.position ;
			
			Vector3 projectVec = Vector3.Project( m_ThisVec , m_Ladder.transform.forward ) ;
			Vector3 projectPos = m_Ladder.transform.position + projectVec ;
			
			m_ProjectSphere.transform.position = projectPos ;
		}
	
	}
}
