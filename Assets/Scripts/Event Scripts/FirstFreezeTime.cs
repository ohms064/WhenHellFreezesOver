using UnityEngine;
using System.Collections;

public class FirstFreezeTime : MonoBehaviour {

    private bool hasExcecuted = false;
    public Rigidbody puzzleCube;
    public float time;

    void OnTriggerEnter(Collider col ) {
        if ( hasExcecuted )
            return;
        if ( col.transform.CompareTag( "Player" ) ) {
            hasExcecuted = true;
            StartCoroutine( "StartEvent" );
        }
    }

    IEnumerator StartEvent() {
        puzzleCube.useGravity = true;
        TimeManager.FreezeScene( false );
        PlayerManager.time.enabled = false;
        PlayerManager.animator.StopRunning();
        PlayerManager.movement.enabled = false;
        PlayerManager.time.Unfreeze();
        yield return new WaitForSeconds( time );
        PlayerManager.time.enabled = true;
        PlayerManager.movement.enabled = true;
        PlayerManager.time.Freeze();
    }
	
}
