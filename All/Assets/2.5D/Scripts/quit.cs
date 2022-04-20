using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quit : MonoBehaviour {
    public Button quitBtn;

	void Start () {
        quitBtn.onClick.AddListener(ClickQuit);

    }
	
	void Update () {
		
	}

    void ClickQuit()
    {
        SceneManager.LoadScene("ChooseScene");
    }
}
