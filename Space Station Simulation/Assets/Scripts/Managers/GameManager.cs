using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;

    public bool inPause, inSettings;

    [Header("Engineering Display :")]
    public bool     engineeringActivityCompleted;
    public float    engineeringActivityTime;
    public Text     engineeringActivityCompletedText;
    public Text     engineeringActivityTimeText;



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        UpdateActivityInfo();
	}
	
 
	public void UpdateActivityInfo() {
        //Engineering.
        if (engineeringActivityCompleted)
        {
            engineeringActivityCompletedText.text = "Activity Completed!";
            engineeringActivityTimeText.text = "Time for completion : " + engineeringActivityTime;
        }
        else
        {
            engineeringActivityCompletedText.text = "Activity has not been completed";
            engineeringActivityTimeText.text = "00:00";
        }


    }

    public void FinishActivity(int activityIndex, float timeTaken)
    {
        if(activityIndex == 0)
        {
            engineeringActivityCompleted = true;
            engineeringActivityTime = timeTaken;
        }

        UpdateActivityInfo();
    }
}
