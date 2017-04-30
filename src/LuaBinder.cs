using Assets.Extends.EXNGUI.Compoment;
using Assets.Scripts.Game;
using Assets.Scripts.Tools.NGUI.Component;
using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Events;

public static class LuaBinder
{
	public static void Bind(LuaState L)
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		L.BeginModule(null);
		LuaInterface_DebuggerWrap.Register(L);
		UICameraWrap.Register(L);
		UISpriteAnimationWrap.Register(L);
		TypewriterEffectWrap.Register(L);
		EventDelegateWrap.Register(L);
		UIWidgetContainerWrap.Register(L);
		UIEventListenerWrap.Register(L);
		UIPanelWrap.Register(L);
		UILabelWrap.Register(L);
		UIGridWrap.Register(L);
		UITableWrap.Register(L);
		UIWidgetWrap.Register(L);
		UIRectWrap.Register(L);
		UIButtonWrap.Register(L);
		UIRootWrap.Register(L);
		UIBasicSpriteWrap.Register(L);
		UITextureWrap.Register(L);
		UISpriteWrap.Register(L);
		UIDragScrollViewWrap.Register(L);
		UISpriteDataWrap.Register(L);
		UICenterOnChildWrap.Register(L);
		UIWrapContentWrap.Register(L);
		UIToggleWrap.Register(L);
		TweenAlphaWrap.Register(L);
		TweenPositionWrap.Register(L);
		TweenRotationWrap.Register(L);
		TweenColorWrap.Register(L);
		TweenScaleWrap.Register(L);
		UITweenerWrap.Register(L);
		UIScrollViewWrap.Register(L);
		UIAtlasWrap.Register(L);
		UIInputWrap.Register(L);
		UISectorWrapContentWrap.Register(L);
		UIClickButtonWrap.Register(L);
		UIPopupMenuWrap.Register(L);
		SdkCallbackManagerWrap.Register(L);
		DebugConsoleWrap.Register(L);
		UIDragDropItemWrap.Register(L);
		SpringPositionWrap.Register(L);
		NGUIToolsWrap.Register(L);
		TweenScrollBarWrap.Register(L);
		UIScrollBarWrap.Register(L);
		UISliderWrap.Register(L);
		UIDrawCallWrap.Register(L);
		BetterList_UICameraWrap.Register(L);
		MultiResourceManagerWrap.Register(L);
		UIButtonColorWrap.Register(L);
		UIProgressBarWrap.Register(L);
		L.RegFunction("SDK_CALLBACK", new LuaCSFunction(LuaBinder.SDK_CALLBACK));
		L.BeginModule("UnityEngine");
		UnityEngine_ComponentWrap.Register(L);
		UnityEngine_TransformWrap.Register(L);
		UnityEngine_MaterialWrap.Register(L);
		UnityEngine_CameraWrap.Register(L);
		UnityEngine_AudioSourceWrap.Register(L);
		UnityEngine_BehaviourWrap.Register(L);
		UnityEngine_MonoBehaviourWrap.Register(L);
		UnityEngine_GameObjectWrap.Register(L);
		UnityEngine_TrackedReferenceWrap.Register(L);
		UnityEngine_ApplicationWrap.Register(L);
		UnityEngine_ColliderWrap.Register(L);
		UnityEngine_TimeWrap.Register(L);
		UnityEngine_TextureWrap.Register(L);
		UnityEngine_Texture2DWrap.Register(L);
		UnityEngine_ShaderWrap.Register(L);
		UnityEngine_RendererWrap.Register(L);
		UnityEngine_WWWWrap.Register(L);
		UnityEngine_ScreenWrap.Register(L);
		UnityEngine_CameraClearFlagsWrap.Register(L);
		UnityEngine_AudioClipWrap.Register(L);
		UnityEngine_AssetBundleWrap.Register(L);
		UnityEngine_AsyncOperationWrap.Register(L);
		UnityEngine_InputWrap.Register(L);
		UnityEngine_AnimationBlendModeWrap.Register(L);
		UnityEngine_AnimationCurveWrap.Register(L);
		UnityEngine_QueueModeWrap.Register(L);
		UnityEngine_PlayModeWrap.Register(L);
		UnityEngine_WrapModeWrap.Register(L);
		UnityEngine_QualitySettingsWrap.Register(L);
		UnityEngine_RenderSettingsWrap.Register(L);
		UnityEngine_FontStyleWrap.Register(L);
		UnityEngine_PlayerPrefsWrap.Register(L);
		UnityEngine_AndroidJavaObjectWrap.Register(L);
		L.BeginModule("Events");
		L.RegFunction("UnityAction", new LuaCSFunction(LuaBinder.UnityEngine_Events_UnityAction));
		L.EndModule();
		L.BeginModule("Camera");
		L.RegFunction("CameraCallback", new LuaCSFunction(LuaBinder.UnityEngine_Camera_CameraCallback));
		L.EndModule();
		L.BeginModule("Application");
		L.RegFunction("LogCallback", new LuaCSFunction(LuaBinder.UnityEngine_Application_LogCallback));
		L.RegFunction("AdvertisingIdentifierCallback", new LuaCSFunction(LuaBinder.UnityEngine_Application_AdvertisingIdentifierCallback));
		L.EndModule();
		L.BeginModule("AudioClip");
		L.RegFunction("PCMReaderCallback", new LuaCSFunction(LuaBinder.UnityEngine_AudioClip_PCMReaderCallback));
		L.RegFunction("PCMSetPositionCallback", new LuaCSFunction(LuaBinder.UnityEngine_AudioClip_PCMSetPositionCallback));
		L.EndModule();
		L.EndModule();
		L.BeginModule("UIBasicSprite");
		UIBasicSprite_FlipWrap.Register(L);
		L.EndModule();
		L.BeginModule("Assets");
		L.BeginModule("Scripts");
		Assets_Scripts_RpgCharacterWrap.Register(L);
		L.BeginModule("Tools");
		L.BeginModule("NGUI");
		L.BeginModule("Component");
		Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2Wrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIDragItemWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIGridOptimizeSpringWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UITweenIntNumberLabelWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UITweenSizeWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UITweenFillAmountWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIDepthModifierWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIScrollGridWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIOnClickPositionWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIClickListenerWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UITweenScrollViewWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIDragEventWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UITrimGridWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialColorWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIBWTextureWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_UIDoubleOutLineLabelWrap.Register(L);
		Assets_Scripts_Tools_NGUI_Component_TweenSpriteMaterialFloatWrap.Register(L);
		L.BeginModule("UICenterOnChildV2");
		L.RegFunction("OnDragFinishedCenter", new LuaCSFunction(LuaBinder.Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter));
		L.EndModule();
		L.EndModule();
		L.BeginModule("Camera");
		Assets_Scripts_Tools_NGUI_Camera_SimpleCameraFadeWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Component");
		Assets_Scripts_Tools_Component_CameraShakerWrap.Register(L);
		Assets_Scripts_Tools_Component_ProjectileLineWrap.Register(L);
		Assets_Scripts_Tools_Component_Main3DCameraWrap.Register(L);
		Assets_Scripts_Tools_Component_Scene2DConfigWrap.Register(L);
		Assets_Scripts_Tools_Component_TweenPositionXYZWrap.Register(L);
		Assets_Scripts_Tools_Component_NcSoloistWrap.Register(L);
		Assets_Scripts_Tools_Component_SceneBakeDataWrap.Register(L);
		Assets_Scripts_Tools_Component_NcAnimationRootWrap.Register(L);
		Assets_Scripts_Tools_Component_LateUpdaterWrap.Register(L);
		L.EndModule();
		L.BeginModule("Sound");
		Assets_Scripts_Tools_Sound_LoginGameVolumeWrap.Register(L);
		Assets_Scripts_Tools_Sound_BattleEffectSoundWrap.Register(L);
		Assets_Scripts_Tools_Sound_LuaGameVolumeWrap.Register(L);
		L.EndModule();
		L.BeginModule("Lua");
		Assets_Scripts_Tools_Lua_LuaReferenceCounterWrap.Register(L);
		L.EndModule();
		L.BeginModule("Event");
		Assets_Scripts_Tools_Event_LuaEventAdapterWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Game");
		Assets_Scripts_Game_GameEntryWrap.Register(L);
		Assets_Scripts_Game_ClientConfigWrap.Register(L);
		Assets_Scripts_Game_LuaEntryWrap.Register(L);
		Assets_Scripts_Game_HexTileSpriteWrap.Register(L);
		Assets_Scripts_Game_GlobalClickEffectWrap.Register(L);
		L.BeginModule("Global");
		Assets_Scripts_Game_Global_GlobalUniqueObjectWrap.Register(L);
		L.EndModule();
		L.BeginModule("SDK");
		Assets_Scripts_Game_SDK_SMSManagerWrap.Register(L);
		Assets_Scripts_Game_SDK_WXManagerWrap.Register(L);
		Assets_Scripts_Game_SDK_ShareSDKManagerWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Performance");
		Assets_Scripts_Performance_Battle3DPerformanceWrap.Register(L);
		Assets_Scripts_Performance_BBProxyWrap.Register(L);
		Assets_Scripts_Performance_BTProxyWrap.Register(L);
		Assets_Scripts_Performance_NodeCanvas3DTestWrap.Register(L);
		Assets_Scripts_Performance_NodeCanvasLuaToolWrap.Register(L);
		L.EndModule();
		L.BeginModule("Platform");
		L.BeginModule("Android");
		Assets_Scripts_Platform_Android_AndroidBridgeWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Net");
		Assets_Scripts_Net_ProjectXUpdaterWrap.Register(L);
		L.EndModule();
		L.BeginModule("Map");
		L.BeginModule("Tool");
		Assets_Scripts_Map_Tool_LuaToCToolWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("Extends");
		L.BeginModule("EXNGUI");
		L.BeginModule("Compoment");
		Assets_Extends_EXNGUI_Compoment_UIRadioBtnGroupWrap.Register(L);
		Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.Register(L);
		Assets_Extends_EXNGUI_Compoment_UIPlayTweenGroupWrap.Register(L);
		Assets_Extends_EXNGUI_Compoment_UIColorCtrlWrap.Register(L);
		Assets_Extends_EXNGUI_Compoment_UIClipWrap.Register(L);
		L.BeginModule("UIClip");
		Assets_Extends_EXNGUI_Compoment_UIClip_StyleWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("Tools");
		L.BeginModule("Script");
		L.BeginModule("Event");
		Assets_Tools_Script_Event_Signal_Assets_Extends_EXNGUI_Compoment_UISelectionBtnWrap.Register(L);
		Assets_Tools_Script_Event_ApplicationEventWrap.Register(L);
		L.EndModule();
		L.BeginModule("Helper");
		Assets_Tools_Script_Helper_GameObjectUtilitiesWrap.Register(L);
		Assets_Tools_Script_Helper_ColorToolWrap.Register(L);
		L.EndModule();
		L.BeginModule("Serialized");
		L.BeginModule("LocalCache");
		Assets_Tools_Script_Serialized_LocalCache_PlayerPrefsCacheWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Go");
		Assets_Tools_Script_Go_UnityCompomentLifeWrap.Register(L);
		Assets_Tools_Script_Go_ParasiticComponentWrap.Register(L);
		L.EndModule();
		L.BeginModule("Sound");
		Assets_Tools_Script_Sound_SoundUtilitiesWrap.Register(L);
		L.EndModule();
		L.BeginModule("File");
		Assets_Tools_Script_File_ESFileWrap.Register(L);
		L.EndModule();
		L.BeginModule("Animation");
		L.BeginModule("Curve");
		Assets_Tools_Script_Animation_Curve_CurveAnimationWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("XQ");
		L.BeginModule("Framework");
		L.BeginModule("Lua");
		XQ_Framework_Lua_LuaUiWrap.Register(L);
		XQ_Framework_Lua_ILuaScriptBaseWrap.Register(L);
		L.BeginModule("Utility");
		XQ_Framework_Lua_Utility_LuaUtilWrap.Register(L);
		XQ_Framework_Lua_Utility_GameJsonCfgInfoWrap.Register(L);
		XQ_Framework_Lua_Utility_NGUIToolWrap.Register(L);
		XQ_Framework_Lua_Utility_NGUIMathLuaWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Language");
		XQ_Framework_Language_LanguageManagerWrap.Register(L);
		XQ_Framework_Language_LangInfoWrap.Register(L);
		L.EndModule();
		L.BeginModule("Utility");
		XQ_Framework_Utility_ShaderHelperWrap.Register(L);
		L.EndModule();
		L.BeginModule("Pay");
		XQ_Framework_Pay_PayManagerWrap.Register(L);
		L.EndModule();
		L.BeginModule("Network");
		L.BeginModule("Skynet");
		XQ_Framework_Network_Skynet_SocketDriverWrap.Register(L);
		XQ_Framework_Network_Skynet_SocketChannelWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("Game");
		L.BeginModule("Util");
		L.BeginModule("Unity");
		XQ_Game_Util_Unity_WordFilterWrap.Register(L);
		XQ_Game_Util_Unity_UnitySceneManagerWrap.Register(L);
		XQ_Game_Util_Unity_SystemMouseEventListenerWrap.Register(L);
		XQ_Game_Util_Unity_AnimationPlayerWrap.Register(L);
		XQ_Game_Util_Unity_ShadowMapLightWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("LuaFramework");
		LuaFramework_UtilWrap.Register(L);
		LuaFramework_ByteBufferWrap.Register(L);
		L.EndModule();
		L.BeginModule("UIWidget");
		UIWidget_PivotWrap.Register(L);
		L.RegFunction("OnDrawCallChange", new LuaCSFunction(LuaBinder.UIWidget_OnDrawCallChange));
		L.RegFunction("OnDimensionsChanged", new LuaCSFunction(LuaBinder.UIWidget_OnDimensionsChanged));
		L.RegFunction("OnPostFillCallback", new LuaCSFunction(LuaBinder.UIWidget_OnPostFillCallback));
		L.RegFunction("HitCheck", new LuaCSFunction(LuaBinder.UIWidget_HitCheck));
		L.EndModule();
		L.BeginModule("System");
		System_DateTimeWrap.Register(L);
		L.RegFunction("Action", new LuaCSFunction(LuaBinder.System_Action));
		L.RegFunction("Predicate_int", new LuaCSFunction(LuaBinder.System_Predicate_int));
		L.RegFunction("Action_int", new LuaCSFunction(LuaBinder.System_Action_int));
		L.RegFunction("Comparison_int", new LuaCSFunction(LuaBinder.System_Comparison_int));
		L.RegFunction("Comparison_UnityEngine_Transform", new LuaCSFunction(LuaBinder.System_Comparison_UnityEngine_Transform));
		L.RegFunction("Action_UnityEngine_Transform", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_Transform));
		L.RegFunction("Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn", new LuaCSFunction(LuaBinder.System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn));
		L.RegFunction("Func_UnityEngine_Transform_bool", new LuaCSFunction(LuaBinder.System_Func_UnityEngine_Transform_bool));
		L.RegFunction("Action_Assets_Extends_EXNGUI_Compoment_UIClip", new LuaCSFunction(LuaBinder.System_Action_Assets_Extends_EXNGUI_Compoment_UIClip));
		L.RegFunction("Action_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_GameObject));
		L.RegFunction("Action_UnityEngine_GameObject_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_GameObject_UnityEngine_GameObject));
		L.RegFunction("Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject));
		L.RegFunction("Func_UnityEngine_GameObject_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Func_UnityEngine_GameObject_UnityEngine_GameObject));
		L.RegFunction("Func_UnityEngine_GameObject_bool", new LuaCSFunction(LuaBinder.System_Func_UnityEngine_GameObject_bool));
		L.RegFunction("Predicate_UIRoot", new LuaCSFunction(LuaBinder.System_Predicate_UIRoot));
		L.RegFunction("Action_UIRoot", new LuaCSFunction(LuaBinder.System_Action_UIRoot));
		L.RegFunction("Comparison_UIRoot", new LuaCSFunction(LuaBinder.System_Comparison_UIRoot));
		L.RegFunction("Predicate_EventDelegate", new LuaCSFunction(LuaBinder.System_Predicate_EventDelegate));
		L.RegFunction("Action_EventDelegate", new LuaCSFunction(LuaBinder.System_Action_EventDelegate));
		L.RegFunction("Comparison_EventDelegate", new LuaCSFunction(LuaBinder.System_Comparison_EventDelegate));
		L.RegFunction("Action_Assets_Scripts_Game_IGameEntryTask_float_string", new LuaCSFunction(LuaBinder.System_Action_Assets_Scripts_Game_IGameEntryTask_float_string));
		L.RegFunction("Action_UnityEngine_Vector2", new LuaCSFunction(LuaBinder.System_Action_UnityEngine_Vector2));
		L.RegFunction("Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3", new LuaCSFunction(LuaBinder.System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3));
		L.RegFunction("Action_string", new LuaCSFunction(LuaBinder.System_Action_string));
		L.RegFunction("Action_bool", new LuaCSFunction(LuaBinder.System_Action_bool));
		L.RegFunction("Predicate_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Predicate_UnityEngine_GameObject));
		L.RegFunction("Comparison_UnityEngine_GameObject", new LuaCSFunction(LuaBinder.System_Comparison_UnityEngine_GameObject));
		L.RegFunction("Predicate_string", new LuaCSFunction(LuaBinder.System_Predicate_string));
		L.RegFunction("Comparison_string", new LuaCSFunction(LuaBinder.System_Comparison_string));
		L.RegFunction("Predicate_object", new LuaCSFunction(LuaBinder.System_Predicate_object));
		L.RegFunction("Action_object", new LuaCSFunction(LuaBinder.System_Action_object));
		L.RegFunction("Comparison_object", new LuaCSFunction(LuaBinder.System_Comparison_object));
		L.BeginModule("Collections");
		L.BeginModule("Generic");
		System_Collections_Generic_List_UIRootWrap.Register(L);
		System_Collections_Generic_List_EventDelegateWrap.Register(L);
		System_Collections_Generic_Dictionary_string_stringWrap.Register(L);
		System_Collections_Generic_List_UnityEngine_GameObjectWrap.Register(L);
		System_Collections_Generic_List_stringWrap.Register(L);
		System_Collections_Generic_List_objectWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("UnityStandardAssets");
		L.BeginModule("ImageEffects");
		UnityStandardAssets_ImageEffects_BlurOptimizedWrap.Register(L);
		UnityStandardAssets_ImageEffects_PostEffectsBaseWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("NodeCanvas");
		L.BeginModule("BehaviourTrees");
		NodeCanvas_BehaviourTrees_BehaviourTreeOwnerWrap.Register(L);
		L.EndModule();
		L.BeginModule("Framework");
		NodeCanvas_Framework_BlackboardWrap.Register(L);
		NodeCanvas_Framework_GraphOwner_NodeCanvas_BehaviourTrees_BehaviourTreeWrap.Register(L);
		NodeCanvas_Framework_GraphOwnerWrap.Register(L);
		L.EndModule();
		L.EndModule();
		L.BeginModule("UICamera");
		L.RegFunction("GetKeyStateFunc", new LuaCSFunction(LuaBinder.UICamera_GetKeyStateFunc));
		L.RegFunction("GetAxisFunc", new LuaCSFunction(LuaBinder.UICamera_GetAxisFunc));
		L.RegFunction("GetAnyKeyFunc", new LuaCSFunction(LuaBinder.UICamera_GetAnyKeyFunc));
		L.RegFunction("GetMouseDelegate", new LuaCSFunction(LuaBinder.UICamera_GetMouseDelegate));
		L.RegFunction("GetTouchDelegate", new LuaCSFunction(LuaBinder.UICamera_GetTouchDelegate));
		L.RegFunction("RemoveTouchDelegate", new LuaCSFunction(LuaBinder.UICamera_RemoveTouchDelegate));
		L.RegFunction("OnScreenResize", new LuaCSFunction(LuaBinder.UICamera_OnScreenResize));
		L.RegFunction("OnCustomInput", new LuaCSFunction(LuaBinder.UICamera_OnCustomInput));
		L.RegFunction("OnSchemeChange", new LuaCSFunction(LuaBinder.UICamera_OnSchemeChange));
		L.RegFunction("VoidDelegate", new LuaCSFunction(LuaBinder.UICamera_VoidDelegate));
		L.RegFunction("BoolDelegate", new LuaCSFunction(LuaBinder.UICamera_BoolDelegate));
		L.RegFunction("FloatDelegate", new LuaCSFunction(LuaBinder.UICamera_FloatDelegate));
		L.RegFunction("VectorDelegate", new LuaCSFunction(LuaBinder.UICamera_VectorDelegate));
		L.RegFunction("ObjectDelegate", new LuaCSFunction(LuaBinder.UICamera_ObjectDelegate));
		L.RegFunction("KeyCodeDelegate", new LuaCSFunction(LuaBinder.UICamera_KeyCodeDelegate));
		L.RegFunction("MoveDelegate", new LuaCSFunction(LuaBinder.UICamera_MoveDelegate));
		L.RegFunction("GetTouchCountCallback", new LuaCSFunction(LuaBinder.UICamera_GetTouchCountCallback));
		L.RegFunction("GetTouchCallback", new LuaCSFunction(LuaBinder.UICamera_GetTouchCallback));
		L.EndModule();
		L.BeginModule("EventDelegate");
		L.RegFunction("Callback", new LuaCSFunction(LuaBinder.EventDelegate_Callback));
		L.EndModule();
		L.BeginModule("UIEventListener");
		L.RegFunction("VoidDelegate", new LuaCSFunction(LuaBinder.UIEventListener_VoidDelegate));
		L.RegFunction("BoolDelegate", new LuaCSFunction(LuaBinder.UIEventListener_BoolDelegate));
		L.RegFunction("FloatDelegate", new LuaCSFunction(LuaBinder.UIEventListener_FloatDelegate));
		L.RegFunction("VectorDelegate", new LuaCSFunction(LuaBinder.UIEventListener_VectorDelegate));
		L.RegFunction("ObjectDelegate", new LuaCSFunction(LuaBinder.UIEventListener_ObjectDelegate));
		L.RegFunction("KeyCodeDelegate", new LuaCSFunction(LuaBinder.UIEventListener_KeyCodeDelegate));
		L.EndModule();
		L.BeginModule("UIPanel");
		L.RegFunction("OnGeometryUpdated", new LuaCSFunction(LuaBinder.UIPanel_OnGeometryUpdated));
		L.RegFunction("OnClippingMoved", new LuaCSFunction(LuaBinder.UIPanel_OnClippingMoved));
		L.EndModule();
		L.BeginModule("UILabel");
		L.RegFunction("ModifierFunc", new LuaCSFunction(LuaBinder.UILabel_ModifierFunc));
		L.EndModule();
		L.BeginModule("UIDrawCall");
		L.RegFunction("OnRenderCallback", new LuaCSFunction(LuaBinder.UIDrawCall_OnRenderCallback));
		L.RegFunction("OnRenderQueueChange", new LuaCSFunction(LuaBinder.UIDrawCall_OnRenderQueueChange));
		L.EndModule();
		L.BeginModule("UIGrid");
		L.RegFunction("OnReposition", new LuaCSFunction(LuaBinder.UIGrid_OnReposition));
		L.EndModule();
		L.BeginModule("UITable");
		L.RegFunction("OnReposition", new LuaCSFunction(LuaBinder.UITable_OnReposition));
		L.EndModule();
		L.BeginModule("SpringPanel");
		L.RegFunction("OnFinished", new LuaCSFunction(LuaBinder.SpringPanel_OnFinished));
		L.EndModule();
		L.BeginModule("UICenterOnChild");
		L.RegFunction("OnCenterCallback", new LuaCSFunction(LuaBinder.UICenterOnChild_OnCenterCallback));
		L.EndModule();
		L.BeginModule("UIWrapContent");
		L.RegFunction("OnInitializeItem", new LuaCSFunction(LuaBinder.UIWrapContent_OnInitializeItem));
		L.EndModule();
		L.BeginModule("UIToggle");
		L.RegFunction("Validate", new LuaCSFunction(LuaBinder.UIToggle_Validate));
		L.EndModule();
		L.BeginModule("UIScrollView");
		L.RegFunction("OnDragNotification", new LuaCSFunction(LuaBinder.UIScrollView_OnDragNotification));
		L.EndModule();
		L.BeginModule("UIInput");
		L.RegFunction("OnValidate", new LuaCSFunction(LuaBinder.UIInput_OnValidate));
		L.EndModule();
		L.BeginModule("UISectorWrapContent");
		L.RegFunction("OnWrapItem", new LuaCSFunction(LuaBinder.UISectorWrapContent_OnWrapItem));
		L.RegFunction("SwitchToCenterPanel", new LuaCSFunction(LuaBinder.UISectorWrapContent_SwitchToCenterPanel));
		L.EndModule();
		L.BeginModule("UIPopupMenu");
		L.RegFunction("OnPopupItemClick", new LuaCSFunction(LuaBinder.UIPopupMenu_OnPopupItemClick));
		L.EndModule();
		L.BeginModule("SpringPosition");
		L.RegFunction("OnFinished", new LuaCSFunction(LuaBinder.SpringPosition_OnFinished));
		L.EndModule();
		L.BeginModule("UIProgressBar");
		L.RegFunction("OnDragFinished", new LuaCSFunction(LuaBinder.UIProgressBar_OnDragFinished));
		L.EndModule();
		L.BeginModule("BetterList<UICamera>");
		L.RegFunction("CompareFunc", new LuaCSFunction(LuaBinder.BetterList_UICamera_CompareFunc));
		L.EndModule();
		L.EndModule();
		L.BeginPreLoad();
		L.AddPreLoad("UnityEngine.BoxCollider", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_BoxCollider), typeof(BoxCollider));
		L.AddPreLoad("UnityEngine.MeshCollider", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_MeshCollider), typeof(MeshCollider));
		L.AddPreLoad("UnityEngine.Animation", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_Animation), typeof(Animation));
		L.AddPreLoad("UnityEngine.AnimationClip", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_AnimationClip), typeof(AnimationClip));
		L.AddPreLoad("UnityEngine.AnimationState", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_AnimationState), typeof(AnimationState));
		L.AddPreLoad("UnityEngine.RenderTexture", new LuaCSFunction(LuaBinder.LuaOpen_UnityEngine_RenderTexture), typeof(RenderTexture));
		L.EndPreLoad();
		Debugger.Log("Register lua type cost time: {0}", Time.realtimeSinceStartup - realtimeSinceStartup);
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SDK_CALLBACK(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SDK_CALLBACK), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SDK_CALLBACK), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Events_UnityAction(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UnityAction), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UnityAction), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Camera_CameraCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Camera.CameraCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Application_LogCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Application.LogCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_Application_AdvertisingIdentifierCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Application.AdvertisingIdentifierCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Application.AdvertisingIdentifierCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_AudioClip_PCMReaderCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMReaderCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UnityEngine_AudioClip_PCMSetPositionCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMSetPositionCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(AudioClip.PCMSetPositionCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int Assets_Scripts_Tools_NGUI_Component_UICenterOnChildV2_OnDragFinishedCenter(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICenterOnChildV2.OnDragFinishedCenter), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICenterOnChildV2.OnDragFinishedCenter), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_OnDrawCallChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDrawCallChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDrawCallChange), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_OnDimensionsChanged(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDimensionsChanged), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnDimensionsChanged), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_OnPostFillCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.OnPostFillCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.OnPostFillCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWidget_HitCheck(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWidget.HitCheck), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWidget.HitCheck), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_int(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<int>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<int>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_int(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<int>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<int>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_int(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<int>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<int>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_UnityEngine_Transform(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<Transform>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<Transform>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_Transform(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<Transform>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<Transform>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_Assets_Extends_EXNGUI_Compoment_UISelectionBtn(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<UISelectionBtn>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<UISelectionBtn>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Func_UnityEngine_Transform_bool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Func<Transform, bool>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Func<Transform, bool>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_Assets_Extends_EXNGUI_Compoment_UIClip(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<UIClip>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<UIClip>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_GameObject_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_GameObject_UnityEngine_GameObject_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject, GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<GameObject, GameObject, GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Func_UnityEngine_GameObject_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Func<GameObject, GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Func<GameObject, GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Func_UnityEngine_GameObject_bool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Func<GameObject, bool>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Func<GameObject, bool>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_UIRoot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<UIRoot>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UIRoot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<UIRoot>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<UIRoot>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_UIRoot(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<UIRoot>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<UIRoot>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_EventDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<EventDelegate>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_EventDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<EventDelegate>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<EventDelegate>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_EventDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<EventDelegate>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<EventDelegate>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_Assets_Scripts_Game_IGameEntryTask_float_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<IGameEntryTask, float, string>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<IGameEntryTask, float, string>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_UnityEngine_Vector2(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<Vector2>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<Vector2>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Func_UnityEngine_Transform_int_UnityEngine_Vector3_UnityEngine_Vector3(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Func<Transform, int, Vector3, Vector3>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Func<Transform, int, Vector3, Vector3>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<string>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<string>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_bool(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<bool>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<bool>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_UnityEngine_GameObject(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<GameObject>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<GameObject>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<string>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<string>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_string(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<string>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<string>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Predicate_object(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Predicate<object>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Predicate<object>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Action_object(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Action<object>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Action<object>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int System_Comparison_object(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(Comparison<object>), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(Comparison<object>), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetKeyStateFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetKeyStateFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetAxisFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetAxisFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetAxisFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetAnyKeyFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetAnyKeyFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetAnyKeyFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetMouseDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetMouseDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetMouseDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetTouchDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_RemoveTouchDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.RemoveTouchDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.RemoveTouchDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_OnScreenResize(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnScreenResize), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnScreenResize), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_OnCustomInput(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnCustomInput), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnCustomInput), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_OnSchemeChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.OnSchemeChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.OnSchemeChange), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_VoidDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.VoidDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_BoolDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.BoolDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_FloatDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.FloatDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.FloatDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_VectorDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.VectorDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_ObjectDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.ObjectDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_KeyCodeDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.KeyCodeDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_MoveDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.MoveDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.MoveDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetTouchCountCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCountCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCountCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICamera_GetTouchCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICamera.GetTouchCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int EventDelegate_Callback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(EventDelegate.Callback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VoidDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.VoidDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_BoolDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.BoolDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_FloatDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.FloatDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.FloatDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_VectorDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.VectorDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.VectorDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_ObjectDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.ObjectDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.ObjectDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIEventListener_KeyCodeDelegate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIEventListener.KeyCodeDelegate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIEventListener.KeyCodeDelegate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPanel_OnGeometryUpdated(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPanel.OnGeometryUpdated), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPanel.OnGeometryUpdated), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPanel_OnClippingMoved(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPanel.OnClippingMoved), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPanel.OnClippingMoved), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UILabel_ModifierFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UILabel.ModifierFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UILabel.ModifierFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIDrawCall_OnRenderCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIDrawCall_OnRenderQueueChange(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderQueueChange), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIDrawCall.OnRenderQueueChange), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIGrid_OnReposition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIGrid.OnReposition), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIGrid.OnReposition), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UITable_OnReposition(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UITable.OnReposition), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UITable.OnReposition), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringPanel_OnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SpringPanel.OnFinished), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UICenterOnChild_OnCenterCallback(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UICenterOnChild.OnCenterCallback), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UICenterOnChild.OnCenterCallback), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIWrapContent_OnInitializeItem(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIWrapContent.OnInitializeItem), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIWrapContent.OnInitializeItem), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIToggle_Validate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIToggle.Validate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIToggle.Validate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIScrollView_OnDragNotification(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIScrollView.OnDragNotification), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIInput_OnValidate(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIInput.OnValidate), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIInput.OnValidate), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UISectorWrapContent_OnWrapItem(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.OnWrapItem), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.OnWrapItem), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UISectorWrapContent_SwitchToCenterPanel(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.SwitchToCenterPanel), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UISectorWrapContent.SwitchToCenterPanel), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIPopupMenu_OnPopupItemClick(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIPopupMenu.OnPopupItemClick), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIPopupMenu.OnPopupItemClick), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int SpringPosition_OnFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(SpringPosition.OnFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(SpringPosition.OnFinished), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int UIProgressBar_OnDragFinished(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(UIProgressBar.OnDragFinished), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(UIProgressBar.OnDragFinished), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int BetterList_UICamera_CompareFunc(IntPtr L)
	{
		int result;
		try
		{
			int num = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);
			if (num == 1)
			{
				Delegate ev = DelegateFactory.CreateDelegate(typeof(BetterList<UICamera>.CompareFunc), func);
				ToLua.Push(L, ev);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate ev2 = DelegateFactory.CreateDelegate(typeof(BetterList<UICamera>.CompareFunc), func, self);
				ToLua.Push(L, ev2);
			}
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_BoxCollider(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_BoxColliderWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(BoxCollider));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_MeshCollider(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_MeshColliderWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(MeshCollider));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_Animation(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_AnimationWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(Animation));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_AnimationClip(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_AnimationClipWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(AnimationClip));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_AnimationState(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_AnimationStateWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(AnimationState));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}

	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	private static int LuaOpen_UnityEngine_RenderTexture(IntPtr L)
	{
		int result;
		try
		{
			LuaState luaState = LuaState.Get(L);
			luaState.BeginPreModule("UnityEngine");
			UnityEngine_RenderTextureWrap.Register(luaState);
			int metaReference = luaState.GetMetaReference(typeof(RenderTexture));
			luaState.EndPreModule(L, metaReference);
			result = 1;
		}
		catch (Exception e)
		{
			result = LuaDLL.toluaL_exception(L, e, null);
		}
		return result;
	}
}
