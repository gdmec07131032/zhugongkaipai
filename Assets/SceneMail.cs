using UnityEngine;
using System.Collections;

public class SceneMail : MonoBehaviour {

    public GameObject mItem;

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
            for (int i = 0; i < 50; i++)
            {
                GameObject item = Instantiate(mItem) as GameObject;
                item.transform.parent = mItem.transform.parent;
                item.SetActive(true);
                item.transform.localScale = Vector3.one;
                item.transform.localEulerAngles = Vector3.zero;
                //设定坐标
                item.transform.localPosition = new Vector3(0, 80 - i * 90, 0);
            }
        }
    }
}
