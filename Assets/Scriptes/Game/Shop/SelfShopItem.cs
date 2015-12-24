using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelfShopItem : MonoBehaviour
{
    public List<GameObject> selfList = new List<GameObject>();

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init(List<ShopItemData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject item = selfList[i];
            ShopItemData data = list[i];
            UILabel name = item.transform.Find("name").GetComponent<UILabel>();
            UISprite pinzhi = item.transform.Find("pinzhi").GetComponent<UISprite>();
            UISprite icon = item.transform.Find("pinzhi/icon").GetComponent<UISprite>();
            UILabel num = item.transform.Find("pinzhi/num").GetComponent<UILabel>();
            UISprite activityIcon = item.transform.Find("activityIcon").GetComponent<UISprite>();
            UILabel price = item.transform.Find("price").GetComponent<UILabel>();
            name.text = data.name;
            num.text = data.num.ToString();
            price.text = data.price.ToString();
            item.name = "Shop_" + data.id.ToString();
        }
        if (list.Count < selfList.Count)
        {
            int num = selfList.Count - list.Count;
            for (int i = selfList.Count - 1; i > selfList.Count - num; i--)
            {
                GameObject item = selfList[i];
                item.SetActive(false);
            }
        }
    }

}

public class ShopItemData
{
    /// <summary>名字</summary>
    public string name;
    /// <summary>数量</summary>
    public int num;
    /// <summary>ID</summary>
    public int id;
    /// <summary>类型</summary>
    public int type;
    /// <summary>单价</summary>
    public int price;

}
