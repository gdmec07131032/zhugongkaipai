using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneLoading : SceneBase {

    private UISlider mSlider;
    private UILabel mLabel;

    void Start()
    {
        mSlider = transform.Find("Slider").GetComponent<UISlider>();
        mLabel = transform.Find("Label").GetComponent<UILabel>();
        mSlider.value = 0.0f;
        SetLabelInfo(mSlider.value);
        
        StartCoroutine(Test());
    }

    /// <summary>
    /// 通过异步实现递归，模拟进度条
    /// </summary>
    /// <returns></returns>
    IEnumerator Test()
    {
        yield return 1;
        yield return new WaitForSeconds(0.2f);
        mSlider.value += 0.01f;
        SetLabelInfo(mSlider.value);

        if (mSlider.value < 1)
        {
            StartCoroutine(Test());
        }
        else
        {
            Debug.Log("加载完成了!");
        }
    }

    void SetLabelInfo(float value)
    {
        mLabel.text = (value * 100.0f).ToString() + "%";
    }
}
