Shader "Unlit/Outline"
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" { }
		_MainColor("Main Color", Color) = (.5,.5,.5,1)
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_OutlineWidth("Outline Width", Range(0, 0.1)) = .005
	}

		CGINCLUDE
#include "UnityCG.cginc"

			struct appdata
		{
			float4 vertex : POSITION;
			float2 uv       : TEXCOORD0;
			float3 normal : NORMAL;
		};

		struct v2f
		{
			float4 pos : SV_POSITION;
			float2 uv       : TEXCOORD0;
		};

		sampler2D _MainTex;
		float4 _MainTex_ST;
		uniform float4 _MainColor;
		uniform float _OutlineWidth;
		uniform float4 _OutlineColor;

		ENDCG

			SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100
			Pass
			{
				Name "BASE" //�{�̕�����`�悷��p�X�̖��O

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"
				v2f vert(appdata v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex); //���_��MVP�s��ϊ�
					o.uv = TRANSFORM_TEX(v.uv, _MainTex); //�e�N�X�`���X�P�[���ƃI�t�Z�b�g������
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					half4 c = tex2D(_MainTex, i.uv); //UV�����ƂɃe�N�X�`���J���[���T���v�����O
					c.rgb *= _MainColor; //�x�[�X�J���[����Z
					return c;
				}
				ENDCG
			}
			Pass
			{
				Name "OUTLINE" //�A�E�g���C��������`�悷��p�X�̖��O

				Cull Front //�\�ʂ��J�����O�i�`�悵�Ȃ��j

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				v2f vert(appdata v)
				{
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex); //���_��MVP�s��ϊ�

					float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal)); //���f�����W�n�̖@�����r���[���W�n�ɕϊ�
					float2 offset = TransformViewToProjection(norm.xy); //�r���[���W�n�ɕϊ������@���𓊉e���W�n�ɕϊ�

					o.pos.xy += offset * UNITY_Z_0_FAR_FROM_CLIPSPACE(o.pos.z) * _OutlineWidth; //�@�������ɒ��_�ʒu�������o��

					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					return _OutlineColor; //�v���p�e�B�ɐݒ肵���A�E�g���C���J���[��\��
				}
				ENDCG
			}
		}
}
