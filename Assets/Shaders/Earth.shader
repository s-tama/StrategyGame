//
// Earth.shader
//

// ------------------------------------------------
// 地球のシェーダー
// ------------------------------------------------
Shader "Custom/Earth" 
{
	Properties
	{
		_MainTex ("Main texture", 2D) = "white"{}
		_Displacement("Displacement", Range(0, 10)) = 0.0
	}

	SubShader
	{
		Tags
		{
			"Queue" = "Geometry"
			"RenderType" = "Transparent"
			"RenderType" = "Opaque"
			"Queue" = "Transparent"
		}
		LOD 200

		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			Tags
			{ 
				"LightMode" = "ForwardBase" 
			}

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"


			// テクスチャ
			sampler2D _MainTex;
			// 拡散範囲
			float _Displacement;


			// ----------------------------------------------
			// 入力
			// ----------------------------------------------
			struct appdata
			{
				float4 vertex	: POSITION;		// 頂点座標
				float3 normal	: NORMAL;		// 頂点の法線情報	
				float2 uv		: TEXCOORD0;	// テクスチャのuv情報
				float4 tangent	: TANGENT;		// 接線の情報
			};

			// ----------------------------------------------
			// フラグメントシェーダに渡す情報
			// ----------------------------------------------
			struct v2f
			{
				float4 vertex	: SV_POSITION;	// 頂点座標
				float3 normal	: NORMAL;		// 法線情報	
				float2 uv		: TEXCOORD0;	// テクスチャのuv情報
				float3 viewDir	: TEXCOORD1;	// カメラの方向ベクトル
				float3 lightDir : TEXCOORD2;	// ライトの方向ベクトル		
				float3 worldPos : TEXCOORD3;	// オブジェクトのワールド座標
			};


			// ----------------------------------------------
			// 頂点シェーダー
			// ----------------------------------------------
			v2f vert(appdata v)
			{
				// フラグメントシェーダーに渡すデータ
				v2f o;
				o.normal   = UnityObjectToWorldNormal(v.normal);
				o.vertex   = UnityObjectToClipPos(v.vertex);
				//o.vertex   = UnityObjectToClipPos(v.vertex) + float4(n * _Displacement, 0);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex);
				o.uv       = v.uv;

				// 接空間におけるライト方向のベクトルと視点方向のベクトルを求める
				TANGENT_SPACE_ROTATION;
				o.lightDir = normalize(ObjSpaceLightDir(v.vertex));
				o.viewDir  = normalize(ObjSpaceViewDir(v.vertex));

				// 結果を返す
				return o;
			}

			// ----------------------------------------------
			// フラグメントシェーダー
			// ----------------------------------------------
			float4 frag(v2f i) : COLOR
			{
				// 描画色
				float4 albedo = float4(1, 1, 1, 1);
				float4 base   = tex2D(_MainTex, i.uv);
				albedo        = base;

				// リムライティング処理
				float4 rimColor = float4(1, 1, 1, 1);
				float  rim      = 1 - saturate(dot(i.viewDir, i.normal));
				float3 rimRGB   = float3(rimColor.r, rimColor.g, rimColor.b);
				float4 emission = float4(rimRGB * cos(_Time), 1) * pow(rim, 5.5);

				// 透過処理	
				float alpha = max(0.2, 1 - (abs(dot(i.viewDir, i.normal))));
				albedo.a    = alpha * 1.5;

				// 結果を返す
				return albedo + emission;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
