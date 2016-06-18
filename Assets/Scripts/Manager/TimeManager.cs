using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {
    public static IFreezable[] timeBoundObjects;
    public static bool recording, hasted, slowed, frozen; //Estados del juego, si alguno de ellos está activo significa que ese habilidad está activada para algún objeto.

	// Use this for initialization
	void Start () {
        recording = false;
        frozen = false;
        timeBoundObjects = InterfaceHelper.FindObjects<IFreezable>();
    }

    public static void FreezeScene() {
        if (frozen) {
            foreach (IFreezable obj in timeBoundObjects) {
                obj.Unfreeze();
            }
            frozen = false;
        }
        else {
            foreach (IFreezable obj in timeBoundObjects) {
                obj.Freeze();
            }
            frozen = true;
        }
    }

    public static void StartRecording() {
        recording = true;
    }

}
