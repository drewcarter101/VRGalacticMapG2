// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "SolarSystem/Ring" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_ShadowTex ("Texture", 2D) = "white" {}
		_Color ("Front Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_BackColor ("Back Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Light("Light", Vector) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			uniform sampler2D _MainTex;
			uniform sampler2D _ShadowTex;
			uniform fixed4 _Color;
			uniform fixed4 _BackColor;
			uniform fixed4 _Light;
			
			struct vertexInput {
				fixed4 vertex : POSITION;
				fixed3 normal : NORMAL;
				fixed4 texcoord : TEXCOORD0;
			};
			struct vertexOutput {
				fixed4 pos : SV_POSITION;
				fixed4 col : Color;
				fixed4 tex : TEXCOORD0;
			};
			
			vertexOutput vert(vertexInput v) {
				vertexOutput o;
				
				fixed3 normalDir = normalize (mul (unity_ObjectToWorld, float4 (v.normal,0)).xyz);
				fixed3 lightDir = normalize (_Light.xyz);
            	
            	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.tex = v.texcoord;
				o.tex.w = 1 + dot (normalDir, -lightDir) * 2.5;
				o.col = lerp (_BackColor, _Color, saturate (dot (normalDir, -lightDir) * 0.5 + 0.5));
				
				return o;
			}
			
			fixed4 frag(vertexOutput i) : Color {
				fixed4 s = fixed4 (saturate (tex2D (_ShadowTex, i.tex.xy + float2 (0, -_Light.w)).rgb * i.tex.w), 1.0);
				return tex2D (_MainTex, i.tex.xy) * s * i.col;
			}
			
			ENDCG
		}
		
		Pass {
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			Cull Front
		
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			uniform sampler2D _MainTex;
			uniform sampler2D _ShadowTex;
			uniform fixed4 _Color;
			uniform fixed4 _BackColor;
			uniform fixed4 _Light;
			
			struct vertexInput {
				fixed4 vertex : POSITION;
				fixed3 normal : NORMAL;
				fixed4 texcoord : TEXCOORD0;
			};
			struct vertexOutput {
				fixed4 pos : SV_POSITION;
				fixed4 col : Color;
				fixed4 tex : TEXCOORD0;
			};
			
			vertexOutput vert(vertexInput v) {
				vertexOutput o;
				
				fixed3 normalDir = normalize (mul (unity_ObjectToWorld, float4 (v.normal,0)).xyz);
				fixed3 lightDir = normalize (_Light.xyz);
            	
            	o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.tex = v.texcoord;
				o.tex.w = 1 + dot (normalDir, lightDir) * 2.5;
				o.col = lerp (_BackColor, _Color, saturate (dot (normalDir, lightDir) * 0.5 + 0.5));
				
				return o;
			}
			
			fixed4 frag(vertexOutput i) : Color {
				fixed4 s = fixed4 (saturate (tex2D (_ShadowTex, i.tex.xy + float2 (0, -_Light.w)).rgb * i.tex.w), 1.0);
				return tex2D (_MainTex, i.tex.xy) * s * i.col;
			}
			
			ENDCG
		}
		
	}

	Fallback "Transparent/VertexLit"
}