using UnityEngine;
using System.Collections;

public class PanelShop : PanelBase {

    #region 初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/Shop/PanelShop");
        base.OnInitSkin();
        _type = PanelType.PanelShop;
        _showStyle = PanelMgr.PanelShowStyle.CenterScaleBigNormal;
        _openDuration = 0.4f;
    }
    protected override void OnInitDone()
    {
        base.OnInitDone();
        int id = (int)sceneArgs[0];
        InitGame();
    }
    protected override void OnClick(GameObject go)
    {
        base.OnClick(go);
        ClickButton(go);
    }
    #endregion

    #region 数据定义
    private UILabel mName;
    private UIInput mInputNum;
    private int mNowSelectNums = 1;
    #endregion

    #region 初始化
    void InitGame()
    {
        mName = skinTransform.Find("name").GetComponent<UILabel>();
        mInputNum = skinTransform.Find("inputNum").GetComponent<UIInput>();
        mInputNum.value = mNowSelectNums.ToString();
        mInputNum.onChange.Add(new EventDelegate(ChangeInput));
    }

    void ChangeInput()
    {
        //int nums = 1;
       int.TryParse(mInputNum.value, out mNowSelectNums);
        //mNowSelectNums = int.Parse(mInputNum.value);
    }
    #endregion

    #region 点击事件
    public void ClickButton(GameObject click)
    {
        if (click.name.Equals("btnClose") || click.name.Equals("backdrop"))
        {
            Close();
        }
        else if (click.name.Equals("btnAdd"))
        {
            if (mNowSelectNums < 99)
            {
                mNowSelectNums++;
            }
            mInputNum.value = mNowSelectNums.ToString();
        }
        else if (click.name.Equals("btnSub"))
        {
            if (mNowSelectNums > 1)
            {
                mNowSelectNums--;
            }
            mInputNum.value = mNowSelectNums.ToString();
        }
        else if (click.name.Equals("btnBuy"))
        {
            Debug.Log("发送购买信息");
        }

    }
    #endregion

}
