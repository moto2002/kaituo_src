using System;
using System.Collections.Generic;
using UnityEngine;

public class NcSpriteFactory : NcEffectBehaviour
{
	[Serializable]
	public class NcFrameInfo
	{
		public int m_nFrameIndex;

		public bool m_bEmptyFrame;

		public int m_nTexWidth;

		public int m_nTexHeight;

		public Rect m_TextureUvOffset;

		public Rect m_FrameUvOffset;

		public Vector2 m_FrameScale;

		public Vector2 m_scaleFactor;
	}

	[SerializeField]
	[Serializable]
	public class NcSpriteNode
	{
		public bool m_bIncludedAtlas = true;

		public string m_TextureGUID = string.Empty;

		public string m_TextureName = string.Empty;

		public float m_fMaxTextureAlpha = 1f;

		public string m_SpriteName = string.Empty;

		public int m_nSkipFrame;

		public NcSpriteFactory.NcFrameInfo[] m_FrameInfos;

		public int m_nTilingX = 1;

		public int m_nTilingY = 1;

		public int m_nStartFrame;

		public int m_nFrameCount = 1;

		public bool m_bLoop;

		public int m_nLoopStartFrame;

		public int m_nLoopFrameCount;

		public int m_nLoopingCount;

		public float m_fFps = 20f;

		public float m_fTime;

		public int m_nNextSpriteIndex = -1;

		public int m_nTestMode;

		public float m_fTestSpeed = 1f;

		public bool m_bEffectInstantiate = true;

		public GameObject m_EffectPrefab;

		public int m_nSpriteFactoryIndex = -1;

		public int m_nEffectFrame;

		public bool m_bEffectOnlyFirst = true;

		public bool m_bEffectDetach = true;

		public float m_fEffectSpeed = 1f;

		public float m_fEffectScale = 1f;

		public Vector3 m_EffectPos = Vector3.zero;

		public Vector3 m_EffectRot = Vector3.zero;

		public AudioClip m_AudioClip;

		public int m_nSoundFrame;

		public bool m_bSoundOnlyFirst = true;

		public bool m_bSoundLoop;

		public float m_fSoundVolume = 1f;

		public float m_fSoundPitch = 1f;

		public NcSpriteFactory.NcSpriteNode GetClone()
		{
			return null;
		}

		public int GetStartFrame()
		{
			if (this.m_FrameInfos == null || this.m_FrameInfos.Length == 0)
			{
				return 0;
			}
			return this.m_FrameInfos[0].m_nFrameIndex;
		}

		public void SetEmpty()
		{
			this.m_FrameInfos = null;
			this.m_TextureGUID = string.Empty;
		}

		public bool IsEmptyTexture()
		{
			return this.m_TextureGUID == string.Empty;
		}

		public bool IsUnused()
		{
			return !this.m_bIncludedAtlas;
		}
	}

	[SerializeField]
	public enum MESH_TYPE
	{
		BuiltIn_Plane,
		BuiltIn_TwosidePlane
	}

	public enum ALIGN_TYPE
	{
		TOP,
		CENTER,
		BOTTOM,
		LEFTCENTER,
		RIGHTCENTER
	}

	public enum SPRITE_TYPE
	{
		NcSpriteTexture,
		NcSpriteAnimation,
		Auto
	}

	public enum SHOW_TYPE
	{
		NONE,
		ALL,
		SPRITE,
		ANIMATION,
		EFFECT
	}

	public NcSpriteFactory.SPRITE_TYPE m_SpriteType = NcSpriteFactory.SPRITE_TYPE.Auto;

	public List<NcSpriteFactory.NcSpriteNode> m_SpriteList;

	public int m_nCurrentIndex;

	public int m_nMaxAtlasTextureSize = 2048;

	public bool m_bNeedRebuild = true;

	public int m_nBuildStartIndex;

	public float m_fSpriteResizeRate = 1f;

	public bool m_bTrimBlack = true;

	public bool m_bTrimAlpha = true;

	public float m_fUvScale = 1f;

	public float m_fTextureRatio = 1f;

	public GameObject m_CurrentEffect;

	public NcAttachSound m_CurrentSound;

	protected bool m_bEndSprite = true;

