 using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PanelMgr {

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
    private PanelMgr()
    {
        panels = new Dictionary<PanelType, PanelBase>();
    }
    void Destroy()
    {
        panels.Clear();
        panels = null;
    }
    #endregion
    #region 数据定义
    
    public Dictionary<PanelType, PanelBase> panels;
    public enum PanelShowStyle
    {
        /// <summary>正常出现 </summary>
        Normal,
        /// <summary>中间由小变大 </summary>
        CenterScaleBigNormal,
        /// <summary>由上往下 </summary>
        TopToSlide,
        /// <summary>由下往上 </summary>
        DownToSlide,
        /// <summary>左往右 </summary>
        LeftToSlide,
        /// <summary>右往左 </summary>
        RightToSlide
    }
    public enum PanelMaskStyle
    {
        /// <summary>无背景 </summary>
        none,
        /// <summary>半透明背景 </summary>
        BlackAlpha,
        /// <summary>无透明，但有Box关闭组件 </summary>
        Alpha
    }
    #endregion
    //private GameObject curren;
    private Transform parentObj = null;
    /// <summary>当前打开的面板 </summary>
    private PanelBase current = null;
    public void ShowPanel(PanelType panelType, params object[] panelArgs)
    {
        if (panels.ContainsKey(panelType))
        {
            current = panels[panelType];
            current.gameObject.SetActive(false);
            current.OnInit(panelArgs);
        }
        else
        {
            GameObject scene = new GameObject(panelType.ToString());
            current = scene.AddComponent(Type.GetType(panelType.ToString())) as PanelBase;
            current.gameObject.SetActive(false);
            current.OnInit(panelArgs);
            panels.Add(panelType, current);
            if (parentObj == null)
            {
                parentObj = GameObject.Find("UI Root").transform;
            }
            scene.transform.parent = parentObj;
            scene.transform.localEulerAngles = Vector3.zero;
            scene.transform.localScale = Vector3.one;
            scene.transform.localPosition = Vector3.zero;
            LayerMgr.GetInstance().SetLayer(current.gameObject, LayerType.Panel);
        }
        StartShowPanel(current, current.PanelShowStyle, true);
    }

    /// <summary>
    /// 发起关闭
    /// </summary>
    /// <param name="panelType"></param>
    public void HidePanel(PanelType panelType)
    {
        if (panels.ContainsKey(panelType))
        {
            PanelBase pb = panels[panelType];
            StartShowPanel(pb, pb.PanelShowStyle, false);
        }
        else
        {
            Debug.Log("你要关闭的面板并不存在");
        }
    }
    /// <summary>
    /// 强制KO面板
    /// </summary>
    /// <param name="panelType"></param>
    public void DestroyPanel(PanelType panelType)
    {

        if (panels.ContainsKey(panelType))
        {
            PanelBase pb = panels[panelType];
            GameObject.Destroy(pb.gameObject);
            panels.Remove(panelType);
        }
    }
    private void StartShowPanel(PanelBase go, PanelMgr.PanelShowStyle showStyle, bool isOpen)
    {
        switch (showStyle)
        {
            case PanelShowStyle.Normal:
                ShowNormal(go, isOpen);
                break;
            case PanelShowStyle.CenterScaleBigNormal:
                ShowCenterScaleBigNormal(go, isOpen);
                break;
            case PanelShowStyle.LeftToSlide:
                ShowLeftScale(go, isOpen,true);
                break;
            case PanelShowStyle.RightToSlide:
                ShowLeftScale(go, isOpen, false);
                break;
            case PanelShowStyle.TopToSlide:
                ShowTopScale(go, isOpen, true);
                break;
            case PanelShowStyle.DownToSlide:
                ShowTopScale(go, isOpen, false);
                break;
        }
    }

    
    #region 各种打开效果
    void ShowNormal(PanelBase go,bool isOpen)
    {
        if (!isOpen)
        {
            DestroyPanel(go.type);
        }
        else
        {
            go.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 中间变大
    /// </summary>
    void ShowCenterScaleBigNormal(PanelBase go, bool isOpen)
    {
        TweenScale ts = go.gameObject.GetComponent<TweenScale>();
        if (ts == null)
        {
            ts = go.gameObject.AddComponent<TweenScale>();
        }
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.duration = go.openDuration;
        ts.SetOnFinished(() =>
        {
            if (!isOpen) DestroyPanel(go.type);
        });
        go.gameObject.SetActive(true);
        if (!isOpen) ts.Play(isOpen);
    }
    /// <summary>
    /// 左右往中
    /// </summary>
    /// <param name="go"></param>
    /// <param name="isOpen"></param>
    /// <param name="isLeft"></param>
    private void ShowLeftScale(PanelBase go, bool isOpen,bool isLeft)
    {
        TweenPosition tp = go.gameObject.GetComponent<TweenPosition>();
        if (tp == null) tp = go.gameObject.AddComponent<TweenPosition>();
        tp.from = isLeft ? new Vector3(-700, 0, 0) : new Vector3(700, 0, 0);
        tp.to = Vector3.zero;
        tp.duration = go.openDuration;
        tp.SetOnFinished(() =>
        {
            if (!isOpen) DestroyPanel(go.type);
        });
        go.gameObject.SetActive(true);
        if (!isOpen) tp.Play(isOpen);
    }
    /// <summary>
    /// 上下往中
    /// </summary>
    /// <param name="go"></param>
    /// <param name="isOpen"></param>
    /// <param name="isTop"></param>
    private void ShowTopScale(PanelBase go, bool isOpen, bool isTop)
    {
        TweenPosition tp = go.gameObject.GetComponent<TweenPosition>();
        if (tp == null) tp = go.gameObject.AddComponent<TweenPosition>();
        tp.from = isTop ? new Vector3(0, 600, 0) : new Vector3(0, -600, 0);
        tp.to = Vector3.zero;
        tp.duration = go.openDuration;
        tp.SetOnFinished(() =>
        {
            if (!isOpen) DestroyPanel(go.type);
        });
        go.gameObject.SetActive(true);
        if (!isOpen) tp.Play(isOpen);
    }
    #endregion
}
