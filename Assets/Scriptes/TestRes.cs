using UnityEngine;
using System.Collections;

public class TestRes : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        //GameObject obj = ResourceMgr.GetInstance().CreateGameObject("Game/UI/SceneLogin", false);
        SceneMgr.Instance.SwitchScene(SceneType.SceneLogin,"haha",22,false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
//"($File)" $(Line)
