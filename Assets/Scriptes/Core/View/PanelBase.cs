using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PanelBase : UIBase
{
    protected PanelType _type;
    public PanelType type
    {
        get
        {
            return _type;
        }
    }
    /// <summary>
    /// 面板打开时间
    /// </summary>
    protected float _openDuration = 0.2f;
    /// <summary>
    /// 面板打开时间
    /// </summary>
    public float openDuration
    {
        get
        {
            return _openDuration; 
        }
    }
    /// <summary> 面板显示方式 </summary>
    protected PanelMgr.PanelShowStyle _showStyle = PanelMgr.PanelShowStyle.CenterScaleBigNormal;
    /// <summary>
    /// 面板显示方式
    /// </summary>
    public PanelMgr.PanelShowStyle PanelShowStyle
    {
        get
        {
            return _showStyle;
        }
    }

    #region
    /// <summary>
    /// 发起关闭，播放效果
    /// </summary>
    protected void Close()
    {
        //Destroy(this.gameObject);
        PanelMgr.Instance.HidePanel(type);
    }
    /// <summary>
    /// 立刻关闭
    /// </summary>
    protected void CloseImmediate()
    {
        PanelMgr.Instance.DestroyPanel(type);
    }
    #endregion
}

public enum PanelType
{
    /// <summary>玩家信息面板 </summary>
    PanelPlayInfo
}
