using UnityEngine;
using System.Collections;

public class PathFollowerController : MonoBehaviour {

    public bool start;
    public float speed = 100f;
    public float distanceTarget;

    public GameObject[] objectsMove;

    public Transform pathParent;
    Transform targetPoint;
	
    private int index;
    private int maxIndex;

	void OnDrawGizmos() {
		Vector3 from;
		Vector3 to;
		for (int a=0; a < pathParent.childCount - 1; a++) {
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a + 1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 0, 0);
			Gizmos.DrawLine (from, to);
		}
	}
	
    void Start () {
        start = false;
		index = 1;
        distanceTarget = 0;

        maxIndex = pathParent.transform.childCount;
		targetPoint = pathParent.GetChild(index);
    }
	
	// Update is called once per frame
	void Update () {

        // Stop the follower
        if (index == maxIndex) { start = false; }

        if (start) {

            for (int a = 0; a < objectsMove.Length; a++) {

                // Move object in target
                objectsMove[a].transform.position = Vector3.MoveTowards(objectsMove[a].transform.position, targetPoint.position, speed * Time.deltaTime);

                // Calculate distance between object / target
                distanceTarget = Vector3.Distance(objectsMove[a].transform.position, targetPoint.position);

                if (distanceTarget < 0.1f && index != pathParent.childCount) {

                    index++;

                    if (index < pathParent.childCount) {
                        index %= pathParent.childCount;
                        targetPoint = pathParent.GetChild(index);
                    }

                }
            }

        }
    }

    public float getTargetDistance() { return this.distanceTarget; }
    public int getIndex() { return this.index; }
    public int getMaxIndex () { return this.maxIndex; }
}
