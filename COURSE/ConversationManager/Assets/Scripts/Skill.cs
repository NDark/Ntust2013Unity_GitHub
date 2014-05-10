/**
@file Skill.cs
@author NDark
@date 20140405 file started.
@date 20140427 by NDark . add class SkillLabel
@date 20140510 by NDark 
. rename Skill to SkillSetting
. add class EnegyProperty
. add class SkillProperty
. add class SkillVariable
. add class method GetKeys()
. add class method AddPropertyToArmor()


 */
using UnityEngine;
using System.Collections.Generic;

// 能量屬性
public class EnegyProperty 
{
	
	public void Parse( string _Str )
	{
		string [] spliter1 = { "," } ;
		string [] propertyVec = _Str.Split( spliter1 , System.StringSplitOptions.None ) ;
		
		string [] spliter2 = { ":" } ;
		foreach( string propertyStr in propertyVec ) 
		{
			string [] propertyValue = propertyStr.Split( spliter2 , System.StringSplitOptions.None ) ;
			if( propertyValue.Length >= 2 )
			{
				// propertyValue[ 0 ] ;// label
				int value = 0 ;
				int.TryParse( propertyValue[ 1 ] , out value ) ;
				AddProperty( propertyValue[ 0 ] , value ) ;
			}
		}
	}

	public void Assign( EnegyProperty _Src ) 
	{
		Clear() ;
		Import( _Src ) ;
	}
	
	public void Clear() 
	{
		m_PropertyTable.Clear() ;
	}
		
	public void Import( EnegyProperty _Src ) 
	{
		Dictionary<string,int>.Enumerator i = _Src.m_PropertyTable.GetEnumerator() ;
		while( i.MoveNext() )
		{
			AssignProperty( i.Current.Key , i.Current.Value ) ;
		}
	}
	
	public string [] GetKeys()
	{
		string [] array = new string[ m_PropertyTable.Count ] ;
		m_PropertyTable.Keys.CopyTo( array , 0 ) ;
		return array ;
	}
	
	public int GetProperty( string _Key ) 
	{
		int ret = 0 ;
		if( true == m_PropertyTable.ContainsKey( _Key ) )
		{
			ret = m_PropertyTable[ _Key ] ;
		}		
		return ret ;
	}
	
	public int AddProperty( string _Key , int _Value ) 
	{
		int result = GetProperty( _Key ) + _Value ;
		AssignProperty( _Key , result ) ;
		return result ;	
	}		
	
	// return 的是攻擊能量還剩下多少
	public int AddPropertyToArmor( string _Key , int _Value ) 
	{
		int propertyValue = GetProperty( _Key ) ;
		int armorValue = GetProperty( "Armor" ) ;
		
		int retCost = armorValue + propertyValue + _Value ;
		int finalArmor = retCost ;
		if( _Value > 0 )
		{
			AssignProperty( _Key , propertyValue + _Value ) ;
			retCost = 0 ;
		}
		else
		{
			// armor 1 property 1 , _Value -10
			// final :
			// armor 0 , property 0 , _Value -8
					
			// 假如是扣的
			int costOnArmor = propertyValue + _Value ;
			if( costOnArmor > 0 )
			{
				// armor 10 property 2 , _Value -1
				// final :
				// armor 10 , property 1 , _Value 0				
				// 如果不動到armor
				retCost = 0 ;// 攻擊被抵消了
				AssignProperty( _Key , costOnArmor ) ;
			}
			else if( finalArmor > 0 ) 
			{
				// armor 10 property 2 , _Value -3
				// final :
				// armor 9 , property 0 , _Value 0 			
				// armor 要修改
				retCost = 0 ;// 攻擊被抵消了
				AssignProperty( _Key , 0 ) ;
				AssignProperty( "Armor" , finalArmor ) ;
			}
			else
			{
				// armor 10 property 2 , _Value -100
				// final :
				// armor 0 , property 0 , _Value -88				
				// armor 也被扣光
				AssignProperty( _Key , 0 ) ;
				AssignProperty( "Armor" , 0 ) ;			
			}
			
		}		
		
		return -1 * retCost ;	
	}			
	
	public int AssignProperty( string _Key , int _Value ) 
	{
		int result = 0 ;
		if( false == m_PropertyTable.ContainsKey( _Key ) )
		{
			m_PropertyTable.Add( _Key , _Value ) ;
		}
		else
		{
			m_PropertyTable[ _Key ] = _Value ;
		}
		
		return result ;
	}	
	
	public int PositiveProperty()
	{
		int ret = 0 ;
		Dictionary<string,int>.Enumerator i = m_PropertyTable.GetEnumerator() ;
		while( i.MoveNext() )
		{
			if( i.Current.Value > 0 )
			{
				ret += i.Current.Value ;
			}
		}
		return ret ;
	}
	
	public string CreatePropertyString()
	{
		string property = "" ;
		string ret = "" ;
		Dictionary<string,int>.Enumerator i = m_PropertyTable.GetEnumerator() ;
		while( i.MoveNext() )
		{
			property = string.Format( "{0}:{1}" , i.Current.Key , i.Current.Value ) ;
			if( 0 == ret.Length )
			{
				ret = property ;
			}
			else
			{
				ret = ret + "," + property ;
			}
		}
		return ret ;
	}
		
	private Dictionary<string,int> m_PropertyTable = new Dictionary<string, int>() ;
}

// 技能屬性
public class SkillProperty
{
	public EnegyProperty DefenseProperty
	{
		get { return m_DefenseProperty ; }
		set { m_DefenseProperty.Assign( value ) ; }
	}	
	protected EnegyProperty m_DefenseProperty = new EnegyProperty() ;
	
	public EnegyProperty AttackProperty
	{
		get { return m_AttackProperty ; }
		set { m_AttackProperty.Assign( value ) ; }
	}	
	protected EnegyProperty m_AttackProperty = new EnegyProperty() ;	
}

// 設定
public class SkillSetting : SkillProperty
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

// 攜帶中技能變數
public class SkillVariable
{
	public SkillSetting m_SkillSetting = null ;
	public SkillProperty m_SkillPropertyNow = new SkillProperty() ;
	
	public bool HasArmor()
	{
		bool ret = false ;
		if( m_SkillPropertyNow.DefenseProperty.GetProperty( "Armor" ) > 0 )
		{
			ret = true ;
		}
		return ret ;
	}
	public bool HasAttactProperty()
	{
		bool ret = false ;
		if( m_SkillPropertyNow.AttackProperty.PositiveProperty() > 0 )
		{
			ret = true ;
		}
		else
		{
			Debug.Log( "AttackProperty.PositiveProperty=" + m_SkillPropertyNow.AttackProperty.PositiveProperty() ) ;
		}
			
		return ret ;
	}	
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
