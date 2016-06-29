using UnityEngine;
using System.Collections;

public enum GrabStatus {
    GRABING_OBJECT,
    ROTATING_OBJECT,
    HANDS_FREE
}

public class PlayerEnviromentController : MonoBehaviour {
    public float rotationSensitivity = 2.0f;
    public float grabRange = 5.0f;

    [HideInInspector]
    public GrabStatus grabStatus;
    [HideInInspector]
    public Transform grabedObject;

    private Ray _mouseRay;
    private RaycastHit _mouseHit;

	// Use this for initialization
	void Start () {
        grabStatus = GrabStatus.HANDS_FREE;
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            if( grabStatus == GrabStatus.GRABING_OBJECT && !TimeManager.isFrozen) {
                Drop();
                return;
            }
            _mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
            if ( Physics.Raycast( _mouseRay, out _mouseHit, 1 << 10 ) ) {
                print( LayerMask.GetMask( "EnviromentObjects" ) );
                
                
                grabedObject = _mouseHit.transform;
                if ( TimeManager.isFrozen && grabStatus != GrabStatus.ROTATING_OBJECT ) {
                    grabStatus = GrabStatus.ROTATING_OBJECT;
                    StartCoroutine( "RotateFrozenObject" );
                    return;
                }
                if ( Vector3.Distance( grabedObject.position, this.transform.position ) < grabRange ) {
                    Grab();
                }
                else {
                    grabedObject = null;
                    grabStatus = GrabStatus.HANDS_FREE;
                }
            }
        }
	}

    void Drop() {
        grabedObject.parent = null;
        grabedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabedObject = null;
        grabStatus = GrabStatus.HANDS_FREE;
    }

    void Grab() {
        grabStatus = GrabStatus.GRABING_OBJECT;
        grabedObject.position = this.transform.position + this.transform.right;
        grabedObject.parent = this.transform;
        grabedObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    IEnumerator RotateFrozenObject() {
        IFreezable frozenObject = grabedObject.GetComponent<IFreezable>();
        Vector3 mouseStartPosition = Input.mousePosition;
        Vector3 mouseVector;
        while ( Input.GetMouseButton( 0 ) && Vector3.Distance(this.transform.position, grabedObject.position) < grabRange){
            mouseVector = Input.mousePosition - mouseStartPosition;
            frozenObject.FrozenRotation((mouseVector.x + mouseVector.y) * -rotationSensitivity);
            yield return new WaitForEndOfFrame();
        }
        grabStatus = GrabStatus.HANDS_FREE;
    }
}
