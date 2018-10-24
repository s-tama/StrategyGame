//
// Soldier.shader
//

Shader "Custom/Soldier" 
{
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		/// <summary>
		/// 入力構造体
		/// </summary>
		struct Input 
		{
			float2 uv_MainTex;
		};
		
		// 色
		float4 _Color;

		/// <summary>
		/// サーフェイスシェーダー
		/// </summary>
		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			o.Albedo = _Color;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
