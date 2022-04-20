using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startUI : MonoBehaviour {
    public Button startBtn;
	void Start () {
        startBtn.onClick.AddListener(ClickStartBtn);

    }
	
	void Update () {
		
	}

    /// <summary>
    /// 点击开始按钮，跳转到选择界面，并初始化数据
    /// 这个函数绑定了开始按钮
    /// </summary>
    void ClickStartBtn()
    {
        PlayerPrefs.SetInt("is1", 0);
        PlayerPrefs.SetInt("is2", 0);
        PlayerPrefs.SetInt("is3", 0);
        PlayerPrefs.SetInt("powerNum", 0);
        SceneManager.LoadScene("ChooseScene");
    }
}
