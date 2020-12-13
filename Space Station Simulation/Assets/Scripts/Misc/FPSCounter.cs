using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour {

	string label = "";
	float count;
	
	IEnumerator Start ()
	{
        Application.targetFrameRate = 80;
		//GUI.depth = 2;
		while (true) {
			if (Time.timeScale == 1) {
				yield return new WaitForSeconds (0.1f);
				count = (1 / Time.deltaTime);
				label = "FPS :" + (Mathf.Round (count));
			} else {
				label = "Pause";
			}
            print(label);
			yield return new WaitForSeconds (0.5f);
		}
	}
	
}
