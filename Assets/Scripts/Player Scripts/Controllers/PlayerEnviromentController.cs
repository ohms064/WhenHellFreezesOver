using UnityEngine;
using System.Collections;

public class PlayerEnviromentController : MonoBehaviour {

    public Transform grabedObject;
    public float grabRange = 5.0f;
    [HideInInspector]
    public bool grabingObject;

    private Ray _mouseRay;
    private RaycastHit _mouseHit;
    private bool _leftClick;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        _leftClick = Input.GetMouseButtonDown( 0 );
        if ( !TimeManager.frozen &&  _leftClick) {
            if( grabingObject ) {
                Drop();
                return;
            }
            _mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
            if ( Physics.Raycast( _mouseRay, out _mouseHit, 1 << 10 )) {
                grabedObject = _mouseHit.transform;
                if ( Vector3.Distance( grabedObject.position, this.transform.position ) < grabRange) {
                    Grab();
                }else {
                    grabedObject = null;
                    grabingObject = false;
                }
            }
        }
        else if(_leftClick){
            _mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
            if(Physics.Raycast(_mouseRay, out _mouseHit, 1 << 10 ) ) {
                grabedObject = _mouseHit.transform;
            }
        }
	}

    private void Drop() {
        grabedObject.parent = null;
        grabedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabedObject = null;
        grabingObject = false;
    }

    private void Grab() {
        grabingObject = true;
        grabedObject.position = this.transform.position + this.transform.right;
        grabedObject.parent = this.transform;
        grabedObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
