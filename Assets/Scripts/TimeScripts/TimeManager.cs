using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public static TimeBound[] timeBoundObjects;

	// Use this for initialization
	void Start () {
	    
        timeBoundObjects = Object.FindObjectsOfType<TimeBound>();
    }

    public static void FreezeScene() {
        foreach ( TimeBound obj in timeBoundObjects ) {
            obj.ToggleFreeze();
        }
    }

}
