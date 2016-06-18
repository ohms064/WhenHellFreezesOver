using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class PlayerMovementController : MonoBehaviour {
    private Rigidbody _rigidbody;
    private RaycastHit _hit;
    private Ray _ray;

    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;
    // Use this for initialization
	void Start () {
	    _rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    _rigidbody.MovePosition( _rigidbody.position + (Manager.mainCamera.transform.right * Time.deltaTime * movementSpeed * Input.GetAxis( "Horizontal" )));
        _ray = new Ray(this.transform.position, -this.transform.up);
	    if ( Physics.Raycast( _ray, out _hit, (this.transform.localScale.y / 2) + 0.5f) && Input.GetKeyDown(KeyCode.Space)) {
	        _rigidbody.AddForce( this.transform.up * jumpForce, ForceMode.Impulse );
	    }
	    
	}
}
