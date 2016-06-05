using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTimeController : MonoBehaviour, ITimeMaster {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if ( Input.GetKeyDown( KeyCode.E ) ) {
	        FreezeTime();
	    }
	}

    public void FreezeTime() {
        TimeManager.FreezeScene();
    }

    public void SlowTime() {
        throw new System.NotImplementedException();
    }

    public void HasteTime() {
        throw new System.NotImplementedException();
    }

    public void RewindTime() {
        throw new System.NotImplementedException();
    }
}
