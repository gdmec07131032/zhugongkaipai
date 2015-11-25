using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SceneMail : SceneBase
{

    private GameObject mItem;

    private List<GameObject> mItemList;

    void Start()
    {    
        mItem = transform.Find("PanelMove/Items/Item").gameObject;
        ShowItems();
    }

    /// <summary>
    /// 显示item列表
    /// </summary>
    void ShowItems()
    {
        if (mItem == null)
        {
            Debug.LogError("Item null");
        }
        else
        {
            mItemList = new List<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                GameObject item = Instantiate(mItem) as GameObject;
                item.transform.parent = mItem.transform.parent;
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                item.transform.localEulerAngles = Vector3.zero;
                InitItem(item, i);
                item.name = i.ToString();
            }
        }
    }
    /// <summary>
    /// 初始化item
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    void InitItem(GameObject item, int index)
    {
        //设定坐标
        item.transform.localPosition = new Vector3(0, 135 - index * 90, 0);

        GameObject btnDelete = item.transform.Find("BtnDelete").gameObject;

        UIEventListener listener = UIEventListener.Get(btnDelete);
        listener.onClick = ClickButton;

        UILabel title = item.transform.Find("Title").GetComponent<UILabel>();
        UILabel time = item.transform.Find("SendTime").GetComponent<UILabel>();
        title.text = "李奶奶的来信" + index.ToString();
        time.text = DateTime.Now.ToString();
        mItemList.Add(item);

    }

    /// <summary>
    /// 点击事件
    /// </summary>
    /// <param name="click"></param>
    void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnDelete"))
        {
            Debug.Log("点击了" + click.transform.parent.name);
            mItemList.Remove(click.transform.parent.gameObject);
            Destroy(click.transform.parent.gameObject);
            ChangePosition();
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void ChangePosition()
    {
        for (int i = 0; i < mItemList.Count; i++)
        {
            //GameObject item = mItemList[i];
            mItemList[i].transform.localPosition = new Vector3(0, 135 - i * 90, 0);
        }
    }

}
