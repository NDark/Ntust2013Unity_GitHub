/*
@file EditorWindow02.cs
@author NDark

Attention!!!!
Script must be placed in the folder called "Editor" in Assets

@date 20130819 file started.
*/
using UnityEngine;
using UnityEditor ; // add this for editor
	
// You don't have to put script on GameObject
public class EditorWindow02 : EditorWindow 
{
	[MenuItem ("Window/My Window 2")]
    static void ShowWindow () 
	{
        EditorWindow.GetWindow<EditorWindow02>() ;
    }		

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public enum EnumTest
	{
		On,
		Off ,
	}
	public EnumTest m_EnumTest1 = EnumTest.On ;
	public EnumTest m_EnumTest2 = EnumTest.On ;
	public Bounds m_Bound = new Bounds( Vector3.zero , new Vector3( 1 , 1 , 1 ) ) ;
	public Color m_Color = Color.white ;
	public AnimationCurve m_AnimationCurve = new AnimationCurve() ;
	public float m_FloatValue = 0 ;
	public int m_IntValue = 0 ;
	public bool m_FoldOut1 = false ;
	public bool m_FoldOut2 = false ;
	public int m_IntPopupSelectValue = 0 ;
	string [] m_DisplayOption = { "Plan A" , "Plan B" } ;
	int [] m_DisplayOptionValue = { 0 , 1 } ;
	
	
	
	public int m_IntSliderValue = 0 ;
	public float m_MinSliderValue = 0 ;
	public float m_MaxSliderValue = 0 ;
	public int m_LayerValue = 0 ;
	public int m_MaskValue = 0 ;
	
	public GameObject m_SelectObj = null ;
	// the content of your window draw here.
	void OnGUI()
	{
		// HelpBox
		EditorGUILayout.HelpBox( "Help Box MessageType.Error" , MessageType.Error ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.Info" , MessageType.Info ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.None" , MessageType.None ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.Warning" , MessageType.Warning ) ;
		
		EditorGUILayout.LabelField( "This is a label" ) ;
		EditorGUILayout.LabelField( "The Lord of the Rings" , "The Fellowship of the Ring." ) ;
		
		m_Bound = EditorGUILayout.BoundsField( "This is Bound , James Bound." , m_Bound ) ;
		
		m_Color = EditorGUILayout.ColorField( "ColorField" , m_Color ) ;
		
		m_AnimationCurve = EditorGUILayout.CurveField( "Animation Curve" , m_AnimationCurve ) ;
		
		m_EnumTest1 = (EnumTest) EditorGUILayout.EnumMaskField( "Enum Mask Field" , m_EnumTest1 ) ;
		
		m_EnumTest2 = (EnumTest) EditorGUILayout.EnumPopup( "Enum Pop Up" , m_EnumTest2 ) ;
		
		m_FloatValue = EditorGUILayout.FloatField( "Float Field" , m_FloatValue ) ;
		
		if( true == ( m_FoldOut1 = EditorGUILayout.Foldout( m_FoldOut1 , "Fold Out" ) ) )
		// m_FoldOut = EditorGUILayout.Foldout( m_FoldOut , "Fold Out" ) ;
		{
			m_IntValue = EditorGUILayout.IntField( "IntValue" , m_IntValue ) ;
		
			m_IntPopupSelectValue = EditorGUILayout.IntPopup( m_IntPopupSelectValue , m_DisplayOption , m_DisplayOptionValue ) ;
			
			m_MaskValue = EditorGUILayout.MaskField( "This is a mask" , m_MaskValue , m_DisplayOption ) ;
			
			EditorGUILayout.IntField( "m_MaskValue" , m_MaskValue ) ;			
		}
		
		if( 0 != Selection.objects.Length )
		{
			if( true == ( m_FoldOut2 = EditorGUILayout.InspectorTitlebar( m_FoldOut2 , Selection.objects ) ) )
			{
				m_IntSliderValue = EditorGUILayout.IntSlider( m_IntSliderValue , 0 , 10 ) ;
				
				m_LayerValue = EditorGUILayout.LayerField( "This is a layer" , m_LayerValue ) ;
				
				EditorGUILayout.MinMaxSlider( ref m_MinSliderValue , ref m_MaxSliderValue , 10 , 100 ) ;
				
				EditorGUILayout.FloatField( "m_MinSliderValue" , m_MinSliderValue ) ;
				
				EditorGUILayout.FloatField( "m_MaxSliderValue" , m_MaxSliderValue ) ;
				
			}
			
		}
		
		if( null != Selection.activeObject )
			m_SelectObj = (GameObject) EditorGUILayout.ObjectField( Selection.activeObject , typeof(GameObject) ) ;
	
		
	}

}
