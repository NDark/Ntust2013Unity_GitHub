/*
@file ConditionEventFactory.cs
@author NDark
@date 20130816 file started.
*/
using UnityEngine;

[System.Serializable]
public static class ConditionEventFactory
{
	public static ConditionEvent GetByString( string _Name )
	{
		if( "ConditionEvent_PlayAudio" == _Name )
			return new ConditionEvent_PlayAudio() ;
		else if( "ConditionEvent_ShowAMessage" == _Name )
			return new ConditionEvent_ShowAMessage() ;
		else if( "ConditionEvent_ShowAGUIObj" == _Name  )
			return new ConditionEvent_ShowAGUIObj() ;
		else
			return null ;
	}

}
