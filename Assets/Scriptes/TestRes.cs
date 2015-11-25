using UnityEngine;
using System.Collections;

public class TestRes : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        //GameObject obj = ResourceMgr.GetInstance().CreateGameObject("Game/UI/SceneLogin", false);
        SceneMgr.Instance.SwitchScene("SceneLogin");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
//"($File)" $(Line)
