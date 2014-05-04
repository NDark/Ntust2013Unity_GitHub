/**
 * @file Skill.cs
 * @author NDark
 * @date 20140405 file started.
@date 20140427 by NDark . add class SkillLabel

 */
using UnityEngine;

public class Skill
{
	public string Label
	{
		get { return m_Label ; }
		set { m_Label = value ; }
	}
	private string m_Label = "" ;
	
	public string Type
	{
		get { return m_Type ; }
		set { m_Type = value ; }
	}
	private string m_Type = "" ;	
	
	
	public string Target
	{
		get { return m_Target ; }
		set { m_Target = value ; }
	}
	private string m_Target = "" ;
	
	public string DefenseProperty
	{
		get { return m_DefenseProperty ; }
		set { m_DefenseProperty = value ; }
	}
	private string m_DefenseProperty = "" ;	
	
	public string AttactProperty
	{
		get { return m_AttactProperty ; }
		set { m_AttactProperty = value ; }
	}
	private string m_AttactProperty = "" ;	
		
	public string FyingSpeed
	{
		get { return m_FyingSpeed ; }
		set { m_FyingSpeed = value ; }
	}
	private string m_FyingSpeed = "" ;	

	public string AnimationPrefab
	{
		get { return m_AnimationPrefab ; }
		set { m_AnimationPrefab = value ; }
	}
	private string m_AnimationPrefab = "" ;	
	
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
