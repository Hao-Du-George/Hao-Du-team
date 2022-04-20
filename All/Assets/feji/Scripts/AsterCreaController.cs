using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsterCreaController : MonoBehaviour {

    public float nextAster;
    public float asterRate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update () {
        Util util = FindObjectOfType<Util>();
        if (Util.GetUtil().isPlaying == true && Time.time > nextAster)
        {
            nextAster = Time.time + asterRate;
            Instantiate(util.asteroid, new Vector3((Random.value * 2.0f - 1.0f) * 11.0f, 0.0f, transform.position.z), transform.rotation);
            Instantiate(util.enemy, new Vector3((Random.value * 2.0f - 1.0f) * 11.0f, 0.0f, transform.position.z), transform.rotation);
        }
	}
}
