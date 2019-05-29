using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public bool isOpen;
    public bool isClose;
    private float sizeY;
    private Vector3 positionOrigin;
    private Vector3 scaleOrigin;

    // Start is called before the first frame update
    void Start() {
        isOpen = false;
        isClose = false;
        sizeY = transform.position.y;
        positionOrigin = transform.position;
        scaleOrigin = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        int scaleY = (int)transform.localScale.y;
        int positionY = (int)transform.position.y;

        if (isOpen && positionY < sizeY + sizeY/2) {

            transform.position += new Vector3(0.0f, 0.1f, 0.0f);

            if (scaleY > 0) {
                transform.localScale += new Vector3(0.0f, -0.15f, 0.0f);
            }
        }

        // Reset varibale isOpen
        if (positionY == (int)(sizeY + sizeY / 2)) {
            isOpen = false;
        }

        // Reset closeDoor
        if (isClose) {
            transform.position = positionOrigin;
            transform.localScale = scaleOrigin;
            isClose = false;
        }
    }

}
