using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataManager : MonoBehaviour {
    public static dataManager instance;
    /// <summary>
    /// 单例脚本，储存数据
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    public bool isAttract;//吸铁石是否生效

    void Start () {
        isAttract = false;

    }
	
	void Update () {
		
	}
}
