using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public static IFreezable[] timeBoundObjects;
    public static bool recording, hasted, slowed; //Estados del juego, si alguno de ellos está activo significa que ese habilidad está activada para algún objeto.

	// Use this for initialization
	void Start () {
        recording = false;
        timeBoundObjects = InterfaceHelper.FindObjects<IFreezable>();
    }

    public static void FreezeScene() {
        foreach ( IFreezable obj in timeBoundObjects ) {
            obj.ToggleFreeze();
        }
    }

    public static void FreezeScene( bool state ) {
        foreach ( IFreezable obj in timeBoundObjects ) {
            obj.Freeze(state);
        }
    }

    public static void StartRecording() {
        recording = true;
    }

}
