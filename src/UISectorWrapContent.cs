using System;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(UICenterOnChild))]
public class UISectorWrapContent : UIWrapContent
{
	public delegate void OnWrapItem(int wrapIndex, bool toLeft);

	public delegate void SwitchToCenterPanel(Transform centerPanel);

	public int m_count = 9;

	public int m_angle = 12;

	public int m_startDepth = 100;

	public int m_wrapsize;

	public UISectorWrapContent.OnWrapItem onWrapItem;

	public UISectorWrapContent.SwitchToCenterPanel switchToCenterPanel;

	private int halfDepth;

	private int panelDepth;

	private bool mInit;

	private bool isMove;

	private Transform panelTrans;

	private UICenterOnChild centerChild;

	private UIScrollCenterView centerView;

	protected override void Start()
	{
		this.centerChild = base.GetComponent<UICenterOnChild>();
	}

	[ContextMenu("Execute")]
	protected override void OnEnable()
	{
		this.mFirstTime = false;
		this.SortBasedOnScrollMovement();
		this.WrapContent();
		this.mPanel.onClipMove = new UIPanel.OnClippingMoved(this.OnMove);
	}

	private void OnDisable()
	{
		this.mPanel.onClipMove = null;
	}

	private void Init()
	{
		this.mTrans = base.transform;
		this.mPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		this.centerView = this.mPanel.GetComponent<UIScrollCenterView>();
		if (this.centerView.movement == UIScrollView.Movement.Horizontal)
		{
			this.mHorizontal = true;
		}
		else if (this.centerView.movement == UIScrollView.Movement.Vertical)
		{
			this.mHorizontal = false;
		}
		this.halfDepth = (this.m_startDepth >> 1) + 10;
		if (this.m_wrapsize == 0)
		{
			this.m_wrapsize = (this.itemSize >> 1) + 1;
		}
		this.panelDepth = (((this.m_count <= 0) ? this.mChildren.Count : this.m_count) >> 1) + 1;
		this.panelTrans = this.mPanel.transform;
		this.mInit = true;
	}

	protected override void OnMove(UIPanel panel)
	{
		this.isMove = true;
		this.WrapContent();
		this.isMove = false;
	}

	public override void SortBasedOnScrollMovement()
	{
		if (!base.enabled)
		{
			return;
		}
		if (!this.mInit)
		{
			this.Init();
		}
		this.mChildren.Clear();
		for (int i = 0; i < this.mTrans.childCount; i++)
		{
			Transform child = this.mTrans.GetChild(i);
			if (!this.hideInactive || child.gameObject.activeInHierarchy)
			{
				this.mChildren.Add(child);
			}
		}
		this.ResetChildPositions();
	}

	public override void SortAlphabetically()
	{
	}

