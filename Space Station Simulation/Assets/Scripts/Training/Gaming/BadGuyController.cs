using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valve.VR.InteractionSystem.Sample
{
    public class BadGuyController : MonoBehaviour
    {

        [Header("AI settings")]
        public GameObject target;
        public float speed = 0.5f;
        public float distanceUntilChase = 1f;

        GamingActivity gamingActivity;

        [Header("Pacman animator :")]
        public Animator anim;

        private void Start()
        {
            gamingActivity = FindObjectOfType<GamingActivity>();
        }


        void Update()
        {
            if (gamingActivity.trainingPhase != GamingActivity.TRAINING_PHASE.second_phase)
            {
                return;
            }
            if (Vector3.Distance(this.transform.position, target.transform.position) > distanceUntilChase)
            {
                //Enable animator just once.
                EnableAnimator();
                //Look at jeff and follow him.
                transform.LookAt(target.transform);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
            }
        }

        bool hasBeenEnabled;
        void EnableAnimator()
        {
            if (!hasBeenEnabled)
            {
                anim.SetBool("biting", true);
                hasBeenEnabled = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Buddy")
            {
                gamingActivity.EndActivityKilled();
                
            }
        }
    }
}

