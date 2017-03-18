// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "SolarSystem/Planet(Simple)" {

	Properties {
		_MainTex("Texture", 2D) = "black" {}
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_SurfaceShininess("Surface Shininess", Float) = 1.0
		_SurfaceFalloff("Surface Falloff", Float) = 1.0
	}
	
	SubShader {
		Tags { "RenderType" = "Opaque" }
		
		Pass {
			Tags { "LightMode" = "ForwardAdd" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			uniform sampler2D _MainTex;
			uniform half4 _Color;
        	uniform half _SurfaceFalloff;
        	uniform half _SurfaceShininess;
        	uniform fixed4 _LightColor0;
			
			struct vertexInput {
				half4 vertex : POSITION;
				half3 normal : NORMAL;
				half4 texcoord : TEXCOORD0;
			};
			struct vertexOutput {
				half4 pos : SV_POSITION;
				half4 tex : TEXCOORD0;
			};
			
			vertexOutput vert(vertexInput v) {
				vertexOutput o;
				
				half3 normalDir = normalize (mul (unity_ObjectToWorld, half4 (v.normal,0)).xyz);
				half3 viewDir = normalize (_WorldSpaceCameraPos.xyz - mul (unity_ObjectToWorld, v.vertex));
				half3 lightDir = normalize (mul (unity_ObjectToWorld, v.vertex) - _WorldSpaceLightPos0.xyz);
				
				half atmo;
				half light = saturate (dot (normalDir, -lightDir));
            	atmo = saturate (pow (1.0 - dot (viewDir, normalDir), _SurfaceFalloff) * _SurfaceShininess);
            	
            	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.tex = v.texcoord;
				o.tex.zw = half2 (light, atmo);
				
				return o;
			}
			
			half4 frag(vertexOutput i) : Color {
				
				half4 tex = saturate(tex2D (_MainTex, i.tex.xy));
				
				return lerp (tex, _Color, i.tex.w) * i.tex.z * _LightColor0;
			}
			
			ENDCG
		}
		
	}
	
	Fallback "Diffuse"
}