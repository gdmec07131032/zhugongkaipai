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
        InitGame();
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
    private GameObject mItem;
    /// <summary>所有商品数据 </summary>
    List<ShopItemData> mListData = new List<ShopItemData>();
    /// <summary>一行元素个数 </summary>
    private int mOneLineNum = 3;
    /// <summary>有多少行 </summary>
    private int mLine = 0;
    /// <summary>行于数 </summary>
    private int mRemainder = 0;
    void InitGame()
    {
        mItem = skinTransform.Find("PanelMove/Items/Item").gameObject;

        Transform menuTran = skinTransform.Find("Content/Menu");
        BoxCollider[] buttonArr = menuTran.GetComponentsInChildren<BoxCollider>(true);
        foreach (BoxCollider box in buttonArr)
        {
            mMenuButtonList.Add(box.gameObject);
        }
        mListData = MoNiData(Random.Range(10, 30));
        ShowItems();
    }

    void ShowItems()
    {
        mLine = mListData.Count / mOneLineNum;
        mRemainder = mListData.Count % mOneLineNum;
        if (mRemainder != 0)
        {
            mLine++;
        }
        Debug.Log(string.Format("行数：{0}，余数：{1}，总个数：{2}", mLine, mRemainder, mListData.Count));
        for (int i = 0; i < mLine; i++)
        {
            GameObject item = Instantiate(mItem) as GameObject;
            item.transform.parent = mItem.transform.parent;
            item.transform.localEulerAngles = Vector3.zero;
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = new Vector3(0, -180 * (i - 1), 0);
            item.SetActive(true);
            item.name = i.ToString();
            InitItem(item, i);
        }
    }
    /// <summary>
    /// item 初始化
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    void InitItem(GameObject item, int index)
    {
        SelfShopItem self = item.GetComponent<SelfShopItem>();
        List<ShopItemData> list = new List<ShopItemData>();
        int nowListIndex = index * mOneLineNum;
        Debug.Log("当前行的索引：" + nowListIndex);
        int forNum = mOneLineNum;
        if (index == (mLine - 1) && mRemainder != mOneLineNum)
        {
            forNum = mRemainder;
        }
        //将当前行的数据传入
        for (int i = 0; i < forNum; i++)
        {
            ShopItemData data = mListData[nowListIndex + i];
            list.Add(data);
        }
        self.Init(list);
    }
    List<ShopItemData> MoNiData(int nums)
    {
        List<ShopItemData> list = new List<ShopItemData>();
        for (int i = 0; i < nums; i++)
        {
            ShopItemData data = new ShopItemData();
            data.id = Random.Range(100, 199);
            if (data.id >= 100 && data.id < 120)
            {
                data.type = 0;
            }
            else if (data.id >= 120 && data.id < 140)
            {
                data.type = 1;
            }
            else if (data.id >= 140 && data.id < 160)
            {
                data.type = 2;
            }
            else if (data.id >= 160 && data.id < 180)
            {
                data.type = 3;
            }
            else if (data.id >= 180 && data.id < 200)
            {
                data.type = 4;
            }
            data.num = Random.Range(1, 99);
            data.name = "商品" + data.id.ToString();
            data.price = data.id + 666;
            list.Add(data);
        }
            return list;
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
