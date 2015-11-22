using UnityEngine;
using System.Collections;

public class BtnLogin : MonoBehaviour {

    public UIInput mInputAcc;
    public UIInput mInputPass;

	// Use this for initialization
	void Start () {
        mInputAcc = transform.Find("InputAcc").GetComponent<UIInput>();
        mInputPass = transform.Find("InputPass").GetComponent<UIInput>();
        BoxCollider[] boxs = transform.GetComponentsInChildren<BoxCollider>(true);
        foreach (BoxCollider box in boxs)
        {
            UIEventListener listener = UIEventListener.Get(box.gameObject);
            listener.onClick = ClickButton;
        }
	}

    void ClickButton(GameObject click)
    {
        if (click.name.Equals("BtnLogin"))
        {
            Debug.Log(string.Format("点击了登陆 账号：{0} 密码：{1}", mInputAcc.value, mInputPass.value));
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
