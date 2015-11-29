using UnityEngine;
using System.Collections;

public class SceneHome : SceneBase
{

    #region 初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Home/SceneHome");
        base.OnInitSkin();
    }
    protected override void OnInitDone()
    {
        base.OnInitDone();
        
    }
    protected override void OnClick(GameObject go)
    {
        base.OnClick(go);
        ClickButton(go);
    }
    #endregion 

    #region 点击事件
    void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnMail"))
        {
            SceneMgr.Instance.SwitchScene("SceneMail");
        }
        else if (click.name.Equals("border"))
        {
            PanelMgr.Instance.ShowPanel("PanelPlayInfo");
        }
    }
    #endregion
}
