// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.28 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.28;sub:START;pass:START;ps:flbk:Mobile/Particles/Alpha Blended,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:33852,y:32722,varname:node_1873,prsc:2|emission-9495-OUT,alpha-5262-OUT;n:type:ShaderForge.SFN_Multiply,id:1086,x:32802,y:32760,cmnt:RGB,varname:node_1086,prsc:2|A-3018-RGB,B-5983-RGB,C-5376-A,D-7690-OUT,E-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32270,y:32733,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32343,y:32962,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Append,id:4884,x:32143,y:33189,varname:node_4884,prsc:1|A-8742-OUT,B-5308-OUT;n:type:ShaderForge.SFN_Vector1,id:5308,x:31815,y:33408,varname:node_5308,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:6235,x:32396,y:33142,ptovrint:False,ptlb:ColorRamp,ptin:_ColorRamp,varname:_ColorRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Tex2d,id:3018,x:32370,y:32530,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1143,x:33389,y:32795,varname:node_1143,prsc:2|A-1086-OUT,B-6118-OUT;n:type:ShaderForge.SFN_Vector1,id:7690,x:32629,y:32933,varname:node_7690,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:9495,x:33636,y:32735,varname:node_9495,prsc:2|A-1143-OUT,B-2580-OUT,T-2188-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2188,x:33407,y:33071,ptovrint:False,ptlb:Affect by fog,ptin:_Affectbyfog,varname:_Affectbyfog,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7298-OUT,B-7208-OUT;n:type:ShaderForge.SFN_Vector1,id:7298,x:33246,y:33135,varname:node_7298,prsc:2,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:8742,x:31774,y:33237,ptovrint:False,ptlb:CurrentTime,ptin:_CurrentTime,varname:node_8742,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1655,x:32563,y:33414,ptovrint:False,ptlb:FogDensity,ptin:_FogDensity,varname:node_1655,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7740,x:32802,y:32596,varname:node_7740,prsc:2|A-3018-A,B-5983-RGB,C-5376-A,D-7690-OUT,E-5376-RGB;n:type:ShaderForge.SFN_Multiply,id:2580,x:33242,y:32646,varname:node_2580,prsc:2|A-7740-OUT,B-6118-OUT,C-3210-OUT,D-5674-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:3003,x:32117,y:32281,varname:node_3003,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:8981,x:32312,y:32313,varname:node_8981,prsc:2,frmn:0,frmx:100,tomn:0,tomx:1|IN-3003-Z;n:type:ShaderForge.SFN_Clamp01,id:2603,x:32510,y:32331,varname:node_2603,prsc:2|IN-8981-OUT;n:type:ShaderForge.SFN_OneMinus,id:204,x:32724,y:32348,varname:node_204,prsc:2|IN-2603-OUT;n:type:ShaderForge.SFN_Vector1,id:5674,x:32973,y:32701,varname:node_5674,prsc:2,v1:1.5;n:type:ShaderForge.SFN_SwitchProperty,id:3210,x:33034,y:32396,ptovrint:False,ptlb:Affect by distance,ptin:_Affectbydistance,varname:_Affectbydistance,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-2310-OUT,B-204-OUT;n:type:ShaderForge.SFN_Vector1,id:2310,x:32864,y:32324,varname:node_2310,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:5372,x:32584,y:33191,varname:node_5372,prsc:2|A-6235-RGB,B-1655-OUT;n:type:ShaderForge.SFN_Clamp01,id:5802,x:32756,y:33179,varname:node_5802,prsc:2|IN-5372-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:6118,x:32935,y:33095,ptovrint:False,ptlb:Fog Light,ptin:_FogLight,varname:_FogLight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6235-RGB,B-5802-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:4511,x:32886,y:33397,varname:node_4511,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:4701,x:33084,y:33420,varname:node_4701,prsc:2,frmn:0,frmx:100,tomn:0,tomx:1|IN-4511-Z;n:type:ShaderForge.SFN_Clamp01,id:9673,x:33252,y:33458,varname:node_9673,prsc:2|IN-4701-OUT;n:type:ShaderForge.SFN_Multiply,id:7208,x:33441,y:33501,varname:node_7208,prsc:2|A-9673-OUT,B-1655-OUT;n:type:ShaderForge.SFN_Multiply,id:5262,x:33008,y:32875,varname:node_5262,prsc:2|A-3018-A,B-5983-A,C-5376-A;proporder:5983-3018-6235-2188-3210-6118;pass:END;sub:END;*/

Shader "Shader Forge/test_Particle_Alphablend" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _ColorRamp ("ColorRamp", 2D) = "gray" {}
        [MaterialToggle] _Affectbyfog ("Affect by fog", Float ) = 0
        [MaterialToggle] _Affectbydistance ("Affect by distance", Float ) = 1
        [MaterialToggle] _FogLight ("Fog Light", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform fixed4 _Color;
            uniform sampler2D _ColorRamp; uniform float4 _ColorRamp_ST;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform fixed _Affectbyfog;
            uniform float _CurrentTime;
            uniform float _FogDensity;
            uniform fixed _Affectbydistance;
            uniform fixed _FogLight;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                fixed4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float node_7690 = 2.0;
                half2 node_4884 = float2(_CurrentTime,0.5);
                half4 _ColorRamp_var = tex2D(_ColorRamp,TRANSFORM_TEX(node_4884, _ColorRamp));
                float3 _FogLight_var = lerp( _ColorRamp_var.rgb, saturate((_ColorRamp_var.rgb+_FogDensity)), _FogLight );
                float3 emissive = lerp(((_Diffuse_var.rgb*_Color.rgb*i.vertexColor.a*node_7690*i.vertexColor.rgb)*_FogLight_var),((_Diffuse_var.a*_Color.rgb*i.vertexColor.a*node_7690*i.vertexColor.rgb)*_FogLight_var*lerp( 1.0, (1.0 - saturate((i.posWorld.b*0.01+0.0))), _Affectbydistance )*1.5),lerp( 0.0, (saturate((i.posWorld.b*0.01+0.0))*_FogDensity), _Affectbyfog ));
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Diffuse_var.a*_Color.a*i.vertexColor.a));
            }
            ENDCG
        }
    }
    FallBack "Mobile/Particles/Alpha Blended"
    CustomEditor "ShaderForgeMaterialInspector"
}
