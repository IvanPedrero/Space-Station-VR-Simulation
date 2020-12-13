using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairFirstNodesBehaviour : MonoBehaviour {

    //Main controller.
    FixTerminalController fixTerminalController;

    [Header("Which tool to use?")]
    public string toolNeededName;

    public bool isRepaired;

    public float totalRepairingTime = 2.5f;
    private float timeLeft;

    public ParticleSystem ps;

	void Start () {

        //StartTimer:
        this.timeLeft = totalRepairingTime;

        //Fetch the controller.
        fixTerminalController = FindObjectOfType<FixTerminalController>();

        //The node at the beginning is not repaired!
        this.isRepaired = false;
	}

    //Repair this node.
    private void RepairNode()
    {
        //Set this node as repaired.
        this.isRepaired = true;
        //Check if all nodes are repaired!
        fixTerminalController.SendMessage("CheckFirstPhaseCompletion");
        //Stop the particles!
        var main = ps.main;
        main.startLifetime = 0f;
    }

    //While the player is interacting with the node...
    private void OnTriggerStay(Collider other)
    {
        //And the tool's name is indeed the one needed...
        if(other.tag == "Tool" && other.name == toolNeededName && !this.isRepaired)
        {
            //print("Interacting with tool : "+other.name+" at "+this.gameObject.name+"for : "+this.timeLeft);

            //Lower the counter.
            this.timeLeft -= Time.deltaTime;

            //Once the counter ends, repair the actual node.
            if(this.timeLeft <= 0)
            {
                RepairNode();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //this.timeLeft = totalRepairingTime;
    }
}
