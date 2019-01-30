using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloLensModule.Input;

namespace PivotControl
{
    /// <summary>
    /// 選択Pivotを通知し，Y軸回転をドラッグで行う
    /// </summary>
    public class DragPivot : MonoBehaviour,IDragGestureInterface
    {
        /// <summary>
        /// Pivot選択イベント
        /// </summary>
        public event Action<Transform> OnClickPivot;

        private Vector3 current;

        public void OnStartDrag(Vector3 pos, Quaternion? rot = null)
        {
            current = pos;
        }

        public void OnUpdateDrag(Vector3 pos, Quaternion? rot = null)
        {
            if (OnClickPivot != null) OnClickPivot.Invoke(transform);
            transform.Rotate(0, (pos.x - current.x) * 100.0f, 0);
            current = pos;
        }
    }
}
