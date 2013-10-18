Shader "DiscardShader" {
   Properties {
      _MainTex ("RGBA Texture Image", 2D) = "white" {} 
   }
   SubShader {
      Pass {    
         //Cull Off // since the front is partially transparent, 
            // we shouldn't cull the back
 
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag 
 
         uniform sampler2D _MainTex;    
 
         struct vertexInput {
            float4 vertex : POSITION;
            float4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float4 tex : TEXCOORD0;
            float2 screenPos : TEXCOORD5;
         };
 
         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;
 
 			float4 clipSpace = mul (UNITY_MATRIX_MVP, input.vertex );
 			
 			// to -1 ~ 1 
 			clipSpace.xy /= clipSpace.w;
 			
 			// we don't normalize to screen coordiate
 			// p.xy = 0.5*(p.xy+1.0) * _ScreenParams.xy;
 			output.screenPos = clipSpace.xy ;
	
            output.tex = input.texcoord;
            output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR
         {
            float4 textureColor = tex2D(_MainTex, float2(input.tex));  
            
            float distanceFromCenter = length( input.screenPos ) ;
            if( distanceFromCenter > 1 )
            {
            	discard;
            }
            
            return textureColor;
         }
 
         ENDCG
      }
   }
 
   // The definition of a fallback shader should be commented out 
   // during development:
   // Fallback "Unlit/Transparent Cutout"
}