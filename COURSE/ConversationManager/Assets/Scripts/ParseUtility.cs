/*
@file ParseUtility.cs
@author NDark
@date 20140329 . file created.
@date 20140412 by NDark 
. add class method ParseUnitDataTemplateData()
. add argument of _UnitDataTemplateName at ParseUnit()
@date 20140427 by NDark
. add class method ParseSkillSetting()
. add class method ParseExistUnit()

*/
#define USE_XML
// #define USE_XML
using UnityEngine;
using System.Collections.Generic ;
#if USE_XML
using System.Xml ;
#endif // USE_XML

public static class ParseUtility  
{
	public static bool ParseStaticObject( 
	                                      #if USE_XML
	                                      XmlNode _node ,
	                                      #endif // USE_XML
	                                      
	                                      ref string _unitName ,
	                                      ref string _prefabTemplateName , 
	                                      ref Vector3 _position , 
	                                      ref Quaternion _orientation )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.CheckAndParseStaticObject( _node , 
		                                                  ref _unitName ,
		                                                  ref _prefabTemplateName , 
		                                                  ref _position , 
		                                                  ref _orientation ) ;
		return ret ;
		#endif // USE_XML
	}

	public static bool ParseMapZoneObject( 
#if USE_XML
	                              XmlNode _node ,
#endif // USE_XML

	                               ref string _unitName ,
	                              ref string _prefabTemplateName , 
	                              ref Vector3 _position , 
	                              ref Quaternion _orientation , 
	                                      ref string _TextureName )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.CheckAndParseMapZoneObject( _node , 
		                                                   ref _unitName ,
		                                                           ref _prefabTemplateName , 
		                                                           ref _position , 
		                                                           ref _orientation ,
		                                                           ref _TextureName ) ;


		return ret ;
		#endif // USE_XML
	}

	public static bool ParseUnit( 
	                                      #if USE_XML
	                                      XmlNode _node ,
	                                      #endif // USE_XML
	                             ref string _UnitName , 
	                             ref string _PrefabeName ,
	                             ref string _UnitDataTemplateName ,
	                             ref PosAnchor _PosAnchor , 
	                             ref Quaternion _Orientation ,
	                             ref Dictionary<string , StandardParameter> _StandardParamMap )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.ParseUnit( _node , 
		                                          ref  _UnitName , 
		                                          ref _PrefabeName ,
		                                          ref _UnitDataTemplateName ,
		                                          ref _PosAnchor , 
		                                          ref _Orientation ,
		                                          ref _StandardParamMap ) ;
		
		
		return ret ;
		#endif // USE_XML
	}

	public static bool ParseUnitDataTemplateData( 
	                                     #if USE_XML
	                                     XmlNode _node ,
	                                     #endif // USE_XML
                                         ref string _UnitDataTemplateName ,
	                                             ref UnitDataSetting _DataSetting )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.ParseUnitDataTemplateData( _node , 
		                                                          ref _UnitDataTemplateName ,
		                                                          ref _DataSetting ) ;
		return ret ;
		#endif // USE_XML
	}

	public static bool ParseSkillSetting( 
	                                     #if USE_XML
	                                     XmlNode _node ,
	                                     #endif // USE_XML
	                                     ref string _SkillName ,
	                                     ref SkillSetting _SkillSetting )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.ParseSkillSetting( _node , 
		                                                  ref _SkillName ,
		                                                  ref _SkillSetting ) ;
		return ret ;
		#endif // USE_XML
	}

	public static bool ParseExistUnit( 
	                             #if USE_XML
	                             XmlNode _node ,
	                             #endif // USE_XML
	                             ref string _UnitName , 
	                             ref string _UnitDataTemplateName )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.ParseExistUnit( _node , 
		                                          ref  _UnitName , 
		                                          ref _UnitDataTemplateName ) ;
		
		
		return ret ;
		#endif // USE_XML
	}

	public static bool ParseUnitDataStruct( 
	                                  #if USE_XML
	                                  XmlNode _node ,
	                                  #endif // USE_XML
	                                  ref string _UnitName , 
	                                  ref string _UnitDataTemplateName )
	{
		#if USE_XML
		bool ret = XMLParseLevelUtility.ParseUnitDataStruct( _node , 
		                                               ref  _UnitName , 
		                                               ref _UnitDataTemplateName ) ;
		
		
		return ret ;
		#endif // USE_XML
	}
}
