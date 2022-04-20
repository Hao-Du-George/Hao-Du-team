using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization
    void Start () {
        Util util = FindObjectOfType<Util>();
        float zSpeed = Random.Range(-10.0f, -2.0f);
        float time = 36.0f / Mathf.Abs(zSpeed);
        float width = util.background.transform.localScale.x - 2.0f;
        float xMinSpeed = (-(width / 2.0f) - transform.position.x) / time;
        float xMaxSpeed = ((width / 2.0f) - transform.position.x) / time;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(xMinSpeed, xMaxSpeed), 0.0f, zSpeed);
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
