﻿using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour{
    public static GameObject player;
    public static PlayerEnviromentController enviroment;
    public static PlayerTimeController time;
    public static PlayerMovementController movement;
    public static PlayerAnimationController animator;
    public static PlayerLifeController life;
    public static Collider collider;

    void Awake() {
        player = GameObject.FindGameObjectWithTag( "Player" );
        enviroment = player.GetComponent<PlayerEnviromentController>();
        time = player.GetComponent<PlayerTimeController>();
        movement = player.GetComponent<PlayerMovementController>();
        animator = player.GetComponent<PlayerAnimationController>();
        life = player.GetComponent<PlayerLifeController>();
        collider = player.GetComponent<Collider>();
    }
}
