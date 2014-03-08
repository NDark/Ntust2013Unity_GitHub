/**
 * @file Story.cs
 * @author NDark
 * @date20140308 file started.
 */
using UnityEngine;
using System.Collections.Generic ;

public enum ConversationManagerState
{
	UnActive = 0 ,
	Starting ,
	WaitEnd ,
	WaitForInput , 
	Closing ,
	Close ,
} ;

public class ConversationManager : MonoBehaviour 
{
	public ConversationManagerState State
	{
		get { return m_State ; }
	}
	private ConversationManagerState m_State = ConversationManagerState.UnActive ;
	private int m_CurrentStoryUID = 0 ;
	private int m_CurrentTakeUID = 0 ;
	private float m_StartTime = 0.0f ;
	private List<Story> m_Stories = new List<Story>() ;
	private List<Take> m_Takes = new List<Take>() ;
	private List<int> m_StartingQueue = new List<int>() ;
	
	public void ActiveConversation( int _StoryUID )
	{

	}
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_State )
		{
		case ConversationManagerState.UnActive :
			CheckQueue() ;
			break ;
		case ConversationManagerState.Starting :
			ShowDialogUI( true ) ;
			break ;
		case ConversationManagerState.WaitEnd :
			break ;
		case ConversationManagerState.WaitForInput :
			if( true == CheckIfPress() )
			{
				PlayNext() ;
			}
			break ;
		case ConversationManagerState.Closing :
			ShowDialogUI( false ) ;
			break ;
		case ConversationManagerState.Close :
			m_State = ConversationManagerState.UnActive ;
			break ;			
		}
	
	}
	
	private bool CheckIfPress()
	{
		bool ret = false ;
		return ret ; 
	}
	
	private void PlayNext()
	{
		ShowDialogUI( true ) ;
		m_State = ConversationManagerState.WaitEnd ;
	}	
	
	private void ShowDialogUI( bool _Show )
	{
		
	}
	
	private void CheckQueue()
	{
		
	}
}

