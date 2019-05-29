using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionEndLighthouse : MonoBehaviour {

    /*public GameObject cameraLighthouse;
    public GameObject cameraPyramid;
    public GameObject targetObject;
    public GameObject dustStorm;
    public GameObject secondPath;
    public GameObject sun;*/

    public GameObject mainCamera;

    public GameObject pathFollowerLighthouse;
    public GameObject pathFollowerPyramid;

    public GameObject dustStorm;
    private ParticleSystem stormParticules;

    public GameObject sun;
    public GameObject ship;

    bool particlesEffectAlreadyPassing = false;

    float timerParticulesEffect = 0.0f;
    int secondsParticulesEffect = 0;

    // Start is called before the first frame update
    void Start() {

        stormParticules = dustStorm.GetComponent<ParticleSystem>();

        //stormParticules.Stop();
    }

    // Update is called once per frame
    void Update() {

        float distanceNextTarget = pathFollowerLighthouse.GetComponent<PathFollowerController>().getTargetDistance();
        int index = pathFollowerLighthouse.GetComponent<PathFollowerController>().getIndex();
        int maxIndex = pathFollowerLighthouse.GetComponent<PathFollowerController>().getMaxIndex();


        if (index == (maxIndex - 1)) {

            // Start storm
            if (!particlesEffectAlreadyPassing) {

                stormParticules.Play();
                particlesEffectAlreadyPassing = true;

                Debug.Log("Storm starting");
            } else {
                timerParticulesEffect += Time.deltaTime;
                secondsParticulesEffect = (int)timerParticulesEffect % 60;
            }

            // Change camera and modify the sun
            if (secondsParticulesEffect == 2) {

                Debug.Log("Transition starting");

                //cameraLighthouse.GetComponent<Collider>().enabled = false;

                //cameraLighthouse.transform.Find("RigidBodyFPSController").GetComponent<Collider>().enabled = false;

                //mainCamera.transform.Find("Pyrogue").gameObject.SetActive(false);
                ship.SetActive(false);

                pathFollowerLighthouse.GetComponent<PathFollowerController>().start = false;
                pathFollowerLighthouse.GetComponent<TransitionEndLighthouse>().enabled = false;

                pathFollowerPyramid.GetComponent<PathFollowerController>().start = true;

                // Change position of the camera in the first target of path
                //mainCamera.transform.position = firstTargetPathFollowerPyramid.transform.position;
                mainCamera.transform.position = pathFollowerPyramid.transform.GetChild(0).GetChild(0).transform.position;

                //sun.GetComponent<RealtimeGlobalIllumination>().currentTimeOfDay = 0.45f;
            }

        }
    }

}
