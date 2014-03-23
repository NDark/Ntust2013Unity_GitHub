/**
 * @file AgentManager.cs
 * @author NDark
 * @date 20140322 . file started.
 */
using UnityEngine;
using System.Collections.Generic;

public class AgentManager : MonoBehaviour 
{
	private List<AgentBase> m_Agents = new List<AgentBase>() ;

	// Use this for initialization
	void Start () 
	{
		// Character_TestObj1
		InfoDataCenter infoDataCenter = GlobalSingleton.GetInfoDataCenter() ;
		infoDataCenter.WriteProperty( "CHARACTER_TestObj1" , "OBJECT_NAME" , "Character_TestObj1" ) ;
		AgentBase addAgent = new AgentBase( "TestObj1" ) ;
		infoDataCenter.WriteProperty( "CHARACTER_TestObj1" , "STATE" , "Condition" ) ;
		infoDataCenter.WriteProperty( "CHARACTER_TestObj1" , "ASSIGNMENT" , "GOTOTARGET" ) ;
		infoDataCenter.WriteProperty( "CHARACTER_TestObj1" , "TARGET_POSITION" , "5,0,0" ) ;
		m_Agents.Add( addAgent ) ;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		foreach( AgentBase agent in m_Agents )
		{
			agent.DoUpdate() ;
		}
	}
}
