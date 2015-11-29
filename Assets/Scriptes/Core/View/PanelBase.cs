using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelBase : MonoBehaviour {

    #region 皮肤
    private GameObject _skin;
    /// <summary>
    /// 皮肤
    /// </summary>
    public GameObject skin
    {
        get
        {
            return _skin;
        }
    }
    /// <summary>
    /// 皮肤transform
    /// </summary>
    protected Transform skinTransform
    {
        get
        {
            return _skin.transform;
        }
    }
    /// <summary>
    /// 住皮肤路径
    /// </summary>
    private string mainSkinPath;
    /// <summary>
    /// 设置主皮肤
    /// </summary>
    /// <param name="path"></param>
    protected void SetMainSkinPath(string path)
    {
        mainSkinPath = path;
    }
    /// <summary>
    /// 所有的boxcollider
    /// </summary>
    private List<Collider> colliderList = new List<Collider>();

    protected object[] _sceneArgs;
    /// <summary>
    /// 场景init参数
    /// </summary>
    public object[] sceneArgs
    {
        get
        {
            return _sceneArgs;
        }
    }
    #endregion
    #region 初始化相关
    void Start()
    {
        OnStart();
    }
    void Update()
    {

    }
    public void OnDestroy()
    {
        OnDestroyFront();
        colliderList.Clear();
        colliderList = null;
        OnDestroyEnd();
    }

    public void Init(params object[] sceneArgs)
    {
        _sceneArgs = sceneArgs;
        OnInit();
        OnInitSkin();
        OnInitSkinDone();
        Collider[] colliders = this.GetComponentsInChildren<Collider>(true);
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
            UIEventListener listener = UIEventListener.Get(collider.gameObject);
            listener.onClick = OnClick;
            colliderList.Add(collider);
        }
        OnInitDone();
    }
    #endregion
    #region 虚方法

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
    /// <summary>
    /// 初始化
    /// </summary>
    protected virtual void OnInit() { }
    protected virtual void OnInitDone() { }
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
    /// <summary>
    /// 初始化皮肤
    /// </summary>
    protected virtual void OnInitSkin()
    {
        if (!string.IsNullOrEmpty(mainSkinPath))
        {
            _skin = ResourceMgr.GetInstance().CreateGameObject(mainSkinPath, false);
        }
        _skin.transform.parent = this.gameObject.transform;
        _skin.transform.localEulerAngles = Vector3.zero;
        _skin.transform.localPosition = Vector3.zero;
        _skin.transform.localScale = Vector3.one;
    }
    /// <summary>
    /// 初始化皮肤完成
    /// </summary>
    protected virtual void OnInitSkinDone() { }
    #endregion

    #region
    /// <summary>
    /// 关闭当前界面
    /// </summary>
    protected void Close()
    {
        Destroy(this.gameObject);
    }
    #endregion
}
