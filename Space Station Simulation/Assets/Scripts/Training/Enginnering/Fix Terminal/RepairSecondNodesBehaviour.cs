using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSecondNodesBehaviour : MonoBehaviour {

    //Main controller.
    FixTerminalController fixTerminalController;

    [Header("Which tool to use?")]
    public string toolNeededName;

    public bool isRepaired;

    public float timeLeft = 4f;

    public ParticleSystem ps;

    [Header("Which node will be this iteration?")]
    [Range(1, 2)]
    int nodeIndex;

    void Start()
    {

        //Fetch the controller.
        fixTerminalController = FindObjectOfType<FixTerminalController>();

        //The node at the beginning is not repaired!
        isRepaired = false;
    }

    //Repair this node.
    private void RepairNode()
    {
        //Set this node as repaired.
        isRepaired = true;
        //Check if all nodes are repaired!
        fixTerminalController.SendMessage("CheckSecondPhaseCompletion");
        //Stop the particles!
        var main = ps.main;
        main.startLifetime = 0f;
    }

    //While the player is interacting with the node...
    private void OnTriggerStay(Collider other)
    {
        //And the tool's name is indeed the one needed...
        if (other.tag == "Tool" && other.name == toolNeededName)
        {
            //print("Interacting with tool : "+other.name+" at "+this.gameObject.name);

            //Lower the counter.
            timeLeft -= Time.deltaTime;

            //Once the counter ends, repair the actual node.
            if (timeLeft <= 0)
            {
                RepairNode();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timeLeft = 2.5f;

        if (this.nodeIndex == 1)
        {
            fixTerminalController.firstNodeActive = false;

        }
        else
        {
            fixTerminalController.secondNodeActive = false;
        }
    }
}
