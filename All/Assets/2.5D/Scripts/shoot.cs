using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {
    private GameObject player;
    private GameObject temp1;
    private GameObject temp2;
    bool isgo;
	void Start () {
        player = GameObject.FindWithTag("Player");
        temp1 = GameObject.Find("temp1");
        temp2 = GameObject.Find("temp2");
        if (transform.position.x > player.transform.position.x)
        {
            isgo = true;
        }
        else
        {
            isgo = false;
        }
    }
	
	void Update () {
        if (isgo == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, temp1.transform.position, 10 * Time.deltaTime);
        }
        if (isgo == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, temp2.transform.position, 10 * Time.deltaTime);
        }
	}
}
