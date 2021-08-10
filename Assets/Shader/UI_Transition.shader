// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:4,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:8848,x:32926,y:32708,varname:node_8848,prsc:2|emission-1383-OUT;n:type:ShaderForge.SFN_Tex2d,id:8854,x:31684,y:33051,ptovrint:False,ptlb:Mask,ptin:_Mask,varname:_Mask,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8a75e78ce03d6bf4aa7ab9b759c2ca32,ntxv:0,isnm:False|UVIN-4292-OUT;n:type:ShaderForge.SFN_ScreenPos,id:7141,x:31106,y:33047,varname:node_7141,prsc:2,sctp:1;n:type:ShaderForge.SFN_Clamp01,id:1383,x:32436,y:33105,varname:node_1383,prsc:2|IN-8776-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5718,x:30855,y:33716,ptovrint:False,ptlb:Progress,ptin:_Progress,varname:_Progress,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Vector1,id:8967,x:32002,y:33370,varname:node_8967,prsc:2,v1:3;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:4292,x:31480,y:33051,varname:node_4292,prsc:1|IN-7141-UVOUT,IMIN-556-OUT,IMAX-9417-OUT,OMIN-3896-OUT,OMAX-3369-OUT;n:type:ShaderForge.SFN_OneMinus,id:3896,x:31458,y:33319,varname:node_3896,prsc:1|IN-3369-OUT;n:type:ShaderForge.SFN_RemapRange,id:3369,x:31256,y:33405,varname:node_3369,prsc:1,frmn:0,frmx:1,tomn:0,tomx:0.5|IN-488-OUT;n:type:ShaderForge.SFN_Add,id:8432,x:32015,y:33152,varname:node_8432,prsc:2|A-8854-RGB,B-2124-OUT;n:type:ShaderForge.SFN_Negate,id:2124,x:31551,y:33649,varname:node_2124,prsc:2|IN-5718-OUT;n:type:ShaderForge.SFN_Multiply,id:8776,x:32222,y:33162,varname:node_8776,prsc:2|A-8432-OUT,B-8967-OUT;n:type:ShaderForge.SFN_OneMinus,id:488,x:31057,y:33506,varname:node_488,prsc:2|IN-5718-OUT;n:type:ShaderForge.SFN_Vector1,id:9417,x:31159,y:33271,varname:node_9417,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:556,x:31192,y:33173,varname:node_556,prsc:1,v1:-1;proporder:8854-5718;pass:END;sub:END;*/

Shader "UI/Transition" {
    Properties {
        _Mask ("Mask", 2D) = "white" {}
        _Progress ("Progress", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend DstColor Zero
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Mask; uniform float4 _Mask_ST;
            uniform half _Progress;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos(v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
////// Lighting:
////// Emissive:
                half node_556 = (-1.0);
                half node_3369 = ((1.0 - _Progress)*0.5+0.0);
                half node_3896 = (1.0 - node_3369);
                half2 node_4292 = (node_3896 + ( (float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg - node_556) * (node_3369 - node_3896) ) / (1.0 - node_556));
                half4 _Mask_var = tex2D(_Mask,TRANSFORM_TEX(node_4292, _Mask));
                float3 emissive = saturate(((_Mask_var.rgb+(-1*_Progress))*3.0));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
