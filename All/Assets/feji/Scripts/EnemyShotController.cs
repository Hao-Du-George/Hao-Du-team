using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {
    
    public GameObject playerExplosion;

	// Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -1.0f * 10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
	}
}
