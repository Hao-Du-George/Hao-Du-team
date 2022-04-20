using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Enemy : MonoBehaviour {
    public PlayMakerFSM enemy;
    public GameObject p1;
    public GameObject p2;
    public Slider slider;
    public GameObject winW;
    public GameObject defeatW;
    public AudioSource deafeatAudio;
    bool direction = false;
	void Start () {

    }
	
	void Update () {
        if (transform.position == p1.transform.position)
        {
            direction = true;
        }

        if (transform.position == p2.transform.position)
        {
            direction = false;
        }

        if (direction == true)
        {
            transform.rotation = new Quaternion(0, 0.7f, 0, 0.7f);
            transform.position = Vector3.MoveTowards(transform.position, p2.transform.position, 3 * Time.deltaTime);
        }

        if (direction == false)
        {
            transform.rotation = new Quaternion(0, -0.7f, 0, 0.7f);
            transform.position = Vector3.MoveTowards(transform.position, p1.transform.position, 3 * Time.deltaTime);
        }
	}


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "gem")
        {
            slider.value -= 15;
            if (slider.value <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collider.gameObject);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            defeatW.transform.DOScale(1, 0.3f);
            deafeatAudio.Play();
        }
    }
}
