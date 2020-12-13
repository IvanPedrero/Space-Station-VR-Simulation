using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class ItemBehaviour : MonoBehaviour
    {


        public bool collected = false;

        public bool isAdder;

        GamingActivity gamingActivity;

        private void Start()
        {
            //Fetch the controller.
            gamingActivity = FindObjectOfType<GamingActivity>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Buddy" && collected == false)
            {
                //Set the flag as collected.
                collected = true;
                //If you want to add score...
                if (isAdder)
                {
                    gamingActivity.AddScore();
                }
                //If you want to remove score...
                else
                {
                    gamingActivity.RemoveScore();
                }
                //Check the completion of the phase.
                gamingActivity.CheckPhaseCompletion();
                //Destroy it at the end.
                this.gameObject.SetActive(false);
            }
        }
    }
}

