using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityActivator : MonoBehaviour {

    GameManager gameManager;

    float distanceOfPlayer;

    [Header("Prefab to instantiate : ")]
    public GameObject activityPrefab;

    [Header("Position to instantiate : ")]
    public Transform prefabPosition;

    [Header("Distance for activation :")]
    public float activationDistance = 7.0f;

    public bool instantiated;

    public GameObject activity;

	// Use this for initialization
	void Start () {
        //Fetch game manager.
        this.gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        //Get the distance of the player.
        this.distanceOfPlayer = Vector3.Distance(this.transform.position, Camera.main.transform.position);

        if (this.distanceOfPlayer <= this.activationDistance)
        {
            if (this.instantiated)
            {
                if(this.activity == null)
                {
                    this.activity = Instantiate(this.activityPrefab, this.prefabPosition, false);
                    this.activity.SetActive(true);
                }
            }
            else
            {
                //Right now we need to activate it, INSTANTIATE LATER!
                this.prefabPosition.gameObject.SetActive(true);
            }
        }
        else
        {
            if (instantiated)
            {
                Destroy(this.activity);
                this.activity = null;
            }
            else
            {
                //Right now we need to activate it, INSTANTIATE LATER!
                this.prefabPosition.gameObject.SetActive(false);
            }
        }
	}

}
