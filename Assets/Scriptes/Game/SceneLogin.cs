using UnityEngine;
using System.Collections;

public class SceneLogin : SceneBase
{

    private UIInput mInputAcc;
    private UIInput mInputPass;

	// Use this for initialization
	void Start () {
        base.Init();
        mInputAcc = transform.Find("InputAcc").GetComponent<UIInput>();
        mInputPass = transform.Find("InputPass").GetComponent<UIInput>();
        
	}

    protected override void OnClick(GameObject go)
    {
        base.OnClick(go);
        ClickButton(go);
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
            SceneMgr.Instance.SwitchScene("SceneLoading");
        }
        else if (click.name.Equals("BtnReg"))
        {
            Debug.Log("BtnReg");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
