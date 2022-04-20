using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float tilt;
    Rigidbody rigid2D;

    public GameObject shot;
    public Transform shotTransform;

    public float fireRate;
    public float nextFire;
    public AudioClip[] audios;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody>();
    }

	private void Update()
	{
        if (Time.time > nextFire)
        {
            Instantiate(shot, shotTransform.position, shotTransform.rotation);
            nextFire = Time.time + fireRate;
            //GetComponent<AudioSource>().clip = audios[0];
            //GetComponent<AudioSource>().Play();
        }
	}

	private void FixedUpdate()
	{
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigid2D.velocity = movement;
        rigid2D.position = new Vector3
        (
            Mathf.Clamp(rigid2D.position.x, -11.0f, 11.0f),
            0.0f,
            Mathf.Clamp(rigid2D.position.z, -7.0f, 25.0f)
        );
        rigid2D.rotation = Quaternion.Euler(0.0f, 0.0f, moveHorizontal * 2.0f);
	}

	private void OnDestroy()
	{
        Debug.Log("Player Destroy");
        Util.GetUtil().GameOver();
	}
}
