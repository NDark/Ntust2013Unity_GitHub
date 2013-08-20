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
	public int m_IntPopupOptionValue = 0 ;
	string [] m_DisplayOption = { "Plan A" , "Plan B" } ;
	int [] m_DisplayOptionValue = { 3 , 4 } ;
	
	public int m_GenericPopupIndexValue = 0 ;
	
	
	
	public int m_IntSliderValue = 0 ;
	public float m_MinSliderValue = 0 ;
	public float m_MaxSliderValue = 0 ;
	public int m_LayerValue = 0 ;
	public string m_TagStr = "" ;
	public int m_MaskValue = 0 ;
	
	public float m_FloatSliderValue = 0 ;
	
	public Transform m_SelectTransform = null ;
	
	public string m_PasswordString = "" ;
		
	public Rect m_RectFieldValue = new Rect( 0 , 0 , 100 , 200 ) ;
	
	public string m_TextAreaContent ;
	public string m_TextFieldContent ;
	
	public Vector2 m_Vector2 = Vector2.right ;
	public Vector3 m_Vector3 = Vector3.forward ;
	public Vector4 m_Vector4 = Vector4.one ;
	

	public bool m_Toggle = false ;
	// the content of your window draw here.
	void OnGUI()
	{
		// HelpBox
		EditorGUILayout.HelpBox( "Help Box MessageType.Error" , MessageType.Error ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.Info" , MessageType.Info ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.None" , MessageType.None ) ;
		EditorGUILayout.HelpBox( "Help Box MessageType.Warning" , MessageType.Warning ) ;
		
		EditorGUILayout.Space() ;
		
		EditorGUILayout.LabelField( "This is a label, the length is unlimited." ) ;
		EditorGUILayout.LabelField( "The Lord of the Rings" , "The Fellowship of the Ring." ) ;
		EditorGUILayout.PrefixLabel( "Prefix Label , the same as LabelField at EditorGUILayout" ) ;
		EditorGUILayout.SelectableLabel( "Selectable Label, Select me please." ) ;
		
		
		
		m_Bound = EditorGUILayout.BoundsField( "This is Bound , James Bound." , m_Bound ) ;
		
		m_RectFieldValue = EditorGUILayout.RectField( "RectField" ,  m_RectFieldValue ) ;
			
		
		EditorGUILayout.Separator() ;
		
		m_Vector2 = EditorGUILayout.Vector2Field( "Vector2" , m_Vector2 ) ;
		m_Vector3 = EditorGUILayout.Vector3Field( "Vector3" , m_Vector3 ) ;
		m_Vector4 = EditorGUILayout.Vector4Field( "Vector4" , m_Vector4 ) ;
			
		EditorGUILayout.Separator() ;
		
		m_Color = EditorGUILayout.ColorField( "ColorField" , m_Color ) ;
		
		m_AnimationCurve = EditorGUILayout.CurveField( "Animation Curve" , m_AnimationCurve ) ;
		
		m_EnumTest1 = (EnumTest) EditorGUILayout.EnumMaskField( "Enum Mask Field" , m_EnumTest1 ) ;
		
		m_EnumTest2 = (EnumTest) EditorGUILayout.EnumPopup( "Enum Pop Up" , m_EnumTest2 ) ;
		
		m_FloatValue = EditorGUILayout.FloatField( "Float Field" , m_FloatValue ) ;
		
		EditorGUILayout.Separator() ;
		
		if( true == ( m_FoldOut1 = EditorGUILayout.Foldout( m_FoldOut1 , "Fold Out" ) ) )
		// m_FoldOut = EditorGUILayout.Foldout( m_FoldOut , "Fold Out" ) ;
		{
			
		
			m_IntPopupOptionValue = EditorGUILayout.IntPopup( "IntPopup" , 
															  m_IntPopupOptionValue , 
															  m_DisplayOption , 
															  m_DisplayOptionValue ) ;
			EditorGUILayout.IntField( "IntPopup Value" , m_IntPopupOptionValue ) ;
			
			
			m_GenericPopupIndexValue = EditorGUILayout.Popup( "Popup" , m_GenericPopupIndexValue , m_DisplayOption ) ;			
			EditorGUILayout.IntField( "Popup Value" , m_GenericPopupIndexValue ) ;
			
				
			m_MaskValue = EditorGUILayout.MaskField( "This is a mask" , m_MaskValue , m_DisplayOption ) ;
			
			EditorGUILayout.IntField( "m_MaskValue" , m_MaskValue ) ;			
		}
		
		EditorGUILayout.Separator() ;
		
		if( 0 != Selection.objects.Length )
		{
			if( true == ( m_FoldOut2 = EditorGUILayout.InspectorTitlebar( m_FoldOut2 , Selection.objects ) ) )
			{
				m_IntSliderValue = EditorGUILayout.IntSlider( m_IntSliderValue , 0 , 10 ) ;
				
				m_FloatSliderValue = EditorGUILayout.Slider( m_FloatSliderValue , -5.0f , 5.0f ) ;
					
				m_LayerValue = EditorGUILayout.LayerField( "This is a layer" , m_LayerValue ) ;
				
				m_TagStr = EditorGUILayout.TagField( "This is a tag" , m_TagStr ) ;
				
				EditorGUILayout.MinMaxSlider( ref m_MinSliderValue , ref m_MaxSliderValue , 10 , 100 ) ;
				
				EditorGUILayout.FloatField( "m_MinSliderValue" , m_MinSliderValue ) ;
				
				EditorGUILayout.FloatField( "m_MaxSliderValue" , m_MaxSliderValue ) ;
				
			}
		}
		
		EditorGUILayout.Separator() ;
		
		if( null != Selection.activeObject )
		{
			m_SelectTransform = (Transform) 
				EditorGUILayout.ObjectField( "ObjectField" ,
					Selection.activeTransform , 
					typeof(Transform) ) ;
		}
	
		EditorGUILayout.Separator() ;
		
		m_PasswordString = EditorGUILayout.PasswordField( m_PasswordString ) ;
		EditorGUILayout.LabelField( "Password String" , m_PasswordString ) ;
		
		EditorGUILayout.Separator() ;
	
		if( true == ( m_Toggle = EditorGUILayout.Toggle( "Toggle TextField&TextArea" , m_Toggle ) ) )
		{
			m_TextAreaContent = EditorGUILayout.TextArea( m_TextAreaContent , GUILayout.Height( 60) ) ;
			m_TextFieldContent = EditorGUILayout.TextField( "TextField"  , m_TextFieldContent , GUILayout.Height( 60) ) ;
		}
	
		
	}

}
