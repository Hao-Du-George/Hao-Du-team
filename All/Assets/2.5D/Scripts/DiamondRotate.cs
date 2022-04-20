using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondRotate : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Vector3.up * 3);
	}
}
