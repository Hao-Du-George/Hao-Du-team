using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

	// Use this for initialization
	void Start()
    {
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
	void Update()
	{
			
	}

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
