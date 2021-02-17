﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Aetherium.Utils
{
    public class MaterialControllerComponents
    {
        public class HGControllerFinder : MonoBehaviour
        {
            public Material Material;

            public void Start()
            {
                if (Material)
                {
                    switch (Material.shader.name)
                    {
                        case "Hopoo Games/Deferred/Standard":
                            var standardController = gameObject.AddComponent<HGStandardController>();
                            standardController.Material = Material;
                            break;
                        case "Hopoo Games/FX/Cloud Remap":
                            var cloudController = gameObject.AddComponent<HGCloudRemapController>();
                            cloudController.Material = Material;
                            break;
                        case "Hopoo Games/FX/Cloud Intersection Remap":
                            var intersectionController = gameObject.AddComponent<HGIntersectionController>();
                            intersectionController.Material = Material;
                            break;
                    }
                    Destroy(this);
                }
            }
        }

        public class HGStandardController : MonoBehaviour
        {
            public Material Material;

            public bool _EnableCutout;
            public Color _Color;
            public Texture _MainTex;
            public Vector2 _MainTexScale;
            public Vector2 _MainTexOffset;

            [Range(0f, 5f)]
            public float _NormalStrength;

            public Texture _NormalTex;
            public Vector2 _NormalTexScale;
            public Vector2 _NormalTexOffset;
            public Color _EmColor;
            public Texture _EmTex;

            [Range(0f, 10f)]
            public float _EmPower;

            [Range(0f, 1f)]
            public float _Smoothness;

            public bool _IgnoreDiffuseAlphaForSpeculars;

            public enum _RampInfoEnum
            {
                TwoTone,
                SmoothedTwoTone,
                Unlitish,
                Subsurface,
                Grass
            }
            public _RampInfoEnum _RampChoice;

            public enum _DecalLayerEnum
            {
                Default,
                Environment,
                Character,
                Misc
            }
            public _DecalLayerEnum _DecalLayer;

            [Range(0f, 1f)]
            public float _SpecularStrength;

            [Range(0.1f, 20f)]
            public float _SpecularExponent;

            public enum _CullEnum
            {
                Off,
                Front,
                Back
            }
            public _CullEnum _Cull_Mode;

            public bool _EnableDither;

            [Range(0f, 1f)]
            public float _FadeBias;

            public bool _EnableFresnelEmission;

            public Texture _FresnelRamp;

            [Range(0.1f, 20f)]
            public float _FresnelPower;

            public Texture _FresnelMask;

            [Range(0f, 20f)]
            public float _FresnelBoost;

            public bool _EnablePrinting;

            [Range(-25f, 25f)]
            public float _SliceHeight;

            [Range(0f, 10f)]
            public float _PrintBandHeight;

            [Range(0f, 1f)]
            public float _PrintAlphaDepth;

            public Texture _PrintAlphaTexture;
            public Vector2 _PrintAlphaTextureScale;
            public Vector2 _PrintAlphaTextureOffset;

            [Range(0f, 10f)]
            public float _PrintColorBoost;

            [Range(0f, 4f)]
            public float _PrintAlphaBias;

            [Range(0f, 1f)]
            public float _PrintEmissionToAlbedoLerp;

            public enum _PrintDirectionEnum
            {
                BottomUp,
                TopDown,
                BackToFront
            }
            public _PrintDirectionEnum _PrintDirection;

            public Texture _PrintRamp;

            [Range(-10f, 10f)]
            public float _EliteBrightnessMin;

            [Range(-10f, 10f)]
            public float _EliteBrightnessMax;

            public bool _EnableSplatmap;
            public bool _UseVertexColorsInstead;

            [Range(0f, 1f)]
            public float _BlendDepth;

            public Texture _SplatmapTex;
            public Vector2 _SplatmapTexScale;
            public Vector2 _SplatmapTexOffset;

            [Range(0f, 20f)]
            public float _SplatmapTileScale;

            public Texture _GreenChannelTex;
            public Texture _GreenChannelNormalTex;

            [Range(0f, 1f)]
            public float _GreenChannelSmoothness;

            [Range(-2f, 5f)]
            public float _GreenChannelBias;

            public Texture _BlueChannelTex;
            public Texture _BlueChannelNormalTex;

            [Range(0f, 1f)]
            public float _BlueChannelSmoothness;

            [Range(-2f, 5f)]
            public float _BlueChannelBias;

            public bool _EnableFlowmap;
            public Texture _FlowTexture;
            public Texture _FlowHeightmap;
            public Vector2 _FlowHeightmapScale;
            public Vector2 _FlowHeightmapOffset;
            public Texture _FlowHeightRamp;
            public Vector2 _FlowHeightRampScale;
            public Vector2 _FlowHeightRampOffset;

            [Range(-1f, 1f)]
            public float _FlowHeightBias;

            [Range(0.1f, 20f)]
            public float _FlowHeightPower;

            [Range(0.1f, 20f)]
            public float _FlowEmissionStrength;

            [Range(0f, 15f)]
            public float _FlowSpeed;

            [Range(0f, 5f)]
            public float _MaskFlowStrength;

            [Range(0f, 5f)]
            public float _NormalFlowStrength;

            [Range(0f, 10f)]
            public float _FlowTextureScaleFactor;

            public bool _EnableLimbRemoval;

            public void Start()
            {
                if (Material)
                {
                    _EnableCutout = Convert.ToBoolean(Material.GetFloat("_EnableCutout"));
                    _Color = Material.GetColor("_Color");
                    _MainTex = Material.GetTexture("_MainTex");
                    _MainTexScale = Material.GetTextureScale("_MainTex");
                    _MainTexOffset = Material.GetTextureOffset("_MainTex");
                    _NormalStrength = Material.GetFloat("_NormalStrength");
                    _NormalTex = Material.GetTexture("_NormalTex");
                    _NormalTexScale = Material.GetTextureScale("_NormalTex");
                    _NormalTexOffset = Material.GetTextureOffset("_NormalTex");
                    _EmColor = Material.GetColor("_EmColor");
                    _EmTex = Material.GetTexture("_EmTex");
                    _EmPower = Material.GetFloat("_EmPower");
                    _Smoothness = Material.GetFloat("_Smoothness");
                    _IgnoreDiffuseAlphaForSpeculars = Convert.ToBoolean(Material.GetFloat("_ForceSpecOn"));
                    _RampChoice = (_RampInfoEnum)(int)Material.GetFloat("_RampInfo");
                    _DecalLayer = (_DecalLayerEnum)(int)Material.GetFloat("_DecalLayer");
                    _SpecularStrength = Material.GetFloat("_SpecularStrength");
                    _SpecularExponent = Material.GetFloat("_SpecularExponent");
                    _Cull_Mode = (_CullEnum)(int)Material.GetFloat("_Cull");
                    _EnableDither = Convert.ToBoolean(Material.GetFloat("_DitherOn"));
                    _FadeBias = Material.GetFloat("_FadeBias");
                    _EnableFresnelEmission = Convert.ToBoolean(Material.GetFloat("_FEON"));
                    _FresnelRamp = Material.GetTexture("_FresnelRamp");
                    _FresnelPower = Material.GetFloat("_FresnelPower");
                    _FresnelMask = Material.GetTexture("_FresnelMask");
                    _FresnelBoost = Material.GetFloat("_FresnelBoost");
                    _EnablePrinting = Convert.ToBoolean(Material.GetFloat("_PrintOn"));
                    _SliceHeight = Material.GetFloat("_SliceHeight");
                    _PrintBandHeight = Material.GetFloat("_SliceBandHeight");
                    _PrintAlphaDepth = Material.GetFloat("_SliceAlphaDepth");
                    _PrintAlphaTexture = Material.GetTexture("_SliceAlphaTex");
                    _PrintAlphaTextureScale = Material.GetTextureScale("_SliceAlphaTex");
                    _PrintAlphaTextureOffset = Material.GetTextureOffset("_SliceAlphaTex");
                    _PrintColorBoost = Material.GetFloat("_PrintBoost");
                    _PrintAlphaBias = Material.GetFloat("_PrintBias");
                    _PrintEmissionToAlbedoLerp = Material.GetFloat("_PrintEmissionToAlbedoLerp");
                    _PrintDirection = (_PrintDirectionEnum)(int)Material.GetFloat("_PrintDirection");
                    _PrintRamp = Material.GetTexture("_PrintRamp");
                    _EliteBrightnessMin = Material.GetFloat("_EliteBrightnessMin");
                    _EliteBrightnessMax = Material.GetFloat("_EliteBrightnessMax");
                    _EnableSplatmap = Convert.ToBoolean(Material.GetFloat("_SplatmapOn"));
                    _UseVertexColorsInstead = Convert.ToBoolean(Material.GetFloat("_ColorsOn"));
                    _BlendDepth = Material.GetFloat("_Depth");
                    _SplatmapTex = Material.GetTexture("_SplatmapTex");
                    _SplatmapTexScale = Material.GetTextureScale("_SplatmapTex");
                    _SplatmapTexOffset = Material.GetTextureOffset("_SplatmapTex");
                    _SplatmapTileScale = Material.GetFloat("_SplatmapTileScale");
                    _GreenChannelTex = Material.GetTexture("_GreenChannelTex");
                    _GreenChannelNormalTex = Material.GetTexture("_GreenChannelNormalTex");
                    _GreenChannelSmoothness = Material.GetFloat("_GreenChannelSmoothness");
                    _GreenChannelBias = Material.GetFloat("_GreenChannelBias");
                    _BlueChannelTex = Material.GetTexture("_BlueChannelTex");
                    _BlueChannelNormalTex = Material.GetTexture("_BlueChannelNormalTex");
                    _BlueChannelSmoothness = Material.GetFloat("_BlueChannelSmoothness");
                    _BlueChannelBias = Material.GetFloat("_BlueChannelBias");
                    _EnableFlowmap = Convert.ToBoolean(Material.GetFloat("_FlowmapOn"));
                    _FlowTexture = Material.GetTexture("_FlowTex");
                    _FlowHeightmap = Material.GetTexture("_FlowHeightmap");
                    _FlowHeightmapScale = Material.GetTextureScale("_FlowHeightmap");
                    _FlowHeightmapOffset = Material.GetTextureOffset("_FlowHeightmap");
                    _FlowHeightRamp = Material.GetTexture("_FlowHeightRamp");
                    _FlowHeightRampScale = Material.GetTextureScale("_FlowHeightRamp");
                    _FlowHeightRampOffset = Material.GetTextureOffset("_FlowHeightRamp");
                    _FlowHeightBias = Material.GetFloat("_FlowHeightBias");
                    _FlowHeightPower = Material.GetFloat("_FlowHeightPower");
                    _FlowEmissionStrength = Material.GetFloat("_FlowEmissionStrength");
                    _FlowSpeed = Material.GetFloat("_FlowSpeed");
                    _MaskFlowStrength = Material.GetFloat("_FlowMaskStrength");
                    _NormalFlowStrength = Material.GetFloat("_FlowNormalStrength");
                    _FlowTextureScaleFactor = Material.GetFloat("_FlowTextureScaleFactor");
                    _EnableLimbRemoval = Convert.ToBoolean(Material.GetFloat("_LimbRemovalOn"));
                }
            }

            public void Update()
            {
                if (Material)
                {
                    Material.SetFloat("_EnableCutout", Convert.ToSingle(_EnableCutout));
                    Material.SetColor("_Color", _Color);

                    if (_MainTex)
                    {
                        Material.SetTexture("_MainTex", _MainTex);
                        Material.SetTextureScale("_MainTex", _MainTexScale);
                        Material.SetTextureOffset("_MainTex", _MainTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_MainTex", null);
                    }

                    Material.SetFloat("_NormalStrength", _NormalStrength);

                    if (_NormalTex)
                    {
                        Material.SetTexture("_NormalTex", _NormalTex);
                        Material.SetTextureScale("_NormalTex", _NormalTexScale);
                        Material.SetTextureOffset("_NormalTex", _NormalTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_NormalTex", null);
                    }

                    Material.SetColor("_EmColor", _EmColor);

                    if (_EmTex)
                    {
                        Material.SetTexture("_EmTex", _EmTex);
                    }
                    else
                    {
                        Material.SetTexture("_EmTex", null);
                    }

                    Material.SetFloat("_EmPower", _EmPower);
                    Material.SetFloat("_Smoothness", _Smoothness);
                    Material.SetFloat("_ForceSpecOn", Convert.ToSingle(_IgnoreDiffuseAlphaForSpeculars));
                    Material.SetFloat("_RampInfo", Convert.ToSingle(_RampChoice));
                    Material.SetFloat("_DecalLayer", Convert.ToSingle(_DecalLayer));
                    Material.SetFloat("_SpecularStrength", _SpecularStrength);
                    Material.SetFloat("_SpecularExponent", _SpecularExponent);
                    Material.SetFloat("_Cull", Convert.ToSingle(_Cull_Mode));
                    Material.SetFloat("_DitherOn", Convert.ToSingle(_EnableDither));
                    Material.SetFloat("_FadeBias", _FadeBias);
                    Material.SetFloat("_FEON", Convert.ToSingle(_EnableFresnelEmission));

                    if (_FresnelRamp)
                    {
                        Material.SetTexture("_FresnelRamp", _FresnelRamp);
                    }
                    else
                    {
                        Material.SetTexture("_FresnelRamp", null);
                    }

                    Material.SetFloat("_FresnelPower", _FresnelPower);

                    if (_FresnelMask)
                    {
                        Material.SetTexture("_FresnelMask", _FresnelMask);
                    }
                    else
                    {
                        Material.SetTexture("_FresnelMask", null);
                    }

                    Material.SetFloat("_FresnelBoost", _FresnelBoost);
                    Material.SetFloat("_PrintOn", Convert.ToSingle(_EnablePrinting));
                    Material.SetFloat("_SliceHeight", _SliceHeight);
                    Material.SetFloat("_SliceBandHeight", _PrintBandHeight);
                    Material.SetFloat("_SliceAlphaDepth", _PrintAlphaDepth);

                    if (_PrintAlphaTexture)
                    {
                        Material.SetTexture("_SliceAlphaTex", _PrintAlphaTexture);
                        Material.SetTextureScale("_SliceAlphaTex", _PrintAlphaTextureScale);
                        Material.SetTextureOffset("_SliceAlphaTex", _PrintAlphaTextureOffset);
                    }
                    else
                    {
                        Material.SetTexture("_SliceAlphaTex", null);
                    }

                    Material.SetFloat("_PrintBoost", _PrintColorBoost);
                    Material.SetFloat("_PrintBias", _PrintAlphaBias);
                    Material.SetFloat("_PrintEmissionToAlbedoLerp", _PrintEmissionToAlbedoLerp);
                    Material.SetFloat("_PrintDirection", Convert.ToSingle(_PrintDirection));

                    if (_PrintRamp)
                    {
                        Material.SetTexture("_PrintRamp", _PrintRamp);
                    }
                    else
                    {
                        Material.SetTexture("_PrintRamp", null);
                    }

                    Material.SetFloat("_EliteBrightnessMin", _EliteBrightnessMin);
                    Material.SetFloat("_EliteBrightnessMax", _EliteBrightnessMax);
                    Material.SetFloat("_SplatmapOn", Convert.ToSingle(_EnableSplatmap));
                    Material.SetFloat("_ColorsOn", Convert.ToSingle(_UseVertexColorsInstead));
                    Material.SetFloat("_Depth", _BlendDepth);

                    if (_SplatmapTex)
                    {
                        Material.SetTexture("_SplatmapTex", _SplatmapTex);
                        Material.SetTextureScale("_SplatmapTex", _SplatmapTexScale);
                        Material.SetTextureOffset("_SplatmapTex", _SplatmapTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_SplatmapTex", null);
                    }

                    Material.SetFloat("_SplatmapTileScale", _SplatmapTileScale);

                    if (_GreenChannelTex)
                    {
                        Material.SetTexture("_GreenChannelTex", _GreenChannelTex);
                    }
                    else
                    {
                        Material.SetTexture("_GreenChannelTex", null);
                    }

                    if (_GreenChannelNormalTex)
                    {
                        Material.SetTexture("_GreenChannelNormalTex", _GreenChannelNormalTex);
                    }
                    else
                    {
                        Material.SetTexture("_GreenChannelNormalTex", null);
                    }

                    Material.SetFloat("_GreenChannelSmoothness", _GreenChannelSmoothness);
                    Material.SetFloat("_GreenChannelBias", _GreenChannelBias);

                    if (_BlueChannelTex)
                    {
                        Material.SetTexture("_BlueChannelTex", _BlueChannelTex);
                    }
                    else
                    {
                        Material.SetTexture("_BlueChannelTex", null);
                    }

                    if (_BlueChannelNormalTex)
                    {
                        Material.SetTexture("_BlueChannelNormalTex", _BlueChannelNormalTex);
                    }
                    else
                    {
                        Material.SetTexture("_BlueChannelNormalTex", null);
                    }

                    Material.SetFloat("_BlueChannelSmoothness", _BlueChannelSmoothness);
                    Material.SetFloat("_BlueChannelBias", _BlueChannelBias);

                    Material.SetFloat("_FlowmapOn", Convert.ToSingle(_EnableFlowmap));

                    if (_FlowTexture)
                    {
                        Material.SetTexture("_FlowTex", _FlowTexture);
                    }
                    else
                    {
                        Material.SetTexture("_FlowTex", null);
                    }

                    if (_FlowHeightmap)
                    {
                        Material.SetTexture("_FlowHeightmap", _FlowHeightmap);
                        Material.SetTextureScale("_FlowHeightmap", _FlowHeightmapScale);
                        Material.SetTextureOffset("_FlowHeightmap", _FlowHeightmapOffset);
                    }
                    else
                    {
                        Material.SetTexture("_FlowHeightmap", null);
                    }

                    if (_FlowHeightRamp)
                    {
                        Material.SetTexture("_FlowHeightRamp", _FlowHeightRamp);
                        Material.SetTextureScale("_FlowHeightRamp", _FlowHeightRampScale);
                        Material.SetTextureOffset("_FlowHeightRamp", _FlowHeightRampOffset);
                    }
                    else
                    {
                        Material.SetTexture("_FlowHeightRamp", null);
                    }

                    Material.SetFloat("_FlowHeightBias", _FlowHeightBias);
                    Material.SetFloat("_FlowHeightPower", _FlowHeightPower);
                    Material.SetFloat("_FlowEmissionStrength", _FlowEmissionStrength);
                    Material.SetFloat("_FlowSpeed", _FlowSpeed);
                    Material.SetFloat("_FlowMaskStrength", _MaskFlowStrength);
                    Material.SetFloat("_FlowNormalStrength", _NormalFlowStrength);
                    Material.SetFloat("_FlowTextureScaleFactor", _FlowTextureScaleFactor);
                    Material.SetFloat("_LimbRemovalOn", Convert.ToSingle(_EnableLimbRemoval));
                }
            }

        }

        /// <summary>
        /// Attach to anything, and feed in a material that has the hgcloudremap shader.
        /// You then gain access to manipulate this in any Runtime Inspector of your choice.
        /// </summary>
        public class HGCloudRemapController : MonoBehaviour
        {
            public Material Material;

            public Color _Tint;
            public bool _DisableRemapping;
            public Texture _MainTex;
            public Vector2 _MainTexScale;
            public Vector2 _MainTexOffset;
            public Texture _RemapTex;
            public Vector2 _RemapTexScale;
            public Vector2 _RemapTexOffset;

            [Range(0f, 2f)]
            public float _SoftFactor;

            [Range(1f, 20f)]
            public float _BrightnessBoost;

            [Range(0f, 20f)]
            public float _AlphaBoost;

            [Range(0f, 1f)]
            public float _AlphaBias;

            public bool _UseUV1;
            public bool _FadeWhenNearCamera;

            [Range(0f, 1f)]
            public float _FadeCloseDistance;

            public enum _CullEnum
            {
                Off,
                Front,
                Back
            }
            public _CullEnum _Cull_Mode;

            public enum _ZTestEnum
            {
                Disabled,
                Never,
                Less,
                Equal,
                LessEqual,
                Greater,
                NotEqual,
                GreaterEqual,
                Always
            }
            public _ZTestEnum _ZTest_Mode;

            [Range(-10f, 10f)]
            public float _DepthOffset;

            public bool _CloudRemapping;
            public bool _DistortionClouds;

            [Range(-2f, 2f)]
            public float _DistortionStrength;

            public Texture _Cloud1Tex;
            public Vector2 _Cloud1TexScale;
            public Vector2 _Cloud1TexOffset;
            public Texture _Cloud2Tex;
            public Vector2 _Cloud2TexScale;
            public Vector2 _Cloud2TexOffset;
            public Vector4 _CutoffScroll;
            public bool _VertexColors;
            public bool _LuminanceForVertexAlpha;
            public bool _LuminanceForTextureAlpha;
            public bool _VertexOffset;
            public bool _FresnelFade;
            public bool _SkyboxOnly;

            [Range(-20f, 20f)]
            public float _FresnelPower;

            [Range(0f, 3f)]
            public float _VertexOffsetAmount;

            public void Start()
            {
                if (Material)
                {
                    _Tint = Material.GetColor("_TintColor");
                    _DisableRemapping = Convert.ToBoolean(Material.GetFloat("_DisableRemapOn"));
                    _MainTex = Material.GetTexture("_MainTex");
                    _MainTexScale = Material.GetTextureScale("_MainTex");
                    _MainTexOffset = Material.GetTextureOffset("_MainTex");
                    _RemapTex = Material.GetTexture("_RemapTex");
                    _RemapTexScale = Material.GetTextureScale("_RemapTex");
                    _RemapTexOffset = Material.GetTextureOffset("_RemapTex");
                    _SoftFactor = Material.GetFloat("_InvFade");
                    _BrightnessBoost = Material.GetFloat("_Boost");
                    _AlphaBoost = Material.GetFloat("_AlphaBoost");
                    _AlphaBias = Material.GetFloat("_AlphaBias");
                    _UseUV1 = Convert.ToBoolean(Material.GetFloat("_UseUV1On"));
                    _FadeWhenNearCamera = Convert.ToBoolean(Material.GetFloat("_FadeCloseOn"));
                    _FadeCloseDistance = Material.GetFloat("_FadeCloseDistance");
                    _Cull_Mode = (_CullEnum)(int)Material.GetFloat("_Cull");
                    _ZTest_Mode = (_ZTestEnum)(int)Material.GetFloat("_ZTest");
                    _DepthOffset = Material.GetFloat("_DepthOffset");
                    _CloudRemapping = Convert.ToBoolean(Material.GetFloat("_CloudsOn"));
                    _DistortionClouds = Convert.ToBoolean(Material.GetFloat("_CloudOffsetOn"));
                    _DistortionStrength = Material.GetFloat("_DistortionStrength");
                    _Cloud1Tex = Material.GetTexture("_Cloud1Tex");
                    _Cloud1TexScale = Material.GetTextureScale("_Cloud1Tex");
                    _Cloud1TexOffset = Material.GetTextureOffset("_Cloud1Tex");
                    _Cloud2Tex = Material.GetTexture("_Cloud2Tex");
                    _Cloud2TexScale = Material.GetTextureScale("_Cloud2Tex");
                    _Cloud2TexOffset = Material.GetTextureOffset("_Cloud2Tex");
                    _CutoffScroll = Material.GetVector("_CutoffScroll");
                    _VertexColors = Convert.ToBoolean(Material.GetFloat("_VertexColorOn"));
                    _LuminanceForVertexAlpha = Convert.ToBoolean(Material.GetFloat("_VertexAlphaOn"));
                    _LuminanceForTextureAlpha = Convert.ToBoolean(Material.GetFloat("_CalcTextureAlphaOn"));
                    _VertexOffset = Convert.ToBoolean(Material.GetFloat("_VertexOffsetOn"));
                    _FresnelFade = Convert.ToBoolean(Material.GetFloat("_FresnelOn"));
                    _SkyboxOnly = Convert.ToBoolean(Material.GetFloat("_SkyboxOnly"));
                    _FresnelPower = Material.GetFloat("_FresnelPower");
                    _VertexOffsetAmount = Material.GetFloat("_OffsetAmount");
                }
            }

            public void Update()
            {

                if (Material)
                {
                    Material.SetColor("_TintColor", _Tint);
                    Material.SetFloat("_DisableRemapOn", Convert.ToSingle(_DisableRemapping));

                    if (_MainTex)
                    {
                        Material.SetTexture("_MainTex", _MainTex);
                        Material.SetTextureScale("_MainTex", _MainTexScale);
                        Material.SetTextureOffset("_MainTex", _MainTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_MainTex", null);
                    }

                    if (_RemapTex)
                    {
                        Material.SetTexture("_RemapTex", _RemapTex);
                        Material.SetTextureScale("_RemapTex", _RemapTexScale);
                        Material.SetTextureOffset("_RemapTex", _RemapTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_RemapTex", null);
                    }

                    Material.SetFloat("_InvFade", _SoftFactor);
                    Material.SetFloat("_Boost", _BrightnessBoost);
                    Material.SetFloat("_AlphaBoost", _AlphaBoost);
                    Material.SetFloat("_AlphaBias", _AlphaBias);
                    Material.SetFloat("_UseUV1On", Convert.ToSingle(_UseUV1));
                    Material.SetFloat("_FadeCloseOn", Convert.ToSingle(_FadeWhenNearCamera));
                    Material.SetFloat("_FadeCloseDistance", _FadeCloseDistance);
                    Material.SetFloat("_Cull", Convert.ToSingle(_Cull_Mode));
                    Material.SetFloat("_ZTest", Convert.ToSingle(_ZTest_Mode));
                    Material.SetFloat("_DepthOffset", _DepthOffset);
                    Material.SetFloat("_CloudsOn", Convert.ToSingle(_CloudRemapping));
                    Material.SetFloat("_CloudOffsetOn", Convert.ToSingle(_DistortionClouds));
                    Material.SetFloat("_DistortionStrength", _DistortionStrength);

                    if (_Cloud1Tex)
                    {
                        Material.SetTexture("_Cloud1Tex", _Cloud1Tex);
                        Material.SetTextureScale("_Cloud1Tex", _Cloud1TexScale);
                        Material.SetTextureOffset("_Cloud1Tex", _Cloud1TexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_Cloud1Tex", null);
                    }

                    if (_Cloud2Tex)
                    {
                        Material.SetTexture("_Cloud2Tex", _Cloud2Tex);
                        Material.SetTextureScale("_Cloud2Tex", _Cloud2TexScale);
                        Material.SetTextureOffset("_Cloud2Tex", _Cloud2TexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_Cloud2Tex", null);
                    }

                    Material.SetVector("_CutoffScroll", _CutoffScroll);
                    Material.SetFloat("_VertexColorOn", Convert.ToSingle(_VertexColors));
                    Material.SetFloat("_VertexAlphaOn", Convert.ToSingle(_LuminanceForVertexAlpha));
                    Material.SetFloat("_CalcTextureAlphaOn", Convert.ToSingle(_LuminanceForTextureAlpha));
                    Material.SetFloat("_VertexOffsetOn", Convert.ToSingle(_VertexOffset));
                    Material.SetFloat("_FresnelOn", Convert.ToSingle(_FresnelFade));
                    Material.SetFloat("_SkyboxOnly", Convert.ToSingle(_SkyboxOnly));
                    Material.SetFloat("_FresnelPower", _FresnelPower);
                    Material.SetFloat("_OffsetAmount", _VertexOffsetAmount);
                }
            }
        }

        /// <summary>
        /// Attach to anything, and feed in a material that has the hgcloudintersectionremap shader.
        /// You then gain access to manipulate this in any Runtime Inspector of your choice.
        /// </summary>
        public class HGIntersectionController : MonoBehaviour
        {
            public Material Material;

            public enum _SrcBlendFloatEnum
            {
                Zero,
                One,
                DstColor,
                SrcColor,
                OneMinusDstColor,
                SrcAlpha,
                OneMinusSrcColor,
                DstAlpha,
                OneMinusDstAlpha,
                SrcAlphaSaturate,
                OneMinusSrcAlpha
            }
            public enum _DstBlendFloatEnum
            {
                Zero,
                One,
                DstColor,
                SrcColor,
                OneMinusDstColor,
                SrcAlpha,
                OneMinusSrcColor,
                DstAlpha,
                OneMinusDstAlpha,
                SrcAlphaSaturate,
                OneMinusSrcAlpha
            }
            public _SrcBlendFloatEnum _Source_Blend_Mode;
            public _DstBlendFloatEnum _Destination_Blend_Mode;

            public Color _Tint;
            public Texture _MainTex;
            public Vector2 _MainTexScale;
            public Vector2 _MainTexOffset;
            public Texture _Cloud1Tex;
            public Vector2 _Cloud1TexScale;
            public Vector2 _Cloud1TexOffset;
            public Texture _Cloud2Tex;
            public Vector2 _Cloud2TexScale;
            public Vector2 _Cloud2TexOffset;
            public Texture _RemapTex;
            public Vector2 _RemapTexScale;
            public Vector2 _RemapTexOffset;
            public Vector4 _CutoffScroll;

            [Range(0f, 30f)]
            public float _SoftFactor;

            [Range(0.1f, 20f)]
            public float _SoftPower;

            [Range(0f, 5f)]
            public float _BrightnessBoost;

            [Range(0.1f, 20f)]
            public float _RimPower;

            [Range(0f, 5f)]
            public float _RimStrength;

            [Range(0f, 20f)]
            public float _AlphaBoost;

            [Range(0f, 20f)]
            public float _IntersectionStrength;

            public enum _CullEnum
            {
                Off,
                Front,
                Back
            }
            public _CullEnum _Cull_Mode;

            public bool _IgnoreVertexColors;
            public bool _EnableTriplanarProjectionsForClouds;

            public void Start()
            {
                if (Material)
                {
                    _Source_Blend_Mode = (_SrcBlendFloatEnum)(int)Material.GetFloat("_SrcBlendFloat");
                    _Destination_Blend_Mode = (_DstBlendFloatEnum)(int)Material.GetFloat("_DstBlendFloat");
                    _Tint = Material.GetColor("_TintColor");
                    _MainTex = Material.GetTexture("_MainTex");
                    _MainTexScale = Material.GetTextureScale("_MainTex");
                    _MainTexOffset = Material.GetTextureOffset("_MainTex");
                    _Cloud1Tex = Material.GetTexture("_Cloud1Tex");
                    _Cloud1TexScale = Material.GetTextureScale("_Cloud1Tex");
                    _Cloud1TexOffset = Material.GetTextureOffset("_Cloud1Tex");
                    _Cloud2Tex = Material.GetTexture("_Cloud2Tex");
                    _Cloud2TexScale = Material.GetTextureScale("_Cloud2Tex");
                    _Cloud2TexOffset = Material.GetTextureOffset("_Cloud2Tex");
                    _RemapTex = Material.GetTexture("_RemapTex");
                    _RemapTexScale = Material.GetTextureScale("_RemapTex");
                    _RemapTexOffset = Material.GetTextureOffset("_RemapTex");
                    _CutoffScroll = Material.GetVector("_CutoffScroll");
                    _SoftFactor = Material.GetFloat("_InvFade");
                    _SoftPower = Material.GetFloat("_SoftPower");
                    _BrightnessBoost = Material.GetFloat("_Boost");
                    _RimPower = Material.GetFloat("_RimPower");
                    _RimStrength = Material.GetFloat("_RimStrength");
                    _AlphaBoost = Material.GetFloat("_AlphaBoost");
                    _IntersectionStrength = Material.GetFloat("_IntersectionStrength");
                    _Cull_Mode = (_CullEnum)(int)Material.GetFloat("_Cull");
                    _IgnoreVertexColors = Convert.ToBoolean(Material.GetFloat("_VertexColorsOn"));
                    _EnableTriplanarProjectionsForClouds = Convert.ToBoolean(Material.GetFloat("_TriplanarOn"));
                }
            }

            public void Update()
            {

                if (Material)
                {
                    Material.SetFloat("_SrcBlendFloat", Convert.ToSingle(_Source_Blend_Mode));
                    Material.SetFloat("_DstBlendFloat", Convert.ToSingle(_Destination_Blend_Mode));
                    Material.SetColor("_TintColor", _Tint);
                    if (_MainTex)
                    {
                        Material.SetTexture("_MainTex", _MainTex);
                        Material.SetTextureScale("_MainTex", _MainTexScale);
                        Material.SetTextureOffset("_MainTex", _MainTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_MainTex", null);
                    }

                    if (_Cloud1Tex)
                    {
                        Material.SetTexture("_Cloud1Tex", _Cloud1Tex);
                        Material.SetTextureScale("_Cloud1Tex", _Cloud1TexScale);
                        Material.SetTextureOffset("_Cloud1Tex", _Cloud1TexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_Cloud1Tex", null);
                    }

                    if (_Cloud2Tex)
                    {
                        Material.SetTexture("_Cloud2Tex", _Cloud2Tex);
                        Material.SetTextureScale("_Cloud2Tex", _Cloud2TexScale);
                        Material.SetTextureOffset("_Cloud2Tex", _Cloud2TexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_Cloud2Tex", null);
                    }

                    if (_RemapTex)
                    {
                        Material.SetTexture("_RemapTex", _RemapTex);
                        Material.SetTextureScale("_RemapTex", _RemapTexScale);
                        Material.SetTextureOffset("_RemapTex", _RemapTexOffset);
                    }
                    else
                    {
                        Material.SetTexture("_RemapTex", null);
                    }

                    Material.SetVector("_CutoffScroll", _CutoffScroll);
                    Material.SetFloat("_InvFade", _SoftFactor);
                    Material.SetFloat("_SoftPower", _SoftPower);
                    Material.SetFloat("_Boost", _BrightnessBoost);
                    Material.SetFloat("_RimPower", _RimPower);
                    Material.SetFloat("_RimStrength", _RimStrength);
                    Material.SetFloat("_AlphaBoost", _AlphaBoost);
                    Material.SetFloat("_IntersectionStrength", _IntersectionStrength);
                    Material.SetFloat("_Cull", Convert.ToSingle(_Cull_Mode));
                    Material.SetFloat("_VertexColorsOn", Convert.ToSingle(_IgnoreVertexColors));
                    Material.SetFloat("_TriplanarOn", Convert.ToSingle(_EnableTriplanarProjectionsForClouds));
                }
            }
        }

    }
}