/*
@file FollowTargetByNavMesh01.cs
@author NDark
@date 20130809 by NDark
*/
using UnityEngine;

public class FollowTargetByNavMesh01 : MonoBehaviour 
{
	
	public GameObject m_TargetObj = null ;
	public UnityEngine.AI.NavMeshAgent m_NavMeshAgent = null ;
	// Use this for initialization
	void Start () 
	{
		m_NavMeshAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>() ;
		if( null == m_NavMeshAgent )
		{
			Debug.LogError( "null == m_NavMeshAgent )" ) ;
			return ;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( null == m_TargetObj || 
			null == m_NavMeshAgent )
			return ;
		
		m_NavMeshAgent.SetDestination( m_TargetObj.transform.position ) ;
	
	}
}
