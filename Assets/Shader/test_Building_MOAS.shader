// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Sprites/Default,iptp:1,cusa:True,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:34995,y:32520,varname:node_1873,prsc:2|emission-1989-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31992,y:32424,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,tex:7d5a1b5c6dca26544a83e95f645ff654,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:33327,y:32691,cmnt:RGB,varname:node_1086,prsc:2|A-5983-RGB,B-5376-RGB,C-4860-OUT;n:type:ShaderForge.SFN_Color,id:5983,x:33177,y:32453,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:33154,y:32690,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Append,id:4884,x:31605,y:32946,varname:node_4884,prsc:1|A-1054-OUT,B-5308-OUT;n:type:ShaderForge.SFN_Vector1,id:5308,x:31416,y:33205,varname:node_5308,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:6235,x:32373,y:33481,ptovrint:False,ptlb:ColorRamp,ptin:_ColorRamp,varname:_ColorRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0395a6a8c2cfe68498778c96de9d0833,ntxv:1,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Blend,id:1261,x:33844,y:32906,varname:node_1261,prsc:2,blmd:13,clmp:True|SRC-6291-OUT,DST-6235-RGB;n:type:ShaderForge.SFN_Tex2d,id:7893,x:31171,y:32111,ptovrint:False,ptlb:WindowRamp,ptin:_WindowRamp,varname:_WindowRamp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:058f9893e7fd8874b8a396bcca26c58e,ntxv:2,isnm:False|UVIN-4884-OUT;n:type:ShaderForge.SFN_Tex2d,id:7313,x:31640,y:31677,ptovrint:False,ptlb:WindowTime,ptin:_WindowTime,varname:_WindowTime,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40f5d911cd1c77a469ab71e028f33e26,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Add,id:1989,x:34804,y:32664,varname:node_1989,prsc:2|A-8067-OUT,B-6106-OUT;n:type:ShaderForge.SFN_Clamp01,id:8999,x:32593,y:32000,varname:node_8999,prsc:2|IN-2937-OUT;n:type:ShaderForge.SFN_Multiply,id:2937,x:32460,y:31844,varname:node_2937,prsc:2|A-6180-OUT,B-6997-OUT;n:type:ShaderForge.SFN_Lerp,id:4860,x:33137,y:32880,varname:node_4860,prsc:2|A-4483-OUT,B-8969-OUT,T-6235-A;n:type:ShaderForge.SFN_Multiply,id:8067,x:32961,y:32331,varname:node_8067,prsc:2|A-8999-OUT,B-3755-RGB;n:type:ShaderForge.SFN_Color,id:3755,x:32635,y:32194,ptovrint:False,ptlb:WindowColor,ptin:_WindowColor,varname:_WindowColor,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:9413,x:31954,y:32078,varname:node_9413,prsc:2|A-5438-OUT,B-8383-OUT;n:type:ShaderForge.SFN_Vector1,id:8383,x:31732,y:32177,varname:node_8383,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:7457,x:32117,y:32737,varname:node_7457,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1130,x:32117,y:32851,varname:node_1130,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:4079,x:32143,y:32512,ptovrint:False,ptlb:DayContrast,ptin:_DayContrast,varname:_DayContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.422488,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1156,x:32605,y:32827,varname:node_1156,prsc:2|IN-4805-RGB,IMIN-7457-OUT,IMAX-1130-OUT,OMIN-4977-OUT,OMAX-11-OUT;n:type:ShaderForge.SFN_Slider,id:5144,x:32035,y:33132,ptovrint:False,ptlb:NightContrast,ptin:_NightContrast,varname:_NightContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.676643,max:1;n:type:ShaderForge.SFN_OneMinus,id:4977,x:32368,y:32900,varname:node_4977,prsc:2|IN-11-OUT;n:type:ShaderForge.SFN_Clamp01,id:4483,x:33029,y:32614,varname:node_4483,prsc:2|IN-1122-OUT;n:type:ShaderForge.SFN_Multiply,id:4002,x:32716,y:32582,varname:node_4002,prsc:2|A-3762-OUT,B-3049-OUT;n:type:ShaderForge.SFN_Power,id:3762,x:32716,y:32412,varname:node_3762,prsc:2|VAL-4805-RGB,EXP-7044-OUT;n:type:ShaderForge.SFN_Add,id:4841,x:33486,y:32691,varname:node_4841,prsc:2|A-1086-OUT,B-6410-OUT;n:type:ShaderForge.SFN_Slider,id:4628,x:32980,y:33081,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:6291,x:33648,y:32691,varname:node_6291,prsc:2|IN-4841-OUT;n:type:ShaderForge.SFN_RemapRange,id:6410,x:33345,y:32862,varname:node_6410,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-4628-OUT;n:type:ShaderForge.SFN_RemapRange,id:3049,x:32532,y:32627,varname:node_3049,prsc:2,frmn:0,frmx:1,tomn:1,tomx:2|IN-4079-OUT;n:type:ShaderForge.SFN_RemapRange,id:7044,x:32532,y:32458,varname:node_7044,prsc:2,frmn:0,frmx:1,tomn:1,tomx:3|IN-4079-OUT;n:type:ShaderForge.SFN_RemapRange,id:11,x:32376,y:33157,varname:node_11,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-5144-OUT;n:type:ShaderForge.SFN_Blend,id:3284,x:33572,y:33326,varname:node_3284,prsc:2,blmd:10,clmp:True|SRC-6291-OUT,DST-6235-RGB;n:type:ShaderForge.SFN_Power,id:6705,x:33767,y:33326,varname:node_6705,prsc:2|VAL-3284-OUT,EXP-1626-OUT;n:type:ShaderForge.SFN_Vector1,id:1626,x:33534,y:33522,varname:node_1626,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:6787,x:33955,y:33326,varname:node_6787,prsc:2|A-6705-OUT,B-1345-OUT;n:type:ShaderForge.SFN_Vector1,id:1345,x:33767,y:33522,varname:node_1345,prsc:2,v1:1.5;n:type:ShaderForge.SFN_SwitchProperty,id:6286,x:34136,y:32937,ptovrint:False,ptlb:OverlayBlend,ptin:_OverlayBlend,varname:_OverlayBlend,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1261-OUT,B-6787-OUT;n:type:ShaderForge.SFN_Color,id:4879,x:33833,y:31276,ptovrint:False,ptlb:FogColor,ptin:_FogColor,varname:_FogColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5190311,c2:0.6517599,c3:0.7058823,c4:1;n:type:ShaderForge.SFN_FragmentPosition,id:1897,x:33429,y:32005,varname:node_1897,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:4013,x:33652,y:32019,varname:node_4013,prsc:2,frmn:0,frmx:100,tomn:0,tomx:1|IN-1897-Z;n:type:ShaderForge.SFN_Lerp,id:6106,x:34668,y:32530,varname:node_6106,prsc:2|A-2603-OUT,B-2133-OUT,T-7760-OUT;n:type:ShaderForge.SFN_Clamp01,id:6709,x:33876,y:32126,varname:node_6709,prsc:2|IN-4013-OUT;n:type:ShaderForge.SFN_Multiply,id:7760,x:34225,y:32323,varname:node_7760,prsc:2|A-6709-OUT,B-4252-OUT;n:type:ShaderForge.SFN_Get,id:811,x:33751,y:31872,varname:node_811,prsc:2|IN-7371-OUT;n:type:ShaderForge.SFN_Set,id:7371,x:32917,y:32953,varname:nightcontrast,prsc:2|IN-8969-OUT;n:type:ShaderForge.SFN_Multiply,id:8007,x:34157,y:31934,varname:node_8007,prsc:2|A-5553-OUT,B-811-OUT;n:type:ShaderForge.SFN_Set,id:4973,x:32631,y:33608,varname:daynightramp,prsc:2|IN-6235-A;n:type:ShaderForge.SFN_Get,id:7722,x:33792,y:31728,varname:node_7722,prsc:2|IN-4973-OUT;n:type:ShaderForge.SFN_Color,id:5110,x:33813,y:31514,ptovrint:False,ptlb:Fogcolor2,ptin:_Fogcolor2,varname:_Fogcolor2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2463235,c2:0.3740366,c3:0.5,c4:1;n:type:ShaderForge.SFN_Lerp,id:5553,x:34137,y:31602,varname:node_5553,prsc:2|A-4879-RGB,B-5110-RGB,T-7722-OUT;n:type:ShaderForge.SFN_Lerp,id:2603,x:34696,y:32898,varname:node_2603,prsc:2|A-6286-OUT,B-2145-OUT,T-4252-OUT;n:type:ShaderForge.SFN_RemapRange,id:2145,x:34452,y:33067,varname:node_2145,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-6286-OUT;n:type:ShaderForge.SFN_Lerp,id:2133,x:34409,y:31953,varname:node_2133,prsc:2|A-8007-OUT,B-5553-OUT,T-7722-OUT;n:type:ShaderForge.SFN_Add,id:6997,x:32180,y:32010,varname:node_6997,prsc:2|A-9855-OUT,B-9413-OUT;n:type:ShaderForge.SFN_Lerp,id:6180,x:32180,y:31683,varname:node_6180,prsc:2|A-7313-R,B-7222-OUT,T-1485-OUT;n:type:ShaderForge.SFN_Get,id:1485,x:31888,y:31809,varname:node_1485,prsc:2|IN-3057-OUT;n:type:ShaderForge.SFN_Set,id:3057,x:34363,y:32236,varname:fogtimer,prsc:2|IN-7760-OUT;n:type:ShaderForge.SFN_Multiply,id:4118,x:31983,y:31516,varname:node_4118,prsc:2|A-7313-G,B-3920-OUT,C-2776-OUT;n:type:ShaderForge.SFN_Set,id:2086,x:34080,y:32110,varname:Zposition,prsc:2|IN-6709-OUT;n:type:ShaderForge.SFN_Get,id:2558,x:31381,y:31491,varname:node_2558,prsc:2|IN-2086-OUT;n:type:ShaderForge.SFN_Clamp01,id:7222,x:32208,y:31486,varname:node_7222,prsc:2|IN-4118-OUT;n:type:ShaderForge.SFN_OneMinus,id:2776,x:31605,y:31455,varname:node_2776,prsc:2|IN-2558-OUT;n:type:ShaderForge.SFN_Vector1,id:3920,x:31758,y:31560,varname:node_3920,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Slider,id:6523,x:32200,y:32671,ptovrint:False,ptlb:DayBrightness,ptin:_DayBrightness,varname:_DayBrightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Slider,id:6479,x:31850,y:33019,ptovrint:False,ptlb:NightBrightness,ptin:_NightBrightness,varname:_NightBrightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_RemapRange,id:7805,x:32754,y:32718,varname:node_7805,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-6523-OUT;n:type:ShaderForge.SFN_Add,id:1122,x:32873,y:32582,varname:node_1122,prsc:2|A-4002-OUT,B-7805-OUT;n:type:ShaderForge.SFN_RemapRange,id:4161,x:32559,y:33050,varname:node_4161,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:0.1|IN-6479-OUT;n:type:ShaderForge.SFN_Add,id:8969,x:32742,y:32893,varname:node_8969,prsc:2|A-1156-OUT,B-4161-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1054,x:31389,y:32946,ptovrint:False,ptlb:CurrentTime,ptin:_CurrentTime,varname:node_1054,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Set,id:6701,x:31537,y:32770,varname:time,prsc:2|IN-1054-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4252,x:32987,y:32050,ptovrint:False,ptlb:FogDensity,ptin:_FogDensity,varname:node_4252,prsc:2,glob:True,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ScreenPos,id:6549,x:31757,y:31928,varname:node_6549,prsc:2,sctp:0;n:type:ShaderForge.SFN_RemapRange,id:9855,x:31969,y:31920,varname:node_9855,prsc:2,frmn:-1,frmx:1,tomn:-0.1,tomx:0|IN-6549-U;n:type:ShaderForge.SFN_Add,id:8833,x:31341,y:31900,varname:node_8833,prsc:2|A-4252-OUT,B-7893-RGB;n:type:ShaderForge.SFN_Clamp01,id:7928,x:31529,y:31900,varname:node_7928,prsc:2|IN-8833-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5438,x:31570,y:32121,ptovrint:False,ptlb:Fog Light,ptin:_FogLight,varname:_FogLight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7893-RGB,B-7928-OUT;proporder:4805-5983-6235-7893-7313-3755-4079-5144-4628-6286-4879-5110-6523-6479-5438;pass:END;sub:END;*/

