 using UnityEngine;
using System.Collections;
using System;

public class PanelMgr : MonoBehaviour {

    #region 初始化
    protected static PanelMgr mInstance;
    public static PanelMgr Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new PanelMgr();
            }
            return mInstance;
        }
    }
    #endregion
    //private GameObject curren;
    private Transform parentObj = null;
    public void ShowPanel(string name, params object[] sceneArgs)
    {
        GameObject scene = new GameObject(name);
        PanelBase baseObj = scene.AddComponent(Type.GetType(name)) as PanelBase;
        baseObj.Init(sceneArgs);
        if (parentObj == null)
        {
            parentObj = GameObject.Find("UI Root").transform;
        }
        scene.transform.parent = parentObj;
        scene.transform.parent.localEulerAngles = Vector3.zero;
        scene.transform.localScale = Vector3.one;
        scene.transform.localPosition = Vector3.zero;

    }
}
