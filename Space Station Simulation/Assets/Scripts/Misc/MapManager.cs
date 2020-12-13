using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MapManager : MonoBehaviour
{

    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
                                                                         // Use this for initialization

    public GameObject map;

    bool showMap = false;

    bool activated = false;

    private void Start()
    {
        map.SetActive(true);
    }

    private void Update()
    {
        if (!activated)
        {
            map.SetActive(showMap);
            showMap = !showMap;
            activated = true;
        }
    }

    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressed, inputSource);
        }
    }


    private void OnDisable()
    {
        if (grabPinch != null)
        {
            //grabPinch.RemoveOnChangeListener(OnTriggerPressed, inputSource);
        }
    }


    private void OnTriggerPressed(SteamVR_Action_In action_In)
    {

        map.SetActive(showMap);
        showMap = !showMap;

    }

}
