using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    public void ClickLoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}