Shader "Shader Forge/test_Building_MOAS" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "black" {}
        _Color ("Color", Color) = (1,1,1,1)
        _ColorRamp ("ColorRamp", 2D) = "gray" {}
        _WindowRamp ("WindowRamp", 2D) = "black" {}
        _WindowTime ("WindowTime", 2D) = "black" {}
        _WindowColor ("WindowColor", Color) = (1,1,1,1)
        _DayContrast ("DayContrast", Range(0, 1)) = 0.422488
        _NightContrast ("NightContrast", Range(0, 1)) = 0.676643
        _Brightness ("Brightness", Range(0, 1)) = 0
        [MaterialToggle] _OverlayBlend ("OverlayBlend", Float ) = 0
        _FogColor ("FogColor", Color) = (0.5190311,0.6517599,0.7058823,1)
        _Fogcolor2 ("Fogcolor2", Color) = (0.2463235,0.3740366,0.5,1)
        _DayBrightness ("DayBrightness", Range(0, 1)) = 0.5
        _NightBrightness ("NightBrightness", Range(0, 1)) = 0.5
        [MaterialToggle] _FogLight ("Fog Light", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
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
                float node_6709 = saturate((i.posWorld.b*0.01+0.0));
                float Zposition = node_6709;
                float node_7760 = (node_6709*_FogDensity);
                float fogtimer = node_7760;
                half2 node_4884 = float2(_CurrentTime,0.5);
                half4 _WindowRamp_var = tex2D(_WindowRamp,TRANSFORM_TEX(node_4884, _WindowRamp));
                fixed4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_7457 = 0.0;
                float node_11 = (_NightContrast*0.5+0.5);
                float node_4977 = (1.0 - node_11);
                float3 node_8969 = ((node_4977 + ( (_MainTex_var.rgb - node_7457) * (node_11 - node_4977) ) / (1.0 - node_7457))+(_NightBrightness*0.2+-0.1));
                half4 _ColorRamp_var = tex2D(_ColorRamp,TRANSFORM_TEX(node_4884, _ColorRamp));
                float3 node_6291 = saturate(((_Color.rgb*i.vertexColor.rgb*lerp(saturate(((pow(_MainTex_var.rgb,(_DayContrast*2.0+1.0))*(_DayContrast*1.0+1.0))+(_DayBrightness*0.2+-0.1))),node_8969,_ColorRamp_var.a))+(_Brightness*0.2+-0.1)));
                float3 _OverlayBlend_var = lerp( saturate(( node_6291 > 0.5 ? (_ColorRamp_var.rgb/((1.0-node_6291)*2.0)) : (1.0-(((1.0-_ColorRamp_var.rgb)*0.5)/node_6291)))), (pow(saturate(( _ColorRamp_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_ColorRamp_var.rgb-0.5))*(1.0-node_6291)) : (2.0*_ColorRamp_var.rgb*node_6291) )),5.0)*1.5), _OverlayBlend );
                float daynightramp = _ColorRamp_var.a;
                float node_7722 = daynightramp;
                float3 node_5553 = lerp(_FogColor.rgb,_Fogcolor2.rgb,node_7722);
                float3 nightcontrast = node_8969;
                float3 emissive = ((saturate((lerp(_WindowTime_var.r,saturate((_WindowTime_var.g*1.5*(1.0 - Zposition))),fogtimer)*((i.screenPos.r*0.05+-0.05)+(lerp( _WindowRamp_var.rgb, saturate((_FogDensity+_WindowRamp_var.rgb)), _FogLight )*2.0))))*_WindowColor.rgb)+lerp(lerp(_OverlayBlend_var,(_OverlayBlend_var*0.1+0.0),_FogDensity),lerp((node_5553*nightcontrast),node_5553,node_7722),node_7760));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Sprites/Default"
    CustomEditor "ShaderForgeMaterialInspector"
}
