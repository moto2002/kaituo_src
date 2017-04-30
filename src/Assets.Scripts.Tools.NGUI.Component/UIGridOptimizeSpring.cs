using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools.NGUI.Component
{
	public class UIGridOptimizeSpring : UIGrid
	{
		protected override void ResetPosition(List<Transform> list)
		{
			this.mReposition = false;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			Transform transform = base.transform;
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				Transform transform2 = list[i];
				Vector3 vector = transform2.localPosition;
				float z = vector.z;
				if (this.arrangement == UIGrid.Arrangement.CellSnap)
				{
					if (this.cellWidth > 0f)
					{
						vector.x = Mathf.Round(vector.x / this.cellWidth) * this.cellWidth;
					}
					if (this.cellHeight > 0f)
					{
						vector.y = Mathf.Round(vector.y / this.cellHeight) * this.cellHeight;
					}
				}
				else
				{
					vector = ((this.arrangement != UIGrid.Arrangement.Horizontal) ? new Vector3(this.cellWidth * (float)num2, -this.cellHeight * (float)num, z) : new Vector3(this.cellWidth * (float)num, -this.cellHeight * (float)num2, z));
				}
				if (this.animateSmoothly && Application.isPlaying && Vector3.SqrMagnitude(transform2.localPosition - vector) >= 0.0001f)
				{
					SpringPositionNoScrollBar springPositionNoScrollBar = SpringPositionNoScrollBar.Begin(transform2.gameObject, vector, 15f);
					springPositionNoScrollBar.updateScrollView = true;
					springPositionNoScrollBar.ignoreTimeScale = true;
				}
				else
				{
					transform2.localPosition = vector;
				}
				num3 = Mathf.Max(num3, num);
				num4 = Mathf.Max(num4, num2);
				if (++num >= this.maxPerLine && this.maxPerLine > 0)
				{
					num = 0;
					num2++;
				}
				i++;
			}
			if (this.pivot != UIWidget.Pivot.TopLeft)
			{
				Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
				float num5;
				float num6;
				if (this.arrangement == UIGrid.Arrangement.Horizontal)
				{
					num5 = Mathf.Lerp(0f, (float)num3 * this.cellWidth, pivotOffset.x);
					num6 = Mathf.Lerp((float)(-(float)num4) * this.cellHeight, 0f, pivotOffset.y);
				}
				else
				{
					num5 = Mathf.Lerp(0f, (float)num4 * this.cellWidth, pivotOffset.x);
					num6 = Mathf.Lerp((float)(-(float)num3) * this.cellHeight, 0f, pivotOffset.y);
				}
				for (int j = 0; j < transform.childCount; j++)
				{
					Transform child = transform.GetChild(j);
					SpringPositionNoScrollBar component = child.GetComponent<SpringPositionNoScrollBar>();
					if (component != null)
					{
						SpringPositionNoScrollBar expr_26C_cp_0 = component;
						expr_26C_cp_0.target.x = expr_26C_cp_0.target.x - num5;
						SpringPositionNoScrollBar expr_281_cp_0 = component;
						expr_281_cp_0.target.y = expr_281_cp_0.target.y - num6;
					}
					else
					{
						Vector3 localPosition = child.localPosition;
						localPosition.x -= num5;
						localPosition.y -= num6;
						child.localPosition = localPosition;
					}
				}
			}
		}
	}
}
