/**
 * @file Skill.cs
 * @author NDark
 * @date 20140405 file started.
@date 20140427 by NDark . add class SkillLabel

 */
using UnityEngine;

public class Skill
{
	public string DisplayString
	{
		get { return m_DisplayString ; }
		set { m_DisplayString = value ; }
	}
	private string m_DisplayString = "" ;
}

public class SkillLabel
{
	public string Label
	{
		get { return m_Label ; }
		set { m_Label = value ; }
	}
	private string m_Label = "" ;

	public string Value
	{
		get { return m_Value ; }
		set { m_Value = value ; }
	}
	private string m_Value = "" ;
}
