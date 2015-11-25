using UnityEngine;
using System.Collections;

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

    public void SwitchScene(string name)
    {
        GameObject scene = ResourceMgr.GetInstance().CreateGameObject("Game/UI/"+name, false);

        if (curren != null)
        {
            GameObject.Destroy(curren);
        }
        curren = scene;
    }
}
