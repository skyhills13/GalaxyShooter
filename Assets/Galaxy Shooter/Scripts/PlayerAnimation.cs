﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            _animator.SetBool("TurnLeft", true);
            _animator.SetBool("TurnRight", false);
        } else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)){
            _animator.SetBool("TurnLeft", false);
            _animator.SetBool("TurnRight", false);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            _animator.SetBool("TurnLeft", false);
            _animator.SetBool("TurnRight", true);
        } else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)){
            _animator.SetBool("TurnLeft", false);
            _animator.SetBool("TurnRight", false);
        }
	}
}
