// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:Sprites/Default,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:True;n:type:ShaderForge.SFN_Final,id:1873,x:33304,y:32741,varname:node_1873,prsc:2|emission-3439-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31748,y:32761,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32848,y:32773,cmnt:RGB,varname:node_1086,prsc:2|A-7619-OUT,B-5983-RGB,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:32530,y:32983,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32500,y:33201,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:603,x:32844,y:33055,cmnt:A,varname:node_603,prsc:2|A-2789-OUT,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_Tex2d,id:5582,x:31762,y:32516,ptovrint:False,ptlb:CloudTex,ptin:_CloudTex,varname:_CloudTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:5745,x:32553,y:32582,varname:node_5745,prsc:2|A-4805-RGB,B-2878-OUT,T-8898-OUT;n:type:ShaderForge.SFN_Slider,id:805,x:31683,y:33091,ptovrint:False,ptlb:GlowIntensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:2789,x:32485,y:32767,varname:node_2789,prsc:2|A-4805-A,B-5582-A,T-8898-OUT;n:type:ShaderForge.SFN_Color,id:4775,x:32239,y:32163,ptovrint:False,ptlb:FlashColor,ptin:_FlashColor,varname:_FlashColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Add,id:7619,x:32743,y:32542,varname:node_7619,prsc:2|A-6135-OUT,B-5745-OUT;n:type:ShaderForge.SFN_Multiply,id:6135,x:32553,y:32334,varname:node_6135,prsc:2|A-4775-RGB,B-4067-OUT;n:type:ShaderForge.SFN_Slider,id:4067,x:32161,y:32374,ptovrint:False,ptlb:FlashIntensity,ptin:_FlashIntensity,varname:_FlashIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:8898,x:32146,y:32959,varname:node_8898,prsc:2|IN-805-OUT;n:type:ShaderForge.SFN_Color,id:4779,x:31748,y:32301,ptovrint:False,ptlb:CloudColor,ptin:_CloudColor,varname:_CloudColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2878,x:32177,y:32505,varname:node_2878,prsc:2|A-4779-RGB,B-5582-RGB;n:type:ShaderForge.SFN_Multiply,id:3439,x:33071,y:32827,varname:node_3439,prsc:2|A-1086-OUT,B-603-OUT;proporder:4805-5983-4779-5582-805-4775-4067;pass:END;sub:END;*/

Shader "Shader Forge/test_thundercloud" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _CloudColor ("CloudColor", Color) = (1,1,1,1)
        _CloudTex ("CloudTex", 2D) = "white" {}
        _GlowIntensity ("GlowIntensity", Range(0, 1)) = 0
        _FlashColor ("FlashColor", Color) = (1,1,1,1)
        _FlashIntensity ("FlashIntensity", Range(0, 1)) = 0
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
            Blend One OneMinusSrcAlpha
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
            uniform float4 _Color;
            uniform sampler2D _CloudTex; uniform float4 _CloudTex_ST;
            uniform float _GlowIntensity;
            uniform float4 _FlashColor;
            uniform float _FlashIntensity;
            uniform float4 _CloudColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 _CloudTex_var = tex2D(_CloudTex,TRANSFORM_TEX(i.uv0, _CloudTex));
                float node_8898 = (1.0 - _GlowIntensity);
                float3 node_7619 = ((_FlashColor.rgb*_FlashIntensity)+lerp(_MainTex_var.rgb,(_CloudColor.rgb*_CloudTex_var.rgb),node_8898));
                float3 node_1086 = (node_7619*_Color.rgb*i.vertexColor.rgb); // RGB
                float node_603 = (lerp(_MainTex_var.a,_CloudTex_var.a,node_8898)*_Color.a*i.vertexColor.a); // A
                float3 emissive = (node_1086*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
