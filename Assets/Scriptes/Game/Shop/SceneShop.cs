using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneShop : SceneBase {

    #region 初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Shop/SceneShop");
        base.OnInitSkin();
    }
    protected override void OnInitDone()
    {
        base.OnInitDone();
        Init();
    }
    protected override void OnClick(GameObject go)
    {
        base.OnClick(go);
        ClickButton(go);
    }
    public override void OnResetArgs(params object[] sceneArgs)
    {
        base.OnResetArgs(sceneArgs);
    }
    #endregion

    #region 初始化
    List<GameObject> mMenuButtonList = new List<GameObject>();
    void Init()
    {
        Transform menuTran = skinTransform.Find("Content/Menu");
        BoxCollider[] buttonArr = menuTran.GetComponentsInChildren<BoxCollider>(true);
        foreach (BoxCollider box in buttonArr)
        {
            mMenuButtonList.Add(box.gameObject);
        }
    }
    #endregion

    #region 点击事件
    void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnReturn"))
        {
            SceneMgr.Instance.SwitchToPrevScene();
        }
        else if (click.name.Equals("BtnProp"))
        {
            ChangeMenuButtonStyle(click);
        }
        else if (click.name.Equals("BtnMaterial"))
        {
            ChangeMenuButtonStyle(click);
        }
        else if (click.name.Equals("BtnGift"))
        {
            ChangeMenuButtonStyle(click);
        }
    }
    void ChangeMenuButtonStyle(GameObject clickButton)
    {
        foreach (GameObject obj in mMenuButtonList)
        {
            UISprite sprite = obj.GetComponent<UISprite>();
            UILabel label = obj.transform.Find("Label").GetComponent<UILabel>();
            if (obj.Equals(clickButton))
            {
                sprite.color = Color.white;
                label.color = new Color(1.0f, 1.0f, 0.0f);
            }
            else
            {
                sprite.color = new Color(205.0f / 255.0f, 205.0f / 255.0f, 205.0f / 255.0f);
                label.color = new Color(205.0f / 255.0f, 205.0f / 255.0f, 205.0f / 255.0f);
            }
        }
    }
    #endregion
}
