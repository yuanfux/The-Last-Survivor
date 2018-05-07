using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 10f;

    public Vector3 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 dest = target.position + offset;
        Vector3 smoothDest = Vector3.Lerp(transform.position, dest, smoothSpeed * Time.deltaTime);
        transform.position = smoothDest;
	}
}
