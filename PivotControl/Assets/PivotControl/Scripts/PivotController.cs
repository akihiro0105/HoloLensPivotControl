using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PivotControl
{
    /// <summary>
    /// 選択Pivotとの親子関係を変更することでPivot中心の回転が行える
    /// </summary>
    public class PivotController : MonoBehaviour
    {
        /// <summary>
        /// 操作対象オブジェクト
        /// </summary>
        [SerializeField] private Transform target;
        [Space(14)]
        /// <summary>
        /// 操作対象オブジェクトを格納するオブジェクト
        /// </summary>
        [SerializeField] private Transform root;
        /// <summary>
        /// Pivotオブジェクト
        /// </summary>
        [SerializeField] private DragPivot[] pivots;

        // Use this for initialization
        void Start()
        {
            if (target != null) SetTargetObject(target);
            foreach (var p in pivots) p.OnClickPivot += t =>
            {
                foreach (var pivot in pivots) pivot.transform.parent = transform;
                t.parent = null;
                transform.parent = t;
            };
        }

        public void SetTargetObject(Transform t)
        {
            t.parent = root;
            t.localPosition = Vector3.zero; ;
            t.localRotation = Quaternion.identity;
        }
    }
}
