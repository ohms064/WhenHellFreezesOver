using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public static IFreezable[] timeBoundObjects;
    public static bool recording;
    public static bool frozen;

    // Use this for initialization
    void Start () {
        recording = false;
        timeBoundObjects = InterfaceHelper.FindObjects<IFreezable>();
    }

    public static void FreezeScene( bool state ) {
        if ( frozen == state )
            return;
        frozen = state;
        if ( frozen ) {
            foreach ( IFreezable obj in timeBoundObjects ) {
                obj.Freeze();
            }
        }
        else {
            foreach ( IFreezable obj in timeBoundObjects ) {
                obj.Unfreeze();
            }
        }
    }

    public static void StartRecording() {
        recording = true;
    }

}
