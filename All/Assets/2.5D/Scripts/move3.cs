using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3 : MonoBehaviour {
    public GameObject leftCube;
    public GameObject rightCube;
    bool isgo = true;
    void Start()
    {

    }

    void Update()
    {
        if (isgo == true)
        {
            transform.Translate(Vector3.right * 1.5f * Time.deltaTime);
        }
        if (isgo == false)
        {
            transform.Translate(Vector3.left * 1.5f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "p1")
        {
            isgo = true;
        }
        if (collision.gameObject.tag == "p2")
        {
            isgo = false;
        }
    }
}
