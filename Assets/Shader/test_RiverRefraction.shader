// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Mobile/Particles/Additive,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:34338,y:32566,varname:node_1873,prsc:2|emission-4453-OUT,alpha-603-OUT,refract-5526-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32181,y:32422,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32579,y:32576,cmnt:RGB,varname:node_1086,prsc:2|A-4805-RGB,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32198,y:32726,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32209,y:32958,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:603,x:32555,y:32762,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5376-A,C-5983-A;n:type:ShaderForge.SFN_Append,id:4884,x:31532,y:33023,varname:node_4884,prsc:2|A-6594-OUT,B-5308-OUT;n:type:ShaderForge.SFN_Vector1,id:5308,x:31361,y:33239,varname:node_5308,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:6235,x:32380,y:33218,ptovrint:False,ptlb:ColorRamp,ptin:_ColorRamp,varname:_ColorRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Blend,id:1261,x:32875,y:32640,varname:node_1261,prsc:2,blmd:10,clmp:True|SRC-1086-OUT,DST-6235-RGB;n:type:ShaderForge.SFN_Add,id:1989,x:33601,y:32645,varname:node_1989,prsc:2|A-5413-OUT,B-1261-OUT;n:type:ShaderForge.SFN_Panner,id:4009,x:33038,y:33443,varname:node_4009,prsc:1,spu:0,spv:0.07|UVIN-4685-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4685,x:32828,y:33518,varname:node_4685,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:9,x:33269,y:33358,ptovrint:False,ptlb:refraction,ptin:_refraction,varname:_refraction,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-4009-UVOUT;n:type:ShaderForge.SFN_Append,id:9781,x:33474,y:33287,varname:node_9781,prsc:2|A-9-R,B-9-G;n:type:ShaderForge.SFN_Multiply,id:5526,x:33836,y:33237,varname:node_5526,prsc:2|A-9781-OUT,B-1908-OUT;n:type:ShaderForge.SFN_Vector1,id:1908,x:33661,y:33468,varname:node_1908,prsc:2,v1:0.005;n:type:ShaderForge.SFN_TexCoord,id:7575,x:32538,y:32170,varname:node_7575,prsc:2,uv:0;n:type:ShaderForge.SFN_ComponentMask,id:5801,x:32733,y:32170,varname:node_5801,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7575-V;n:type:ShaderForge.SFN_Power,id:2402,x:33000,y:32241,varname:node_2402,prsc:2|VAL-5801-OUT,EXP-1470-OUT;n:type:ShaderForge.SFN_Vector1,id:1470,x:32733,y:32352,varname:node_1470,prsc:2,v1:8;n:type:ShaderForge.SFN_Multiply,id:5413,x:33125,y:32516,varname:node_5413,prsc:2|A-6235-RGB,B-2402-OUT;n:type:ShaderForge.SFN_Color,id:9170,x:33313,y:30959,ptovrint:False,ptlb:FogColor,ptin:_FogColor,varname:_FogColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:4453,x:34252,y:32181,varname:node_4453,prsc:2|A-3062-OUT,B-6095-OUT,T-6328-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:6908,x:33259,y:31756,varname:node_6908,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:3148,x:33453,y:31823,varname:node_3148,prsc:2,frmn:0,frmx:100,tomn:0,tomx:1|IN-6908-Z;n:type:ShaderForge.SFN_Multiply,id:6328,x:33650,y:31934,varname:node_6328,prsc:2|A-3148-OUT,B-6704-OUT;n:type:ShaderForge.SFN_Set,id:8875,x:32535,y:33311,varname:daynightramp,prsc:2|IN-6235-A;n:type:ShaderForge.SFN_Color,id:1208,x:33283,y:31168,ptovrint:False,ptlb:node_1208,ptin:_node_1208,varname:_node_1208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:6095,x:33625,y:31381,varname:node_6095,prsc:2|A-9170-RGB,B-1208-RGB,T-5864-OUT;n:type:ShaderForge.SFN_Get,id:5864,x:33218,y:31415,varname:node_5864,prsc:2|IN-8875-OUT;n:type:ShaderForge.SFN_RemapRange,id:5914,x:33942,y:32601,varname:node_5914,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-1989-OUT;n:type:ShaderForge.SFN_Lerp,id:3062,x:33948,y:32224,varname:node_3062,prsc:2|A-1989-OUT,B-5914-OUT,T-6704-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6594,x:31286,y:33023,ptovrint:False,ptlb:CurrentTime,ptin:_CurrentTime,varname:node_6594,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:6704,x:33251,y:32122,ptovrint:False,ptlb:FogDensity,ptin:_FogDensity,varname:node_6704,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:4805-5983-6235-9-9170-1208;pass:END;sub:END;*/

Shader "Shader Forge/test_RiverRefraction" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "black" {}
        _Color ("Color", Color) = (1,1,1,1)
        _ColorRamp ("ColorRamp", 2D) = "gray" {}
        _refraction ("refraction", 2D) = "bump" {}
        _FogColor ("FogColor", Color) = (0.5,0.5,0.5,1)
        _node_1208 ("node_1208", Color) = (0.5,0.5,0.5,1)
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
        GrabPass{ "Refraction" }
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
            uniform sampler2D Refraction;
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed4 _Color;
            uniform sampler2D _ColorRamp; uniform float4 _ColorRamp_ST;
            uniform sampler2D _refraction; uniform float4 _refraction_ST;
            uniform float4 _FogColor;
            uniform float4 _node_1208;
            uniform float _CurrentTime;
            uniform float _FogDensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                o.screenPos = float4( o.pos.xy / o.pos.w, 0, 0 );
                o.screenPos.y *= _ProjectionParams.x;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                float4 node_4 = _Time + _TimeEditor;
                half2 node_4009 = (i.uv0+node_4.g*float2(0,0.07));
                half3 _refraction_var = UnpackNormal(tex2D(_refraction,TRANSFORM_TEX(node_4009, _refraction)));
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (float2(_refraction_var.r,_refraction_var.g)*0.005);
                float4 sceneColor = tex2D(Refraction, sceneUVs);
////// Lighting:
////// Emissive:
                float2 node_4884 = float2(_CurrentTime,0.5);
                half4 _ColorRamp_var = tex2D(_ColorRamp,TRANSFORM_TEX(node_4884, _ColorRamp));
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 node_1989 = ((_ColorRamp_var.rgb*pow(i.uv0.g.r,8.0))+saturate(( _ColorRamp_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_ColorRamp_var.rgb-0.5))*(1.0-(_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb))) : (2.0*_ColorRamp_var.rgb*(_MainTex_var.rgb*_Color.rgb*i.vertexColor.rgb)) )));
                float daynightramp = _ColorRamp_var.a;
                float3 emissive = lerp(lerp(node_1989,(node_1989*0.1+0.0),_FogDensity),lerp(_FogColor.rgb,_node_1208.rgb,daynightramp),((i.posWorld.b*0.01+0.0)*_FogDensity));
                float3 finalColor = emissive;
                return fixed4(lerp(sceneColor.rgb, finalColor,(_MainTex_var.a*i.vertexColor.a*_Color.a)),1);
            }
            ENDCG
        }
    }
    FallBack "Mobile/Particles/Additive"
    CustomEditor "ShaderForgeMaterialInspector"
}
