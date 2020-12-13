using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{
    public class GamingActivity : MonoBehaviour
    {

        public enum TRAINING_PHASE
        {
            first_phase,    //Control not activated yet.
            second_phase,    //The little guy is activated. Items need to appear.
            FINISHED_TRAINING
        }
        public TRAINING_PHASE trainingPhase = TRAINING_PHASE.first_phase;

        public GameObject itemsObject;  //This one will hold all the items.
        public List<GameObject> itemsList;

        public bool gameStarted,alreadyStarted;
        public Interactable jeff;
        [Header("Jeff object reset positions :")]
        public GameObject jeffObject;
        public Transform jeffObjectOriginalPos;

        public int score = 0;
        public GameObject gamingCanvas;
        public Text scoreText;

        GamingScore gamingScore;

        public Light light;

        public GameObject backgroundMusic;

        private void Start()
        {
            itemsObject.SetActive(false);

            gamingCanvas.SetActive(false);

            backgroundMusic.SetActive(false);

            //Fetch the gaming score.
            gamingScore = FindObjectOfType<GamingScore>();
        }

        private void Update()
        {
            if(trainingPhase == TRAINING_PHASE.first_phase)
            {
                gameStarted = jeff.GetComponent<Interactable>().attachedToHand;
                if (gameStarted)
                {
                    InitSecondPhase();
                }
            }
            if(trainingPhase == TRAINING_PHASE.second_phase)
            {
                scoreText.text = "POINTS COLLECTED : " + score;
            }
        }

        #region Phases completion region
        //Store items in the list.
        void GetItems()
        {
            foreach (Transform child in itemsObject.transform)
            {
                itemsList.Add(child.gameObject);
                //Disable items.
                child.gameObject.SetActive(false);
                child.GetComponent<ItemBehaviour>().collected = false;
            }
            //Enable the first item.
            itemsList[0].SetActive(true);
        }

        //Accessed from every food behaviour as a message.
        public void CheckPhaseCompletion()
        {
            bool phaseCompleted = true;
            foreach (GameObject item in itemsList)
            {
                //If an item is not collected and its an adder, the phase is not complete
                if (item.GetComponent<ItemBehaviour>().collected == false && item.GetComponent<ItemBehaviour>().isAdder)
                {
                    phaseCompleted = false;
                }
            }
            //Enable next item in the list.
            foreach (GameObject item in itemsList)
            {
                //If a belt is not attached, the activity is not completed!
                if (item.GetComponent<ItemBehaviour>().collected == false)
                {
                    item.SetActive(true);

                    //If an item is not an adder, it means that there's another object in the list which needs to be activated. DO NOT return to activate it.
                    if (item.GetComponent<ItemBehaviour>().isAdder)
                    {
                        return;
                    }
                }
            }

            //Manage Results!
            if (phaseCompleted)
            {
                //If the phase was successfully completed, Inititate phase two.
                EndActivity();
                //Update one last time the score to avoid losing losing last item count.
                scoreText.text = "POINTS COLLECTED : " + score;
            }
        }

        public void DestroyCubes()
        {
            foreach (GameObject item in itemsList)
            {
                item.SetActive(false);
            }
        }

        #endregion

        #region Initialize region

        //This one is going to be accessed from one of the buddys! The items won't be visible until you grab one controller.
        public void InitSecondPhase()
        {
            trainingPhase = TRAINING_PHASE.second_phase;
            itemsObject.SetActive(true);
            gamingCanvas.SetActive(true);
            GetItems();
            backgroundMusic.SetActive(true);
        }

        void EndActivity()
        {
            trainingPhase = TRAINING_PHASE.FINISHED_TRAINING;
            gamingScore.SetScore(score);

            Destroy(this.gameObject);
        }

        public void EndActivityKilled()
        {
            //Print something red
            EndActivity();
        }

        #endregion

        #region Score adding
        public void AddScore()
        {
            StartCoroutine(FlashGreen());
            score += 10;
        }
        IEnumerator FlashGreen()
        {
            bool flash;
            Color prev = light.color;
            flash = true;
            while (flash)
            {
                light.color = Color.green;
                yield return new WaitForSeconds(0.1f);
                flash = false;
                light.color = prev;
            }
        }

        public void RemoveScore()
        {
            StartCoroutine(FlashRed());
            score -= 10;

            if(score <= 0)
            {
                score = 0;
            }
        }
        IEnumerator FlashRed()
        {
            bool flash;
            Color prev = light.color;
            flash = true;
            while (flash)
            {
                light.color = Color.red;
                yield return new WaitForSeconds(0.1f);
                flash = false;
                light.color = prev;
            }
        }


        #endregion
    }

}

