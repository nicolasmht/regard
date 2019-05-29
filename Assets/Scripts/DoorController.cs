using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public bool isOpen;

    // Start is called before the first frame update
    void Start() {
        isOpen = false;
    }

    // Update is called once per frame
    void Update() {

        int scaleY = (int)transform.localScale.y;

        if (isOpen && scaleY > 0) {


        } else {

        }

    }

    void openDoor() {

        //if (isOpen && scaleY > 0) {

        //    transform.localScale += new Vector3(0.0f, -0.5f, 0.0f);
        //    transform.position += new Vector3(0.0f, 0.5f, 0.0f);
        //}

    }
}
