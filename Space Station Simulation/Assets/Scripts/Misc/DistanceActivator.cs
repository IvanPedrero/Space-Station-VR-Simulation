using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceActivator : MonoBehaviour {

    float distanceOfPlayer;
    public float activationDistance = 1.5f;

    public GameObject objectToDeactivate;

    void ActivateOnDistance()
    {
        //Get the distance of the player.
        this.distanceOfPlayer = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        if (this.distanceOfPlayer <= this.activationDistance)
        {
            this.objectToDeactivate.SetActive(true);
        }
        else
        {
            this.objectToDeactivate.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
        ActivateOnDistance();
	}
}
