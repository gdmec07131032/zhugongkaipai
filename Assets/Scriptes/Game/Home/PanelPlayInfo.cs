using UnityEngine;
using System.Collections;

public class PanelPlayInfo : PanelBase {

    #region 初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Home/PanelPlayInfo");
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

    public void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnClose"))
        {
            Close();
        }
       
    }
}
