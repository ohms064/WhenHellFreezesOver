using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour{
    public static GameObject main;
    public static PlayerEnviromentController enviroment;
    public static PlayerTimeController time;
    public static PlayerMovementController movement;

    void Awake() {
        main = GameObject.FindGameObjectWithTag( "Player" );
        enviroment = main.GetComponent<PlayerEnviromentController>();
        time = main.GetComponent<PlayerTimeController>();
        movement = main.GetComponent<PlayerMovementController>();
    }
}