	public NcSpriteFactory.SHOW_TYPE m_ShowType = NcSpriteFactory.SHOW_TYPE.SPRITE;

	public bool m_bShowEffect = true;

	public bool m_bTestMode = true;

	public bool m_bSequenceMode;

	protected bool m_bbInstance;

	public bool IsUnused(int nNodeIndex)
	{
		return this.m_SpriteList[nNodeIndex].IsUnused() || nNodeIndex < this.m_nBuildStartIndex;
	}

	public NcSpriteFactory.NcSpriteNode GetSpriteNode(int nIndex)
	{
		if (this.m_SpriteList == null || nIndex < 0 || this.m_SpriteList.Count <= nIndex)
		{
			return null;
		}
		return this.m_SpriteList[nIndex];
	}

	public NcSpriteFactory.NcSpriteNode GetSpriteNode(string spriteName)
	{
		if (this.m_SpriteList == null)
		{
			return null;
		}
		foreach (NcSpriteFactory.NcSpriteNode current in this.m_SpriteList)
		{
			if (current.m_SpriteName == spriteName)
			{
				return current;
			}
		}
		return null;
	}

	public int GetSpriteNodeIndex(string spriteName)
	{
		if (this.m_SpriteList == null)
		{
			return -1;
		}
		for (int i = 0; i < this.m_SpriteList.Count; i++)
		{
			if (this.m_SpriteList[i].m_SpriteName == spriteName)
			{
				return i;
			}
		}
		return -1;
	}

	public NcSpriteFactory.NcSpriteNode SetSpriteNode(int nIndex, NcSpriteFactory.NcSpriteNode newInfo)
	{
		if (this.m_SpriteList == null || nIndex < 0 || this.m_SpriteList.Count <= nIndex)
		{
			return null;
		}
		NcSpriteFactory.NcSpriteNode result = this.m_SpriteList[nIndex];
		this.m_SpriteList[nIndex] = newInfo;
		return result;
	}

	public int AddSpriteNode()
	{
		NcSpriteFactory.NcSpriteNode item = new NcSpriteFactory.NcSpriteNode();
		if (this.m_SpriteList == null)
		{
			this.m_SpriteList = new List<NcSpriteFactory.NcSpriteNode>();
		}
		this.m_SpriteList.Add(item);
		return this.m_SpriteList.Count - 1;
	}

	public int AddSpriteNode(NcSpriteFactory.NcSpriteNode addSpriteNode)
	{
		if (this.m_SpriteList == null)
		{
			this.m_SpriteList = new List<NcSpriteFactory.NcSpriteNode>();
		}
		this.m_SpriteList.Add(addSpriteNode.GetClone());
		this.m_bNeedRebuild = true;
		return this.m_SpriteList.Count - 1;
	}

	public void DeleteSpriteNode(int nIndex)
	{
		if (this.m_SpriteList == null || nIndex < 0 || this.m_SpriteList.Count <= nIndex)
		{
			return;
		}
		this.m_bNeedRebuild = true;
		this.m_SpriteList.Remove(this.m_SpriteList[nIndex]);
	}

	public void MoveSpriteNode(int nSrcIndex, int nTarIndex)
	{
		NcSpriteFactory.NcSpriteNode item = this.m_SpriteList[nSrcIndex];
		this.m_SpriteList.Remove(item);
		this.m_SpriteList.Insert(nTarIndex, item);
	}

	public void ClearAllSpriteNode()
	{
		if (this.m_SpriteList == null)
		{
			return;
		}
		this.m_bNeedRebuild = true;
		this.m_SpriteList.Clear();
	}

	public int GetSpriteNodeCount()
	{
		if (this.m_SpriteList == null)
		{
			return 0;
		}
		return this.m_SpriteList.Count;
	}

	public NcSpriteFactory.NcSpriteNode GetCurrentSpriteNode()
	{
		if (this.m_SpriteList == null || this.m_SpriteList.Count <= this.m_nCurrentIndex)
		{
			return null;
		}
		return this.m_SpriteList[this.m_nCurrentIndex];
	}

