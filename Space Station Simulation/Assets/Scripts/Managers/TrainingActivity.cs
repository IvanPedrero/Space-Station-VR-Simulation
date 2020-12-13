using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingActivity : MonoBehaviour {

    public string name;
    [TextArea(3, 10)]
    public string description;
    public float highScore;
    public float MAX_SCORE = 100f;

}
