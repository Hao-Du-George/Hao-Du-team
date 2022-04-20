using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

	private void OnTriggerEnter(Collider other)
	{
        Util util = FindObjectOfType<Util>();
        if (other.gameObject.tag == "Boundary" || other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyShot"
            || other.gameObject.tag == "Asteroid")
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            Instantiate(playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
        if (other.gameObject.tag == "Player Shot")
        {
            util.score += 10;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
	}
}