	public Rect GetSpriteUvRect(int nStriteIndex, int nFrameIndex)
	{
		if (this.m_SpriteList.Count <= nStriteIndex || this.m_SpriteList[nStriteIndex].m_FrameInfos == null || this.m_SpriteList[nStriteIndex].m_FrameInfos.Length <= nFrameIndex)
		{
			return new Rect(0f, 0f, 0f, 0f);
		}
		return this.m_SpriteList[nStriteIndex].m_FrameInfos[nFrameIndex].m_TextureUvOffset;
	}

	public bool IsValidFactory()
	{
		return !this.m_bNeedRebuild;
	}

	private void Awake()
	{
		this.m_bbInstance = true;
	}

	public NcEffectBehaviour SetSprite(int nNodeIndex)
	{
		return this.SetSprite(nNodeIndex, true);
	}

	public NcEffectBehaviour SetSprite(string spriteName)
	{
		if (this.m_SpriteList == null)
		{
			return null;
		}
		int num = 0;
		foreach (NcSpriteFactory.NcSpriteNode current in this.m_SpriteList)
		{
			if (current.m_SpriteName == spriteName)
			{
				return this.SetSprite(num, true);
			}
			num++;
		}
		return null;
	}

	public NcEffectBehaviour SetSprite(int nNodeIndex, bool bRunImmediate)
	{
		if (this.m_SpriteList == null || nNodeIndex < 0 || this.m_SpriteList.Count <= nNodeIndex)
		{
			return null;
		}
		if (bRunImmediate)
		{
			this.OnChangingSprite(this.m_nCurrentIndex, nNodeIndex);
		}
		this.m_nCurrentIndex = nNodeIndex;
		NcSpriteAnimation component = base.GetComponent<NcSpriteAnimation>();
		if (component != null)
		{
			component.SetSpriteFactoryIndex(nNodeIndex, false);
			if (bRunImmediate)
			{
				component.ResetAnimation();
			}
		}
		NcSpriteTexture component2 = base.GetComponent<NcSpriteTexture>();
		if (component2 != null)
		{
			component2.SetSpriteFactoryIndex(nNodeIndex, -1, false);
			if (bRunImmediate)
			{
				this.CreateEffectObject();
			}
		}
		if (component != null)
		{
			return component;
		}
		if (component != null)
		{
			return component2;
		}
		return null;
	}

	public int GetCurrentSpriteIndex()
	{
		return this.m_nCurrentIndex;
	}

	public bool IsEndSprite()
	{
		return this.m_SpriteList == null || this.m_nCurrentIndex < 0 || this.m_SpriteList.Count <= this.m_nCurrentIndex || (this.IsUnused(this.m_nCurrentIndex) || this.m_SpriteList[this.m_nCurrentIndex].IsEmptyTexture()) || this.m_bEndSprite;
	}

