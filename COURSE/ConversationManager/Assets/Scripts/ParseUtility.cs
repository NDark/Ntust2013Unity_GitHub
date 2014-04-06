/*
@file ParseUtility.cs
@author NDark
@date 20140329 . file created.
*/
#define USE_XML
// #define USE_XML
using UnityEngine;
#if USE_XML
using System.Xml ;
#endif // USE_XML

public static class ParseUtility  
{
	public static bool ParseMapStaticObject( 
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

}
