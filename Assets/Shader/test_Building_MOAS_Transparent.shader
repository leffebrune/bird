// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Sprites/Default,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:34606,y:32128,varname:node_1873,prsc:2|emission-1989-OUT,alpha-8440-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31992,y:32424,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:7d5a1b5c6dca26544a83e95f645ff654,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:33277,y:32691,cmnt:RGB,varname:node_1086,prsc:2|A-5983-RGB,B-5376-RGB,C-4860-OUT;n:type:ShaderForge.SFN_Color,id:5983,x:33107,y:32451,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:33077,y:32691,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Append,id:4884,x:31604,y:32948,varname:node_4884,prsc:1|A-4174-OUT,B-5308-OUT;n:type:ShaderForge.SFN_Vector1,id:5308,x:31415,y:33207,varname:node_5308,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:6235,x:32192,y:33358,ptovrint:False,ptlb:ColorRamp,ptin:_ColorRamp,varname:_ColorRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0395a6a8c2cfe68498778c96de9d0833,ntxv:1,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Blend,id:1261,x:33615,y:32884,varname:node_1261,prsc:2,blmd:13,clmp:True|SRC-6291-OUT,DST-6235-RGB;n:type:ShaderForge.SFN_Tex2d,id:7893,x:31261,y:32284,ptovrint:False,ptlb:WindowRamp,ptin:_WindowRamp,varname:_WindowRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:058f9893e7fd8874b8a396bcca26c58e,ntxv:2,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Tex2d,id:7313,x:31579,y:31778,ptovrint:False,ptlb:WindowTime,ptin:_WindowTime,varname:_WindowTime,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40f5d911cd1c77a469ab71e028f33e26,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Add,id:1989,x:34379,y:32262,varname:node_1989,prsc:2|A-8067-OUT,B-1419-OUT;n:type:ShaderForge.SFN_Clamp01,id:8999,x:32930,y:32125,varname:node_8999,prsc:2|IN-2937-OUT;n:type:ShaderForge.SFN_Multiply,id:2937,x:32501,y:32006,varname:node_2937,prsc:2|A-9895-OUT,B-1793-OUT;n:type:ShaderForge.SFN_Lerp,id:4860,x:33042,y:32885,varname:node_4860,prsc:2|A-4483-OUT,B-1933-OUT,T-6235-A;n:type:ShaderForge.SFN_Multiply,id:8067,x:33135,y:32227,varname:node_8067,prsc:2|A-8999-OUT,B-3755-RGB;n:type:ShaderForge.SFN_Color,id:3755,x:32930,y:32313,ptovrint:False,ptlb:WindowColor,ptin:_WindowColor,varname:_WindowColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9413,x:32108,y:32195,varname:node_9413,prsc:2|A-6514-OUT,B-8383-OUT;n:type:ShaderForge.SFN_Vector1,id:8383,x:31934,y:32295,varname:node_8383,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:7457,x:32117,y:32737,varname:node_7457,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1130,x:32117,y:32851,varname:node_1130,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:4079,x:32177,y:32576,ptovrint:False,ptlb:DayContrast,ptin:_DayContrast,varname:_DayContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1156,x:32568,y:32893,varname:node_1156,prsc:2|IN-4805-RGB,IMIN-7457-OUT,IMAX-1130-OUT,OMIN-4977-OUT,OMAX-11-OUT;n:type:ShaderForge.SFN_Slider,id:5144,x:32035,y:33174,ptovrint:False,ptlb:NightContrast,ptin:_NightContrast,varname:_NightContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.676643,max:1;n:type:ShaderForge.SFN_OneMinus,id:4977,x:32368,y:32900,varname:node_4977,prsc:2|IN-11-OUT;n:type:ShaderForge.SFN_Clamp01,id:4483,x:32984,y:32594,varname:node_4483,prsc:2|IN-3794-OUT;n:type:ShaderForge.SFN_Multiply,id:4002,x:32697,y:32582,varname:node_4002,prsc:2|A-3762-OUT,B-3049-OUT;n:type:ShaderForge.SFN_Power,id:3762,x:32716,y:32412,varname:node_3762,prsc:2|VAL-4805-RGB,EXP-7044-OUT;n:type:ShaderForge.SFN_Add,id:1793,x:32299,y:32041,varname:node_1793,prsc:2|A-905-OUT,B-9413-OUT;n:type:ShaderForge.SFN_Add,id:4841,x:33440,y:32691,varname:node_4841,prsc:2|A-1086-OUT,B-6410-OUT;n:type:ShaderForge.SFN_Slider,id:4628,x:33000,y:33200,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:6291,x:33615,y:32691,varname:node_6291,prsc:2|IN-4841-OUT;n:type:ShaderForge.SFN_RemapRange,id:6410,x:33264,y:32997,varname:node_6410,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-4628-OUT;n:type:ShaderForge.SFN_RemapRange,id:3049,x:32532,y:32627,varname:node_3049,prsc:2,frmn:0,frmx:1,tomn:1,tomx:2|IN-4079-OUT;n:type:ShaderForge.SFN_RemapRange,id:7044,x:32532,y:32458,varname:node_7044,prsc:2,frmn:0,frmx:1,tomn:1,tomx:3|IN-4079-OUT;n:type:ShaderForge.SFN_RemapRange,id:11,x:32376,y:33157,varname:node_11,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-5144-OUT;n:type:ShaderForge.SFN_Multiply,id:8440,x:33277,y:32856,varname:node_8440,prsc:2|A-5983-A,B-5376-A,C-4805-A;n:type:ShaderForge.SFN_Blend,id:9036,x:33850,y:33057,varname:node_9036,prsc:2,blmd:10,clmp:True|SRC-6291-OUT,DST-6235-RGB;n:type:ShaderForge.SFN_Multiply,id:2734,x:34176,y:33057,varname:node_2734,prsc:2|A-9390-OUT,B-373-OUT;n:type:ShaderForge.SFN_Power,id:9390,x:34017,y:33057,varname:node_9390,prsc:2|VAL-9036-OUT,EXP-3616-OUT;n:type:ShaderForge.SFN_Vector1,id:3616,x:33866,y:33254,varname:node_3616,prsc:2,v1:5;n:type:ShaderForge.SFN_Vector1,id:373,x:34027,y:33254,varname:node_373,prsc:2,v1:1.5;n:type:ShaderForge.SFN_SwitchProperty,id:7937,x:33953,y:32790,ptovrint:False,ptlb:OverlayBlend,ptin:_OverlayBlend,varname:_OverlayBlend,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1261-OUT,B-2734-OUT;n:type:ShaderForge.SFN_Lerp,id:1419,x:34176,y:32158,varname:node_1419,prsc:2|A-1702-OUT,B-3498-OUT,T-9475-OUT;n:type:ShaderForge.SFN_Color,id:6488,x:33469,y:31108,ptovrint:False,ptlb:FogColor,ptin:_FogColor,varname:_FogColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_FragmentPosition,id:4727,x:33401,y:31545,varname:node_4727,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:8183,x:33595,y:31613,varname:node_8183,prsc:2,frmn:0,frmx:100,tomn:0,tomx:1|IN-4727-Z;n:type:ShaderForge.SFN_Multiply,id:9475,x:33943,y:31787,varname:node_9475,prsc:2|A-8183-OUT,B-6324-OUT;n:type:ShaderForge.SFN_Get,id:3483,x:33574,y:31433,varname:node_3483,prsc:2|IN-323-OUT;n:type:ShaderForge.SFN_Set,id:5549,x:32344,y:33543,varname:daynightramp,prsc:2|IN-6235-A;n:type:ShaderForge.SFN_Set,id:323,x:32970,y:33058,varname:nightcontrast,prsc:2|IN-1933-OUT;n:type:ShaderForge.SFN_Get,id:9842,x:33469,y:31310,varname:node_9842,prsc:2|IN-5549-OUT;n:type:ShaderForge.SFN_Multiply,id:5650,x:33853,y:31453,varname:node_5650,prsc:2|A-4581-OUT,B-3483-OUT;n:type:ShaderForge.SFN_Color,id:614,x:33303,y:31235,ptovrint:False,ptlb:Fogcolor2,ptin:_Fogcolor2,varname:_Fogcolor2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:4581,x:33680,y:31203,varname:node_4581,prsc:2|A-6488-RGB,B-614-RGB,T-9842-OUT;n:type:ShaderForge.SFN_Lerp,id:1702,x:33980,y:32357,varname:node_1702,prsc:2|A-7937-OUT,B-471-OUT,T-6324-OUT;n:type:ShaderForge.SFN_RemapRange,id:471,x:34210,y:32699,varname:node_471,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-7937-OUT;n:type:ShaderForge.SFN_Lerp,id:3498,x:34175,y:31354,varname:node_3498,prsc:2|A-5650-OUT,B-4581-OUT,T-9842-OUT;n:type:ShaderForge.SFN_Set,id:9952,x:34229,y:31899,varname:fogtimer,prsc:2|IN-9475-OUT;n:type:ShaderForge.SFN_Set,id:3590,x:33774,y:31755,varname:Zposition,prsc:2|IN-8183-OUT;n:type:ShaderForge.SFN_Lerp,id:9895,x:32250,y:31796,varname:node_9895,prsc:2|A-7313-R,B-4494-OUT,T-736-OUT;n:type:ShaderForge.SFN_Get,id:736,x:32052,y:31914,varname:node_736,prsc:2|IN-9952-OUT;n:type:ShaderForge.SFN_Get,id:4591,x:31602,y:31581,varname:node_4591,prsc:2|IN-3590-OUT;n:type:ShaderForge.SFN_Multiply,id:4182,x:32052,y:31676,varname:node_4182,prsc:2|A-7863-OUT,B-9594-OUT,C-7313-G;n:type:ShaderForge.SFN_Vector1,id:9594,x:31888,y:31651,varname:node_9594,prsc:2,v1:1.5;n:type:ShaderForge.SFN_OneMinus,id:7863,x:31772,y:31496,varname:node_7863,prsc:2|IN-4591-OUT;n:type:ShaderForge.SFN_Clamp01,id:4494,x:32351,y:31652,varname:node_4494,prsc:2|IN-4182-OUT;n:type:ShaderForge.SFN_RemapRange,id:8287,x:32719,y:32716,varname:node_8287,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-1199-OUT;n:type:ShaderForge.SFN_Slider,id:1199,x:32211,y:32719,ptovrint:False,ptlb:DayBrightness,ptin:_DayBrightness,varname:_DayBrightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:3794,x:32851,y:32622,varname:node_3794,prsc:2|A-4002-OUT,B-8287-OUT;n:type:ShaderForge.SFN_RemapRange,id:2501,x:32568,y:33075,varname:node_2501,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-4278-OUT;n:type:ShaderForge.SFN_Slider,id:4278,x:32040,y:33067,ptovrint:False,ptlb:NightBrightness,ptin:_NightBrightness,varname:_NightBrightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:1933,x:32737,y:32943,varname:node_1933,prsc:2|A-1156-OUT,B-2501-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4174,x:31373,y:32948,ptovrint:False,ptlb:CurrentTime,ptin:_CurrentTime,varname:node_4174,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Set,id:1310,x:31528,y:32804,varname:time,prsc:2|IN-4174-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6324,x:33261,y:31821,ptovrint:False,ptlb:FogDensity,ptin:_FogDensity,varname:node_6324,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ScreenPos,id:3633,x:31896,y:32020,varname:node_3633,prsc:2,sctp:0;n:type:ShaderForge.SFN_RemapRange,id:905,x:32141,y:32020,varname:node_905,prsc:2,frmn:-1,frmx:1,tomn:-0.1,tomx:0|IN-3633-U;n:type:ShaderForge.SFN_Add,id:3911,x:31458,y:32119,varname:node_3911,prsc:2|A-6324-OUT,B-7893-RGB;n:type:ShaderForge.SFN_Clamp01,id:1622,x:31645,y:32090,varname:node_1622,prsc:2|IN-3911-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:6514,x:31702,y:32329,ptovrint:False,ptlb:Fog Light,ptin:_FogLight,varname:_FogLight,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7893-RGB,B-1622-OUT;proporder:4805-5983-6235-7893-7313-3755-4079-5144-4628-7937-6488-614-1199-4278-6514;pass:END;sub:END;*/