	private void CreateEffectObject()
	{
		if (!this.m_bbInstance)
		{
			return;
		}
		if (!this.m_bShowEffect)
		{
			return;
		}
		this.DestroyEffectObject();
		if (base.transform.parent != null)
		{
			base.transform.parent.SendMessage("OnSpriteListEffectFrame", this.m_SpriteList[this.m_nCurrentIndex], SendMessageOptions.DontRequireReceiver);
		}
		if (this.m_SpriteList[this.m_nCurrentIndex].m_bEffectInstantiate)
		{
			this.m_CurrentEffect = this.CreateSpriteEffect(this.m_nCurrentIndex, base.transform);
			if (base.transform.parent != null)
			{
				base.transform.parent.SendMessage("OnSpriteListEffectInstance", this.m_CurrentEffect, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public GameObject CreateSpriteEffect(int nSrcSpriteIndex, Transform parentTrans)
	{
		GameObject gameObject = null;
		if (this.m_SpriteList[nSrcSpriteIndex].m_EffectPrefab != null)
		{
			gameObject = base.CreateGameObject("Effect_" + this.m_SpriteList[nSrcSpriteIndex].m_EffectPrefab.name);
			if (gameObject == null)
			{
				return null;
			}
			base.ChangeParent(parentTrans, gameObject.transform, true, null);
			NcAttachPrefab ncAttachPrefab = gameObject.AddComponent<NcAttachPrefab>();
			ncAttachPrefab.m_AttachPrefab = this.m_SpriteList[nSrcSpriteIndex].m_EffectPrefab;
			ncAttachPrefab.m_fPrefabSpeed = this.m_SpriteList[nSrcSpriteIndex].m_fEffectSpeed;
			ncAttachPrefab.m_bDetachParent = this.m_SpriteList[nSrcSpriteIndex].m_bEffectDetach;
			ncAttachPrefab.m_nSpriteFactoryIndex = this.m_SpriteList[nSrcSpriteIndex].m_nSpriteFactoryIndex;
			ncAttachPrefab.UpdateImmediately();
			gameObject.transform.localScale *= this.m_SpriteList[nSrcSpriteIndex].m_fEffectScale;
			gameObject.transform.localPosition += this.m_SpriteList[nSrcSpriteIndex].m_EffectPos;
			gameObject.transform.localRotation *= Quaternion.Euler(this.m_SpriteList[nSrcSpriteIndex].m_EffectRot);
		}
		return gameObject;
	}

	private void DestroyEffectObject()
	{
		if (this.m_CurrentEffect != null)
		{
			UnityEngine.Object.Destroy(this.m_CurrentEffect);
		}
		this.m_CurrentEffect = null;
	}

	private void CreateSoundObject(NcSpriteFactory.NcSpriteNode ncSpriteNode)
	{
		if (!this.m_bShowEffect)
		{
			return;
		}
		if (ncSpriteNode.m_AudioClip != null)
		{
			if (this.m_CurrentSound == null)
			{
				this.m_CurrentSound = base.gameObject.AddComponent<NcAttachSound>();
			}
			this.m_CurrentSound.m_AudioClip = ncSpriteNode.m_AudioClip;
			this.m_CurrentSound.m_bLoop = ncSpriteNode.m_bSoundLoop;
			this.m_CurrentSound.m_fVolume = ncSpriteNode.m_fSoundVolume;
			this.m_CurrentSound.m_fPitch = ncSpriteNode.m_fSoundPitch;
			this.m_CurrentSound.enabled = true;
			this.m_CurrentSound.Replay();
		}
	}

	public void OnChangingSprite(int nOldNodeIndex, int nNewNodeIndex)
	{
		this.m_bEndSprite = false;
		this.DestroyEffectObject();
	}

	public void OnAnimationStartFrame(NcSpriteAnimation spriteCom)
	{
	}

	public void OnAnimationChangingFrame(NcSpriteAnimation spriteCom, int nOldIndex, int nNewIndex, int nLoopCount)
	{
		if (this.m_SpriteList.Count <= this.m_nCurrentIndex)
		{
			return;
		}
		if (this.m_SpriteList[this.m_nCurrentIndex].m_EffectPrefab != null && (nOldIndex < this.m_SpriteList[this.m_nCurrentIndex].m_nEffectFrame || nNewIndex <= nOldIndex) && this.m_SpriteList[this.m_nCurrentIndex].m_nEffectFrame <= nNewIndex && (nLoopCount == 0 || !this.m_SpriteList[this.m_nCurrentIndex].m_bEffectOnlyFirst))
		{
			this.CreateEffectObject();
		}
		if (this.m_SpriteList[this.m_nCurrentIndex].m_AudioClip != null && (nOldIndex < this.m_SpriteList[this.m_nCurrentIndex].m_nSoundFrame || nNewIndex <= nOldIndex) && this.m_SpriteList[this.m_nCurrentIndex].m_nSoundFrame <= nNewIndex && (nLoopCount == 0 || !this.m_SpriteList[this.m_nCurrentIndex].m_bSoundOnlyFirst))
		{
			this.CreateSoundObject(this.m_SpriteList[this.m_nCurrentIndex]);
		}
	}

	public bool OnAnimationLastFrame(NcSpriteAnimation spriteCom, int nLoopCount)
	{
		if (this.m_SpriteList.Count <= this.m_nCurrentIndex)
		{
			return false;
		}
		this.m_bEndSprite = true;
		if (this.m_bSequenceMode)
		{
			if (this.m_nCurrentIndex < this.GetSpriteNodeCount() - 1)
			{
				if (((!this.m_SpriteList[this.m_nCurrentIndex].m_bLoop) ? 1 : 3) == nLoopCount)
				{
					this.SetSprite(this.m_nCurrentIndex + 1);
					return true;
				}
			}
			else
			{
				this.SetSprite(0);
			}
		}
		else
		{
			NcSpriteAnimation ncSpriteAnimation = this.SetSprite(this.m_SpriteList[this.m_nCurrentIndex].m_nNextSpriteIndex) as NcSpriteAnimation;
			if (ncSpriteAnimation != null)
			{
				ncSpriteAnimation.ResetAnimation();
				return true;
			}
		}
		return false;
	}

	public override void OnUpdateEffectSpeed(float fSpeedRate, bool bRuntime)
	{
	}

	public static void CreatePlane(MeshFilter meshFilter, float fUvScale, NcSpriteFactory.NcFrameInfo ncSpriteFrameInfo, bool bTrimCenterAlign, NcSpriteFactory.ALIGN_TYPE alignType, NcSpriteFactory.MESH_TYPE m_MeshType, float fHShowRate)
	{
		Vector2 vector = new Vector2(fUvScale * ncSpriteFrameInfo.m_FrameScale.x, fUvScale * ncSpriteFrameInfo.m_FrameScale.y);
		float num = (alignType != NcSpriteFactory.ALIGN_TYPE.BOTTOM) ? ((alignType != NcSpriteFactory.ALIGN_TYPE.TOP) ? 0f : (-1f * vector.y)) : (1f * vector.y);
		float num2 = (alignType != NcSpriteFactory.ALIGN_TYPE.LEFTCENTER) ? ((alignType != NcSpriteFactory.ALIGN_TYPE.RIGHTCENTER) ? 0f : (-1f * vector.x)) : (1f * vector.x);
		Rect frameUvOffset = ncSpriteFrameInfo.m_FrameUvOffset;
		if (bTrimCenterAlign)
		{
			frameUvOffset.center = Vector2.zero;
		}
		Vector3[] array = new Vector3[4];
		if (alignType == NcSpriteFactory.ALIGN_TYPE.LEFTCENTER && 0f < fHShowRate)
		{
			array[0] = new Vector3(frameUvOffset.xMax * vector.x * fHShowRate + num2 * fHShowRate, frameUvOffset.yMax * vector.y + num);
			array[1] = new Vector3(frameUvOffset.xMax * vector.x * fHShowRate + num2 * fHShowRate, frameUvOffset.yMin * vector.y + num);
		}
		else
		{
			array[0] = new Vector3(frameUvOffset.xMax * vector.x + num2, frameUvOffset.yMax * vector.y + num);
			array[1] = new Vector3(frameUvOffset.xMax * vector.x + num2, frameUvOffset.yMin * vector.y + num);
		}
		array[2] = new Vector3(frameUvOffset.xMin * vector.x + num2, frameUvOffset.yMin * vector.y + num);
		array[3] = new Vector3(frameUvOffset.xMin * vector.x + num2, frameUvOffset.yMax * vector.y + num);
		Color color = Color.white;
		if (meshFilter.mesh.colors != null && 0 < meshFilter.mesh.colors.Length)
		{
			color = meshFilter.mesh.colors[0];
		}
		Color[] colors = new Color[]
		{
			color,
			color,
			color,
			color
		};
		Vector3[] normals = new Vector3[]
		{
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f),
			new Vector3(0f, 0f, -1f)
		};
		Vector4[] tangents = new Vector4[]
		{
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f)
		};
		int[] triangles;
		if (m_MeshType == NcSpriteFactory.MESH_TYPE.BuiltIn_Plane)
		{
			triangles = new int[]
			{
				1,
				2,
				0,
				0,
				2,
				3
			};
		}
		else
		{
			triangles = new int[]
			{
				1,
				2,
				0,
				0,
				2,
				3,
				1,
				0,
				3,
				3,
				2,
				1
			};
		}
		Vector2[] array2 = new Vector2[4];
		float x = 1f;
		if (alignType == NcSpriteFactory.ALIGN_TYPE.LEFTCENTER && 0f < fHShowRate)
		{
			x = fHShowRate;
		}
		array2[0] = new Vector2(x, 1f);
		array2[1] = new Vector2(x, 0f);
		array2[2] = new Vector2(0f, 0f);
		array2[3] = new Vector2(0f, 1f);
		meshFilter.mesh.Clear();
		meshFilter.mesh.vertices = array;
		meshFilter.mesh.colors = colors;
		meshFilter.mesh.normals = normals;
		meshFilter.mesh.tangents = tangents;
		meshFilter.mesh.triangles = triangles;
		meshFilter.mesh.uv = array2;
		meshFilter.mesh.RecalculateBounds();
	}

	public static void CreateEmptyMesh(MeshFilter meshFilter)
	{
		int num = 3;
		Vector3[] array = new Vector3[num];
		Color[] array2 = new Color[num];
		Vector3[] array3 = new Vector3[num];
		Vector4[] array4 = new Vector4[num];
		int[] array5 = new int[num];
		Vector2[] array6 = new Vector2[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Vector3.zero;
			array2[i] = Color.white;
			array3[i] = Vector3.zero;
			array4[i] = Vector4.zero;
			array5[i] = 0;
			array6[i] = Vector2.zero;
		}
		meshFilter.mesh.Clear();
		meshFilter.mesh.vertices = array;
		meshFilter.mesh.colors = array2;
		meshFilter.mesh.normals = array3;
		meshFilter.mesh.tangents = array4;
		meshFilter.mesh.triangles = array5;
		meshFilter.mesh.uv = array6;
		meshFilter.mesh.RecalculateBounds();
	}

	public static void UpdatePlane(MeshFilter meshFilter, float fUvScale, NcSpriteFactory.NcFrameInfo ncSpriteFrameInfo, bool bTrimCenterAlign, NcSpriteFactory.ALIGN_TYPE alignType, float fHShowRate)
	{
		Vector2 vector = new Vector2(fUvScale * ncSpriteFrameInfo.m_FrameScale.x, fUvScale * ncSpriteFrameInfo.m_FrameScale.y);
		float num = (alignType != NcSpriteFactory.ALIGN_TYPE.BOTTOM) ? ((alignType != NcSpriteFactory.ALIGN_TYPE.TOP) ? 0f : (-1f * vector.y)) : (1f * vector.y);
		float num2 = (alignType != NcSpriteFactory.ALIGN_TYPE.LEFTCENTER) ? ((alignType != NcSpriteFactory.ALIGN_TYPE.RIGHTCENTER) ? 0f : (-1f * vector.x)) : (1f * vector.x);
		Rect frameUvOffset = ncSpriteFrameInfo.m_FrameUvOffset;
		if (bTrimCenterAlign)
		{
			frameUvOffset.center = Vector2.zero;
		}
		Vector3[] array = new Vector3[4];
		if (alignType == NcSpriteFactory.ALIGN_TYPE.LEFTCENTER && 0f < fHShowRate)
		{
			array[0] = new Vector3(frameUvOffset.xMax * vector.x * fHShowRate + num2 * fHShowRate, frameUvOffset.yMax * vector.y + num);
			array[1] = new Vector3(frameUvOffset.xMax * vector.x * fHShowRate + num2 * fHShowRate, frameUvOffset.yMin * vector.y + num);
		}
		else
		{
			array[0] = new Vector3(frameUvOffset.xMax * vector.x + num2, frameUvOffset.yMax * vector.y + num);
			array[1] = new Vector3(frameUvOffset.xMax * vector.x + num2, frameUvOffset.yMin * vector.y + num);
		}
		array[2] = new Vector3(frameUvOffset.xMin * vector.x, frameUvOffset.yMin * vector.y + num);
		array[3] = new Vector3(frameUvOffset.xMin * vector.x, frameUvOffset.yMax * vector.y + num);
		meshFilter.mesh.vertices = array;
		meshFilter.mesh.RecalculateBounds();
	}

	public static void UpdateMeshUVs(MeshFilter meshFilter, Rect uv, NcSpriteFactory.ALIGN_TYPE alignType, float fHShowRate)
	{
		Vector2[] array = new Vector2[4];
		float num = 1f;
		if (alignType == NcSpriteFactory.ALIGN_TYPE.LEFTCENTER && 0f < fHShowRate)
		{
			num = fHShowRate;
		}
		array[0] = new Vector2(uv.x + uv.width * num, uv.y + uv.height);
		array[1] = new Vector2(uv.x + uv.width * num, uv.y);
		array[2] = new Vector2(uv.x, uv.y);
		array[3] = new Vector2(uv.x, uv.y + uv.height);
		meshFilter.mesh.uv = array;
	}
}
