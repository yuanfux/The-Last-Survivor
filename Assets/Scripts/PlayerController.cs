using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0F;
    public float rotateSpeed = 20.0F;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        float rawVertical = Input.GetAxisRaw("Vertical");
        float rawHorizontal = Input.GetAxisRaw("Horizontal");
        if (rawVertical != 0)
        {
            Debug.Log("vertical " + rawVertical);
        }
        if (rawHorizontal != 0)
        {
            Debug.Log("horizontal " + rawHorizontal);
        }
        if (rawVertical != 0 || rawHorizontal != 0)
        {
            // if the key was pressed, rotate and translate
            Vector3 rotateDirection = new Vector3(rawHorizontal, 0, rawVertical);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateDirection), rotateSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        // float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        // float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        // transform.Translate(0, 0, translation);
        // transform.Rotate(0, rotation, 0);
    }
}
