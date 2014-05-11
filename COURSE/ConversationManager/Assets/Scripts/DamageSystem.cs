/**
@file DamageSystem.cs
@author NDark
@date 20140510 . file started.
*/
using UnityEngine;
using System.Collections.Generic;

public class DamageSystem : MonoBehaviour 
{

	public void Encounter( GameObject _Skill , GameObject _Target )
	{
		Debug.Log( "_SkillObj.name=" + _Skill.name ) ;
		Debug.Log( "_TargetObj.name=" + _Target.name ) ;
		
		SkillAnimation sourceSkillAnim = _Skill.GetComponent<SkillAnimation>() ;
		if( null == sourceSkillAnim )
		{
			Debug.Log( "null == sourceSkillAnim" ) ;
			return ;
		}
		
		UnitData unitData = _Target.GetComponent<UnitData>() ;
		if( null == unitData )
		{
			Debug.Log( "null == unitData" ) ;
			SkillAnimation skillAnim = _Target.GetComponent<SkillAnimation>() ;
			if( null == skillAnim )
			{
				Debug.Log( "null == skillAnim" ) ;
			}
			else
			{
				Debug.Log( "target is skill" ) ;
				SkillDamage( sourceSkillAnim.m_SkillVariable.m_SkillPropertyNow , skillAnim.m_SkillVariable.m_SkillPropertyNow ) ;
			}
		}
		else
		{
			Debug.Log( "target is player" ) ;
			PlayerDamage( sourceSkillAnim , unitData ) ;
		}
	}
	
	public void PlayerDamage( SkillAnimation _SkillAnim , UnitData _DefenderUnitData )
	{
		Debug.Log( "PlayerDamage()" ) ;
		if( null == _SkillAnim || 
		   null == _DefenderUnitData )
		{
			return ;
		}
		
		int hpNow = 0 ;
		Dictionary< string , StandardParameter > standardParamTable = 
			_DefenderUnitData.m_UnitDataStruct.GetStandardParameterTable() ;			
		if( true == standardParamTable.ContainsKey( "HP" ) )
		{
			hpNow = (int)standardParamTable[ "HP" ].now ;
		}
		
		bool IsDamageToHP = false ;		
		int totalDamagetoHP = 0 ;
		EnegyProperty attactProperty = _SkillAnim.m_SkillVariable.m_SkillPropertyNow.AttackProperty ;
		EnegyProperty defenseProperty = _DefenderUnitData.m_UnitDataStruct.DefenseProperty ;
		Debug.Log( "_Attacker.attacktSkillProperty=" + attactProperty.CreatePropertyString() ) ;
		Debug.Log( "_Defender.defenseProperty=" + defenseProperty.CreatePropertyString() ) ;
		
		string [] keys = attactProperty.GetKeys() ;
		for( int i = 0 ; i < keys.Length ; ++i )
		{
			int attackPower = attactProperty.GetProperty( keys[ 0 ] ) ;
			Debug.Log( "attackPower" + attackPower ) ;
			int attckPowerRemain = 
				defenseProperty.AddPropertyToArmor( keys[ 0 ] , -attackPower ) ;
			
			Debug.Log( "attckPowerRemain=" + attckPowerRemain ) ;
			attactProperty.AssignProperty( keys[ 0 ] , attckPowerRemain ) ;
			
			Debug.Log( "_Attacker.AttackProperty for " + keys[ 0 ] + " = " + 
			          attactProperty.GetProperty( keys[ 0 ] ) ) ;
			Debug.Log( "_Defender.DefenseProperty for " + keys[ 0 ] + " = " + 
						defenseProperty.GetProperty( keys[ 0 ] ) ) ;
			
			if( attckPowerRemain > 0 )
			{
				IsDamageToHP = true ;
				int damageToHP = attckPowerRemain ;
				
				if( true == standardParamTable.ContainsKey( "HP" ) )
				{
					hpNow = (int)standardParamTable[ "HP" ].now ;
					if( hpNow > attckPowerRemain )
					{
						hpNow -= damageToHP ;
						totalDamagetoHP += damageToHP ;
						attactProperty.AssignProperty( keys[ 0 ] , 0 ) ;
					}
					else
					{
						totalDamagetoHP += hpNow ;
						attckPowerRemain = attckPowerRemain - hpNow ;
						attactProperty.AssignProperty( keys[ 0 ] , attckPowerRemain ) ;
						hpNow = 0 ;
					}
						
					standardParamTable[ "HP" ].now = hpNow ;
				}
			}
			
		
		}
		
		FightSystem fs = GlobalSingleton.GetFightSystem() ;
		if( true == IsDamageToHP )
		{
			string str = string.Format( "{0} 對 {1} 造成了 {2} 點傷害" , 
			                           _SkillAnim.m_ParentName , 
			                           _DefenderUnitData.gameObject.name , 
			                           totalDamagetoHP ) ;
			fs.AddStatus( str ) ;
			str = string.Format( "{0} 剩下 {1} 點生命值" , _DefenderUnitData.gameObject.name , hpNow ) ;
			fs.AddStatus( str ) ;	
		}
		else
		{
			string str = string.Format( "{0} 對 {1} 沒有造成傷害" , 
			                           _SkillAnim.m_ParentName , 
			                           _DefenderUnitData.gameObject.name ) ;
			fs.AddStatus( str ) ;
		}
			
	}
	
	public void SkillDamage( SkillProperty _Attacker , SkillProperty _Defender )
	{
		Debug.Log( "SkillDamage()" ) ;
		if( null == _Attacker || 
			null == _Defender )
		{
			return ;
		}
		
		// attacker 的 attack property 會被 defender 的 defense property 抵銷
		Debug.Log( "_Attacker.AttackProperty=" + _Attacker.AttackProperty.CreatePropertyString() ) ;
		Debug.Log( "_Defender.DefenseProperty=" + _Defender.DefenseProperty.CreatePropertyString() ) ;
		
		string [] keys = _Attacker.AttackProperty.GetKeys() ;
		for( int i = 0 ; i < keys.Length ; ++i )
		{
			int attackPower = _Attacker.AttackProperty.GetProperty( keys[ 0 ] ) ;
			Debug.Log( "attackPower" + attackPower ) ;
			int attckPowerRemain = 
				_Defender.DefenseProperty.AddPropertyToArmor( keys[ 0 ] , -attackPower ) ;
			
			Debug.Log( "attckPowerRemain" + attckPowerRemain ) ;
			_Attacker.AttackProperty.AssignProperty( keys[ 0 ] , attckPowerRemain ) ;
			
			
			Debug.Log( "_Attacker.AttackProperty for " + keys[ 0 ] + " = " + _Attacker.AttackProperty.GetProperty( keys[ 0 ] ) ) ;
			Debug.Log( "_Defender.DefenseProperty for " + keys[ 0 ] + " = " + _Defender.DefenseProperty.GetProperty( keys[ 0 ] ) ) ;
			
			
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
