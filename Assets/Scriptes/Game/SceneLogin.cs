using UnityEngine;
using System.Collections;

public class SceneLogin : SceneBase
{

    private UIInput mInputAcc;
    private UIInput mInputPass;

    protected override void OnClick(GameObject go)
    {
        base.OnClick(go);
        ClickButton(go);
    }
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneLogin");
        base.OnInitSkin();
    }
    protected override void OnInitDone()
    {
        base.OnInitDone();
        mInputAcc = skinTransform.Find("InputAcc").GetComponent<UIInput>();
        mInputPass = skinTransform.Find("InputPass").GetComponent<UIInput>();

        string str = (string)sceneArgs[0];
        int i = (int)sceneArgs[1];
        bool bo = (bool)sceneArgs[2];
        Debug.Log(str + "---" + i + "---" + bo);
    }

    protected override void OnDestroyFront()
    {
        base.OnDestroyFront();
        Debug.Log("OnDestroyFront");
    }

    protected override void OnDestroyEnd()
    {
        base.OnDestroyEnd();
        Debug.Log("OnDestroyEnd");
        mInputAcc = null;
        mInputPass = null;
    }

    void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnLogin"))
        {
            Debug.Log(string.Format("点击了登陆 账号：{0} 密码：{1}", mInputAcc.value, mInputPass.value));
            //GameObject go = ResourceMgr.GetInstance().CreateGameObject("Game/UI/SceneLoading", false);
            //Destroy(this.gameObject);
            SceneMgr.Instance.SwitchScene(SceneType.SceneLoading,"hello world");
        }
        else if (click.name.Equals("BtnReg"))
        {
            Debug.Log("BtnReg");
        }
    }
}
