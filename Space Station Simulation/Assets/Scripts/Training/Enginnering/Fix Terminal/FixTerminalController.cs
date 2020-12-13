using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTerminalController : MonoBehaviour {

    [Header("Tools Used:")]
    public GameObject[] tools;

    public enum TRAINING_PHASE
    {
        FIRST_PHASE,
        SECOND_PHASE,
        THIRD_PHASE,
        FOURTH_PHASE,
        FIFTH_PHASE,
        FINISHED_TRAINING
    };
    public TRAINING_PHASE trainingPhase = TRAINING_PHASE.FIRST_PHASE;

    [Header("Nodes phases :")]
    public GameObject firstPhaseNodes;
    public GameObject secondPhaseNodes;

    [Header("First Phase Nodes :")]
    public List<GameObject> firstPhaseNodeChildren;
    public List<GameObject> secondPhaseNodeChildren;

    [Header("Third and Fourth Phase Objects :")]
    public GameObject terminalObject;
    public TerminalSensor terminalSensor;
    public GameObject damagedCircuit;
    public GameObject newCircuit;

    [Header("Objects for final positioning :")]
    public Transform commonParent;
    public GameObject terminal;
    public GameObject circuit;

    [HideInInspector]
    public bool firstNodeActive = false, secondNodeActive = false;

    private float time = 0;

    //Set all the nodes off.
    void DeactivateAllNodes()
    {
        firstPhaseNodes.SetActive(false);
        secondPhaseNodes.SetActive(false);
    }

    //Get the to-repair nodes in a list! For each phase!
    void GetFirstPhaseNodes()
    {        
         foreach (Transform child in firstPhaseNodes.transform)
         {
            firstPhaseNodeChildren.Add(child.gameObject);
         }
    }
    void GetSecondPhaseNodes()
    {
        foreach (Transform child in secondPhaseNodes.transform)
        {
            secondPhaseNodeChildren.Add(child.gameObject);
        }
    }



    // Use this for initialization
    void Start () {

        //Deactivate all nodes.
        DeactivateAllNodes();

        //Activate first phase nodes.
        firstPhaseNodes.SetActive(true);

        //Get the first phase nodes.
        GetFirstPhaseNodes();

        //Deactivate the terminal object properties.
        terminalObject.GetComponent<Collider>().enabled = false;
        damagedCircuit.GetComponent<Collider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        /*
        *   The states will be useful for dispalying instructions in the monitor. For optimization, the change of states
        *   will be managed through single calls to the functions in the controller.
        */
        time += Time.deltaTime;

        if (trainingPhase == TRAINING_PHASE.FIRST_PHASE)
        {
            //Already initiated everything at START().
        }
        if (trainingPhase == TRAINING_PHASE.SECOND_PHASE)
        {
            //Initiated this phase through a single call to the function.
        }
        if (trainingPhase == TRAINING_PHASE.THIRD_PHASE)
        {
            //Initiated this phase through a single call to the function.
            if (!terminalSensor.isTouchingTerminal && !terminalSensor.isTouchingDamaged && !terminalSensor.isTouchingNew)
            {
                InitPhaseFour();
            }
        }
        if(trainingPhase == TRAINING_PHASE.FOURTH_PHASE)
        {
            if (!terminalSensor.isTouchingDamaged && terminalSensor.isTouchingNew)
            {
                InitPhaseFive();
            }
        }

        if (trainingPhase == TRAINING_PHASE.FIFTH_PHASE)
        {
            if (terminalSensor.isTouchingTerminal)
            {
                EndActivity();
            }
        }
    }

    //In the first phase, the player must touch for 3 seconds the points. This function is accessed by the nodes!
    public void CheckFirstPhaseCompletion()
    {
        bool phaseCompleted = true;
        foreach (GameObject node in firstPhaseNodeChildren)
        {
            //If a single node is not repaired, the activity is not completed!
            if (node.GetComponent<RepairFirstNodesBehaviour>().isRepaired == false)
            {
                phaseCompleted = false;
            }
        }

        //Manage Results!
        if (phaseCompleted)
        {
            //If the phase was successfully completed, Inititate phase two.
            InitPhaseTwo();
        }
    }

    //In the second phase, the player must touch two nodes with different tools.
    public void CheckSecondPhaseCompletion()
    {
        bool phaseCompleted = true;
        foreach (GameObject node in secondPhaseNodeChildren)
        {
            //If a single node is not repaired, the activity is not completed!
            if (node.GetComponent<RepairSecondNodesBehaviour>().isRepaired == false)
            {
                phaseCompleted = false;
            }
        }

        //Manage Results!
        if (phaseCompleted)
        {
            //If the phase was successfully completed, Inititate phase two.
            InitPhaseThree(); 
        }
    }

    //In the second phase, the player must touch two nodes with different tools.
    public void CheckThirdPhaseCompletion()
    {
        bool phaseCompleted = true;
       

        //Manage Results!
        if (phaseCompleted)
        {
            //If the phase was successfully completed, Inititate phase two.
            
        }
    }
    

    //Phase two initialization.
    void InitPhaseTwo()
    {
        //Set the current state as second phase.
        trainingPhase = TRAINING_PHASE.SECOND_PHASE;
        //Deactivate all nodes.
        DeactivateAllNodes();
        //Activate the second phase nodes.
        secondPhaseNodes.SetActive(true);
        //GetSecondPhaseNodes.
        GetSecondPhaseNodes();
    }

    //Phase three initialization.
    void InitPhaseThree()
    {
        //Set the current state as third phase.
        trainingPhase = TRAINING_PHASE.THIRD_PHASE;
        //Deactivate all nodes.
        DeactivateAllNodes();
        //Activate the properties of the terminal.
        terminalObject.GetComponent<Collider>().enabled = true;
    }

    //Phase four initialization.
    void InitPhaseFour()
    {
        trainingPhase = TRAINING_PHASE.FOURTH_PHASE;
        //Only this one needs to be activated, the other circuit is not touching the surface of the sensor.
        damagedCircuit.GetComponent<Collider>().enabled = true;
    }

    //Phase five initialization.
    void InitPhaseFive()
    {
        trainingPhase = TRAINING_PHASE.FIFTH_PHASE;
        damagedCircuit.transform.parent.gameObject.SetActive(false);
        //newCircuit.transform.parent.position = new Vector3(0, 0, 0);

        //Reset circuit position. First setting the parent as a null position.
        circuit.transform.parent = commonParent;
        circuit.transform.eulerAngles = new Vector3(0,0,90);
        newCircuit.GetComponent<Collider>().enabled = false;
        circuit.transform.localPosition = new Vector3(0.1f, 0, 0);

    }

    void EndActivity()
    {
        //terminalObject.transform.parent.position = new Vector3(0, 0, 0);
        trainingPhase = TRAINING_PHASE.FINISHED_TRAINING;

        terminal.transform.parent = commonParent;
        terminal.transform.localPosition = new Vector3(0, 0, 0);
        terminal.transform.eulerAngles = new Vector3(-90, 0, 90);
        terminalObject.GetComponent<Collider>().enabled = false;

        FindObjectOfType<GameManager>().FinishActivity(0, time);

        Destroy(this.gameObject, 3f);

        

    }
}
