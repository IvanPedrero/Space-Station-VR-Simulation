using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalBehaviour : MonoBehaviour {

    public FixTerminalController fixTerminalController;
    public TextMesh terminalText;

	// Use this for initialization
	void Start () {
        ResetTerminalText();
	}
	
	// Update is called once per frame
	void Update () {
		if(fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.FIRST_PHASE)
        {
            terminalText.text = "Use the screw driver\nto remove the bolts";
        }
        if (fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.SECOND_PHASE)
        {
            terminalText.text = "Use the wise grip to \nremove the bigger screws";
        }
        if (fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.THIRD_PHASE)
        {
            terminalText.text = "Remove the monitor";
        }
        if (fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.FOURTH_PHASE)
        {
            terminalText.text = "Remove the damaged circuit\nand place a new one";
        }
        if (fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.FIFTH_PHASE)
        {
            terminalText.text = "Place the terminal back";
        }
        if (fixTerminalController.trainingPhase == FixTerminalController.TRAINING_PHASE.FINISHED_TRAINING)
        {
            terminalText.text = "Activity finished!";
        }
    }

    void ActivateWarningState(string message)
    {

    }

    void DeactivateWarningState(string message)
    {

    }

    void ResetTerminalText()
    {
        terminalText.text = "";
    }

}