Shader "Shader Forge/test_Building_MOAS_Transparent" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "black" {}
        _Color ("Color", Color) = (1,1,1,1)
        _ColorRamp ("ColorRamp", 2D) = "gray" {}
        _WindowRamp ("WindowRamp", 2D) = "black" {}
        _WindowTime ("WindowTime", 2D) = "black" {}
        _WindowColor ("WindowColor", Color) = (1,1,1,1)
        _DayContrast ("DayContrast", Range(0, 1)) = 1
        _NightContrast ("NightContrast", Range(0, 1)) = 0.676643
        _Brightness ("Brightness", Range(0, 1)) = 0
        [MaterialToggle] _OverlayBlend ("OverlayBlend", Float ) = 0
        _FogColor ("FogColor", Color) = (0.5,0.5,0.5,1)
        _Fogcolor2 ("Fogcolor2", Color) = (0.5,0.5,0.5,1)
        _DayBrightness ("DayBrightness", Range(0, 1)) = 0.5
        _NightBrightness ("NightBrightness", Range(0, 1)) = 0.5
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform fixed4 _Color;
            uniform sampler2D _ColorRamp; uniform float4 _ColorRamp_ST;
            uniform sampler2D _WindowRamp; uniform float4 _WindowRamp_ST;
            uniform sampler2D _WindowTime; uniform float4 _WindowTime_ST;
            uniform fixed4 _WindowColor;
            uniform float _DayContrast;
            uniform float _NightContrast;
            uniform float _Brightness;
            uniform fixed _OverlayBlend;
            uniform float4 _FogColor;
            uniform float4 _Fogcolor2;
            uniform float _DayBrightness;
            uniform float _NightBrightness;
            uniform float _CurrentTime;
            uniform float _FogDensity;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                half4 _WindowTime_var = tex2D(_WindowTime,TRANSFORM_TEX(i.uv0, _WindowTime));
                float node_8183 = (i.posWorld.b*0.01+0.0);
                float Zposition = node_8183;
                float node_9475 = (node_8183*_FogDensity);
                float fogtimer = node_9475;
                half2 node_4884 = float2(_CurrentTime,0.5);
                half4 _WindowRamp_var = tex2D(_WindowRamp,TRANSFORM_TEX(node_4884, _WindowRamp));
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_7457 = 0.0;
                float node_11 = (_NightContrast*0.5+0.5);
                float node_4977 = (1.0 - node_11);
                float3 node_1933 = ((node_4977 + ( (_MainTex_var.rgb - node_7457) * (node_11 - node_4977) ) / (1.0 - node_7457))+(_NightBrightness*0.2+-0.1));
                half4 _ColorRamp_var = tex2D(_ColorRamp,TRANSFORM_TEX(node_4884, _ColorRamp));
                float3 node_6291 = saturate(((_Color.rgb*i.vertexColor.rgb*lerp(saturate(((pow(_MainTex_var.rgb,(_DayContrast*2.0+1.0))*(_DayContrast*1.0+1.0))+(_DayBrightness*0.2+-0.1))),node_1933,_ColorRamp_var.a))+(_Brightness*0.2+-0.1)));
                float3 _OverlayBlend_var = lerp( saturate(( node_6291 > 0.5 ? (_ColorRamp_var.rgb/((1.0-node_6291)*2.0)) : (1.0-(((1.0-_ColorRamp_var.rgb)*0.5)/node_6291)))), (pow(saturate(( _ColorRamp_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_ColorRamp_var.rgb-0.5))*(1.0-node_6291)) : (2.0*_ColorRamp_var.rgb*node_6291) )),5.0)*1.5), _OverlayBlend );
                float daynightramp = _ColorRamp_var.a;
                float node_9842 = daynightramp;
                float3 node_4581 = lerp(_FogColor.rgb,_Fogcolor2.rgb,node_9842);
                float3 nightcontrast = node_1933;
                float3 emissive = ((saturate((lerp(_WindowTime_var.r,saturate(((1.0 - Zposition)*1.5*_WindowTime_var.g)),fogtimer)*((i.screenPos.r*0.05+-0.05)+(lerp( _WindowRamp_var.rgb, saturate((_FogDensity+_WindowRamp_var.rgb)), _FogLight )*2.0))))*_WindowColor.rgb)+lerp(lerp(_OverlayBlend_var,(_OverlayBlend_var*0.1+0.0),_FogDensity),lerp((node_4581*nightcontrast),node_4581,node_9842),node_9475));
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Color.a*i.vertexColor.a*_MainTex_var.a));
            }
            ENDCG
        }
    }
    FallBack "Sprites/Default"
    CustomEditor "ShaderForgeMaterialInspector"
}
