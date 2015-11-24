using UnityEngine;
using System.Collections;

public class ResourcesMgr : MonoBehaviour
{
    #region 初始化
    private static ResourcesMgr mInstance;
    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static ResourcesMgr GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = new GameObject("ResourcesMgr").AddComponent<ResourcesMgr>();
        }
        return mInstance;
    }
    private ResourcesMgr()
    {
        hashtable = new Hashtable();
    }
    #endregion

    /// <summary>
    /// 资源缓存集合
    /// </summary>
    private Hashtable hashtable;

    /// <summary>
    /// 从res中加载资源
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源路径</param>
    /// <param name="cache">是否缓存</param>
    /// <returns></returns>
    public T Load<T>(string path, bool cache)
        where T:UnityEngine.Object
    {
        if (hashtable.Contains(path))
        {
            return hashtable[path] as T;
        }
        T assetObj = Resources.Load<T>(path);
        if (assetObj == null)
        {
            Debug.LogError("资源不存在 path=" + path);
        }
        if (cache)
        {
            hashtable.Add(path, assetObj);
            Debug.Log("对象缓存 path=" + path);
        }

        return assetObj;
    }
    /// <summary>
    /// 从res中创建一个GameObject对象
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="cache">是否缓存</param>
    /// <returns></returns>

    public GameObject CreateGameObject(string path, bool cache)
    {
        GameObject assetObj = Load<GameObject>(path, cache);
        GameObject go = Instantiate(assetObj) as GameObject;
        if (go == null)
        {
            Debug.Log("从Res中创建游戏对象失败，path=" + path);
        }
        return go;
    }
}
