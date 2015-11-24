using UnityEngine;
using System.Collections;

public class TestRes : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        GameObject obj = ResourcesMgr.GetInstance().CreateGameObject("Game/UI/SceneLoading", false);
        obj.transform.parent = this.gameObject.transform;
        obj.transform.localScale = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
