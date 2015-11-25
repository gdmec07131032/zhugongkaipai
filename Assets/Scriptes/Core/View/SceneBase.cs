using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SceneBase : MonoBehaviour {
    /// <summary>
    /// 所有的boxcollider
    /// </summary>
    private List<Collider> colliderList=new List<Collider>();

    public void OnDestroy()
    {
        OnDestroyFront();
        colliderList.Clear();
        colliderList = null;
        OnDestroyEnd();
    }

    protected void Init()
    {
        OnInit();
        Collider[] colliders = this.GetComponentsInChildren<Collider>(true);
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            UIEventListener listener = UIEventListener.Get(collider.gameObject);
            listener.onClick = OnClick;
            colliderList.Add(collider);
        }
    }
    #region 虚方法
    /// <summary>
    /// 初始化
    /// </summary>
    protected virtual void OnInit() { }
    /// <summary>
    /// 开始删除
    /// </summary>
    protected virtual void OnDestroyFront() { }
    /// <summary>
    /// 删除完成
    /// </summary>
    protected virtual void OnDestroyEnd() { }

    /// <summary>
    /// 点击按钮
    /// </summary>
    /// <param name="go">被电击的对象</param>
    protected virtual void OnClick(GameObject go) { }
    #endregion
}
