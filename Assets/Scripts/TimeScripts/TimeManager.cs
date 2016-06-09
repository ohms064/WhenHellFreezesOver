using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public static TimeBound[] timeBoundObjects;
    public static bool recording;

	// Use this for initialization
	void Start () {
        recording = false;
        timeBoundObjects = Object.FindObjectsOfType<TimeBound>();
    }

    public static void FreezeScene() {
        foreach ( TimeBound obj in timeBoundObjects ) {
            obj.ToggleFreeze();
        }
    }

    public static void FreezeScene( bool state ) {
        foreach ( TimeBound obj in timeBoundObjects ) {
            obj.Freeze(state);
        }
    }

    public static void StartRecording() {
        recording = true;
    }

}
