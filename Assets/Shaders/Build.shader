//
// Build.shader
//

/// <summary>
/// 建物
/// </summary>
Shader "Custom/Build" 
{
	Properties 
	{
		_Color ("Color", Color) = (1, 1, 1, 1)
		_Rim ("Rim Color", Color) = (1, 1, 1, 1)
	}
	SubShader 
		{
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		struct Input 
		{
			float2 uv_MainTex;
			float3 worldNormal;
			float3 viewDir;
		};

		float4 _Color;
		float4 _Rim;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			o.Albedo = _Color;

			// リムライティングの設定
			float rim = 1 - abs(dot(IN.viewDir, o.Normal));
			o.Emission = _Rim * pow(rim, 2.5);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
