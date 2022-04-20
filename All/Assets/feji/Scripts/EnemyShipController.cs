using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float nextFire;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -5.0f);
	}
	
	// Update is called once per frame
    void Update () {
        if (Util.GetUtil().isPlaying == true && Time.time > nextFire)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            nextFire = Time.time + fireRate;
        }
	}

	private void OnTriggerEnter(Collider other)
    {
        Util util = FindObjectOfType<Util>();
        if (other.gameObject.tag == "Asteroid" || other.gameObject.tag == "EnemyShot" || other.gameObject.tag == "Boundary"
            || other.gameObject.tag == "EnemyShip")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        if (other.gameObject.tag == "Player")
        {
            Instantiate(util.playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
        if (other.gameObject.tag == "Player Shot")
        {
            util.score += 20;
        }
        Instantiate(util.enemyExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
	}
}
