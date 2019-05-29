using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPyrogue : MonoBehaviour {

    public GameObject pathFollowerLighthouse;
    public GameObject ship;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        int index = pathFollowerLighthouse.GetComponent<PathFollowerController>().getIndex();
        int maxIndex = pathFollowerLighthouse.GetComponent<PathFollowerController>().getMaxIndex();

        if (index < maxIndex) {

            // Increment for next point if exist
            index = (index < maxIndex - 1) ? index++ : index;

            Transform target = pathFollowerLighthouse.transform.GetChild(0).GetChild(index);

            /*Vector3 relativePos = target.position - ship.transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

            ship.transform.rotation = rotation;*/

            //transform.position = Vector3.Lerp(ship.transform.position, target.position, 1f * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(ship.transform.rotation, target.rotation, 1f * Time.deltaTime);

            Vector3 dir = target.position - ship.transform.position;
            dir.y = 0; // keep the direction strictly horizontal

            //Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);

            // slerp to the desired rotation over time
            ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, XLookRotation(dir), 1f * Time.deltaTime);


        }


    }

    Quaternion XLookRotation(Vector3 right) {

        Quaternion rightToForward = Quaternion.Euler(0f, 90f, 0f);
        Quaternion forwardToTarget = Quaternion.LookRotation(right, Vector3.up);

        return forwardToTarget * rightToForward;
    }
}