	protected override void ResetChildPositions()
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.m_count > 0 && this.mChildren.Count > this.m_count)
		{
			for (int i = 0; i < this.m_count - this.mChildren.Count; i++)
			{
				this.mChildren.RemoveAt(0);
			}
		}
		float num = (float)(this.mChildren.Count - 1) / 2f;
		float num2 = (float)this.itemSize * num;
		int j = 0;
		int count = this.mChildren.Count;
		while (j < count)
		{
			Transform transform = this.mChildren[j];
			Vector3 localPosition = (!this.mHorizontal) ? new Vector3(0f, (float)this.itemSize * (num - (float)j), 0f) : new Vector3(-((float)this.itemSize * (num - (float)j)), (float)(this.halfDepth * j), (float)(j * this.itemSize + this.m_startDepth));
			transform.localPosition = localPosition;
			UIPanel component = transform.GetComponent<UIPanel>();
			if (component)
			{
				component.depth = ((localPosition.x >= 0f) ? ((int)(num2 - localPosition.x) / this.itemSize) : ((int)(num2 + localPosition.x) / this.itemSize)) + 1;
			}
			j++;
		}
		this.centerView.mCenterWidth = this.itemSize;
		this.centerView.mCenterOffset = (num - (float)((int)num)) * (float)this.itemSize;
		if (this.mHorizontal)
		{
			this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
		}
		else
		{
			this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortVertical));
		}
	}

	public override void WrapContent()
	{
		if (!base.enabled)
		{
			return;
		}
		float num = (float)(this.itemSize * this.mChildren.Count) * 0.5f;
		Vector3[] worldCorners = this.mPanel.worldCorners;
		for (int i = 0; i < 4; i++)
		{
			Vector3 vector = worldCorners[i];
			vector = this.mTrans.InverseTransformPoint(vector);
			worldCorners[i] = vector;
		}
		Vector3 vector2 = Vector3.Lerp(worldCorners[0], worldCorners[2], 0.5f);
		bool flag = true;
		float num2 = num * 2f;
		if (this.mHorizontal)
		{
			float num3 = worldCorners[0].x - (float)this.itemSize;
			float num4 = worldCorners[2].x + (float)this.itemSize;
			int j = 0;
			int count = this.mChildren.Count;
			while (j < count)
			{
				Transform transform = this.mChildren[j];
				float num5 = transform.localPosition.x - vector2.x;
				if (num5 < -num)
				{
					Vector3 localPosition = transform.localPosition;
					localPosition.x += num2;
					num5 = localPosition.x - vector2.x;
					int num6 = Mathf.RoundToInt(localPosition.x / (float)this.itemSize);
					if (this.minIndex == this.maxIndex || (this.minIndex <= num6 && num6 <= this.maxIndex))
					{
						transform.localPosition = localPosition;
						if (this.isMove)
						{
							this.UpdateItem(transform, j);
						}
					}
					else
					{
						flag = false;
					}
				}
				else if (num5 > num)
				{
					Vector3 localPosition2 = transform.localPosition;
					localPosition2.x -= num2;
					num5 = localPosition2.x - vector2.x;
					int num7 = Mathf.RoundToInt(localPosition2.x / (float)this.itemSize);
					if (this.minIndex == this.maxIndex || (this.minIndex <= num7 && num7 <= this.maxIndex))
					{
						transform.localPosition = localPosition2;
						if (this.isMove)
						{
							this.UpdateItem(transform, j);
						}
					}
					else
					{
						flag = false;
					}
				}
				else if (this.mFirstTime)
				{
					this.UpdateItem(transform, j);
				}
				if (this.cullContent)
				{
					num5 += this.mPanel.clipOffset.x - this.mTrans.localPosition.x;
					if (!UICamera.IsPressed(transform.gameObject))
					{
						NGUITools.SetActive(transform.gameObject, num5 > num3 && num5 < num4, false);
					}
				}
				this.Reposition(transform);
				j++;
			}
		}
		else
		{
			float num8 = worldCorners[0].y - (float)this.itemSize;
			float num9 = worldCorners[2].y + (float)this.itemSize;
			int k = 0;
			int count2 = this.mChildren.Count;
			while (k < count2)
			{
				Transform transform2 = this.mChildren[k];
				float num10 = transform2.localPosition.y - vector2.y;
				if (num10 < -num)
				{
					Vector3 localPosition3 = transform2.localPosition;
					localPosition3.y += num2;
					num10 = localPosition3.y - vector2.y;
					int num11 = Mathf.RoundToInt(localPosition3.y / (float)this.itemSize);
					if (this.minIndex == this.maxIndex || (this.minIndex <= num11 && num11 <= this.maxIndex))
					{
						transform2.localPosition = localPosition3;
						if (this.isMove)
						{
							this.UpdateItem(transform2, k);
						}
					}
					else
					{
						flag = false;
					}
				}
				else if (num10 > num)
				{
					Vector3 localPosition4 = transform2.localPosition;
					localPosition4.y -= num2;
					num10 = localPosition4.y - vector2.y;
					int num12 = Mathf.RoundToInt(localPosition4.y / (float)this.itemSize);
					if (this.minIndex == this.maxIndex || (this.minIndex <= num12 && num12 <= this.maxIndex))
					{
						transform2.localPosition = localPosition4;
						if (this.isMove)
						{
							this.UpdateItem(transform2, k);
						}
					}
					else
					{
						flag = false;
					}
				}
				else if (this.mFirstTime)
				{
					this.UpdateItem(transform2, k);
				}
				if (this.cullContent)
				{
					num10 += this.mPanel.clipOffset.y - this.mTrans.localPosition.y;
					if (!UICamera.IsPressed(transform2.gameObject))
					{
						NGUITools.SetActive(transform2.gameObject, num10 > num8 && num10 < num9, false);
					}
				}
				this.Reposition(transform2);
				k++;
			}
		}
		this.centerView.restrictWithinPanel = !flag;
		this.centerView.InvalidateBounds();
	}

	public void OnCenterPositon(float pos)
	{
		SpringPanel.Begin(this.panelTrans.gameObject, this.panelTrans.localPosition - new Vector3(pos, 0f, 0f), this.centerChild.springStrength).onFinished = new SpringPanel.OnFinished(this.centerChild.Recenter);
	}

	public void CheckChilds()
	{
		int num = 0;
		int i = 0;
		int childCount = base.transform.childCount;
		while (i < childCount)
		{
			if (base.transform.GetChild(i).gameObject.activeSelf)
			{
				num++;
			}
			i++;
		}
		if (num != this.mChildren.Count)
		{
			this.SortBasedOnScrollMovement();
			this.WrapContent();
		}
	}

	public void ResetPanel(float value)
	{
		if (null == this.centerView)
		{
			return;
		}
		this.centerView.DisableSpring(true);
		this.mPanel.onClipMove = null;
		Vector3 vector = this.mPanel.transform.localPosition;
		vector.x = value;
		this.mPanel.transform.localPosition = vector;
		vector = this.mPanel.clipOffset;
		vector.x = -value;
		this.mPanel.clipOffset = vector;
		this.ResetChildPositions();
		int i = 0;
		int childCount = base.transform.childCount;
		while (i < childCount)
		{
			Transform child = base.transform.GetChild(i);
			if (child.gameObject.activeSelf)
			{
				this.Reposition(child);
			}
			i++;
		}
		this.mPanel.onClipMove = new UIPanel.OnClippingMoved(this.OnMove);
	}

	protected override void UpdateItem(Transform item, int index)
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.onWrapItem != null)
		{
			this.onWrapItem(index, item.localPosition.x + this.panelTrans.localPosition.x < 0f);
		}
		if (this.onInitializeItem != null)
		{
			int realIndex = Mathf.RoundToInt(item.localPosition.x / (float)this.itemSize);
			this.onInitializeItem(item.gameObject, index, realIndex);
		}
		if (this.onEventChange != null)
		{
			this.onEventChange();
		}
		if (this.onEventAction != null)
		{
			this.onEventAction(item);
		}
	}

	private void Reposition(Transform trans)
	{
		if (!base.enabled)
		{
			return;
		}
		Vector3 localPosition = trans.localPosition;
		float num = localPosition.x + this.panelTrans.localPosition.x;
		float num2 = (num >= 0f) ? (num / (float)this.itemSize) : (-num / (float)this.itemSize);
		float num3 = (float)this.halfDepth * num2;
		localPosition.y = ((num3 <= (float)this.halfDepth) ? num3 : ((float)this.halfDepth));
		localPosition.z = num2 * (float)this.itemSize + (float)this.m_startDepth;
		trans.localPosition = localPosition;
		trans.eulerAngles = new Vector3(0f, 0f, (float)this.m_angle * ((num >= 0f) ? (-num2) : num2));
		UIPanel component = trans.GetComponent<UIPanel>();
		int num4 = this.panelDepth - (int)(Mathf.Abs(num2) + 0.5f);
		if (component && component.depth != num4)
		{
			component.depth = num4;
			if (num4 == this.panelDepth && this.switchToCenterPanel != null)
			{
				this.switchToCenterPanel(trans);
			}
		}
	}

	private Transform OnCenter()
	{
		float x = this.panelTrans.localPosition.x;
		int i = 0;
		int count = this.mChildren.Count;
		while (i < count)
		{
			Transform transform = this.mChildren[i];
			if (Mathf.Abs(transform.localPosition.x + x) < (float)this.m_wrapsize)
			{
				return transform;
			}
			i++;
		}
		return null;
	}
}
