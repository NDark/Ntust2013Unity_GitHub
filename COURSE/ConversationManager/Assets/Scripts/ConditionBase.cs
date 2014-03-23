/**
 * @file ConditionBase.cs
 * @author NDark
 * @date 20140322 . file started.
 */
using UnityEngine;

public class ConditionBase 
{
	public string Type
	{
		get { return m_Type ; } 
		set { m_Type = value ; }
	}
	private string m_Type = "" ;

	public virtual void DoCondition()
	{

	}
}
