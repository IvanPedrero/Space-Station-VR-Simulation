using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSimpleAnimatorControl : MonoBehaviour {

    public bool animationSwitch;

    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();

        anim.SetBool("AnimationOne", animationSwitch);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
