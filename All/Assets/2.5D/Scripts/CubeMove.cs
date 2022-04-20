using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
    bool isMove = false;
	void Start () {
		
	}
	
	void Update () {

        if (transform.localPosition.y >= -8)
        {
            isMove = false;
        }

        if (transform.localPosition.y <= -10)
        {
            isMove = true;
        }

        if (isMove == true)
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime);
        }
        if (isMove == false)
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        }
	}
}
