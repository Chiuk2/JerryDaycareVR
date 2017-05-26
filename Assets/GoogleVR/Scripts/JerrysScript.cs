using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerrysScript : MonoBehaviour {
    public GameObject[] waypoints;
    float speed = 1.2f;
    float accuracyWP = 0.2f;
    int currentWP = 0;
    bool isMoving = false;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (waypoints.Length > 0)
        {
            float dist = Vector3.Distance(waypoints[currentWP].transform.position, transform.position);
            if (isMoving == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWP].transform.position, Time.deltaTime * speed);
            }
            if (dist <= accuracyWP)
            {

                if (currentWP >= waypoints.Length - 1)
                {
                    isMoving = false;

                }
                else
                {
                    currentWP++;
                }
            }
        }
    }
    public void beginJerrys()
    {
        isMoving = true;
    }
}
