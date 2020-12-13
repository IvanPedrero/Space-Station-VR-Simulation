using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalSensor : MonoBehaviour {

    public bool isTouchingTerminal = true;
    public bool isTouchingDamaged = false;
    public bool isTouchingNew = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Terminal")
        {
            isTouchingTerminal = true;
            //ResetPosition(other);
        }
        if (other.tag == "DamagedCircuit")
        {
            isTouchingDamaged = true;
        }
        if(other.tag == "NewCircuit")
        {
            isTouchingNew = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Terminal")
        {
            isTouchingTerminal = false;
        }
        if (other.tag == "DamagedCircuit")
        {
            isTouchingDamaged = false;
        }
        if (other.tag == "NewCircuit")
        {
            isTouchingNew = false;
        }
    }
}
