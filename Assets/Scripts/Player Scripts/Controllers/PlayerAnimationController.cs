﻿using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {
    public Animator _playerAnimator;
    private float _movimiento;
    private bool _isRunning;
    // Use this for initialization
    void Start() {
        //_playerAnimator = this.GetComponent<Animator>();
    }

    public void StartRunning() {
        _isRunning = true;
        _playerAnimator.SetBool( "Running", true );
    }

    public void StopRunning() {
        _isRunning = false;
        _playerAnimator.SetBool( "Running", false );
    }
}
