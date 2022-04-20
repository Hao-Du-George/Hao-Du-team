using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldRotate : MonoBehaviour {
    GameObject player;
	void Start () {
        player = GameObject.Find("character");
    }
	
	void Update () {

        //自旋转
        transform.Rotate(Vector3.up * 3);
        Attract();
    }

    /// <summary>
    /// 吸引金币
    /// </summary>
    void Attract()
    {
        //如果吸铁石生效并且人物距离金币小于5金币会被吸引
        if (dataManager.instance.isAttract == true && Vector3.Distance(player.transform.position,transform.position) <= 5)
        {
            Vector3 direction = player.transform.position - transform.position;
            transform.LookAt(player.transform);
            transform.Translate(direction * Time.deltaTime * 10);
        }
    }
    
}
