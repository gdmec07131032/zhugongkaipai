using UnityEngine;
using System.Collections;
using System;

public class SceneMgr
{

    #region
    protected static SceneMgr mInstance;
    public static SceneMgr Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new SceneMgr();
            }
            return mInstance;
        }
    }
    #endregion
    private GameObject curren;
    private Transform parentObj = null;

    public void SwitchScene(string name, params object[] sceneArgs)
    {
        //GameObject scene = ResourceMgr.GetInstance().CreateGameObject("Game/UI/"+name, false);
        GameObject scene = new GameObject(name);
        SceneBase baseObj = scene.AddComponent(Type.GetType(name)) as SceneBase;
        baseObj.Init(sceneArgs);
        if (parentObj == null)
        {
            parentObj = GameObject.Find("UI Root").transform;
        }
        scene.transform.parent = parentObj;
        scene.transform.parent.localEulerAngles = Vector3.zero;
        scene.transform.localScale = Vector3.one;
        scene.transform.localPosition = Vector3.zero;
        if (curren != null)
        {
            GameObject.Destroy(curren);
        }
        curren = scene;
    }
}
