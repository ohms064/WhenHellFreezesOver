using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
//Uses enum grounded state
public class EnemyController : MonoBehaviour, IFreezable {
    private Rigidbody _rigidbody;
    public GroundedState groundedState;
    public bool isJumping;
    public float jumpForce;
    public float deltaDistance = 1.0f;
    public float rayDistance = 2.0f;

    private RaycastHit _walkingHit;
    private Vector3 nextPosition;
    private Ray _fallingRay, _wallRay, _walkingRay;
    private Vector3 _directionAtStop, _angularVelocityAtStop;
    private float _speedAtStop;
    private float _forceUpAngle;
    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _fallingRay = new Ray(Vector3.zero, Vector3.down);
    }
	
    void Update() {
        if (groundedState != GroundedState.GROUNDED || this._rigidbody.isKinematic) return;
        _walkingRay = new Ray(this.transform.position, -this.transform.up);
        if (Physics.Raycast(_walkingRay, out _walkingHit, rayDistance)) {
            Vector3 movementDirection = Vector3.ProjectOnPlane(this.transform.forward, _walkingHit.normal);


            nextPosition = this.transform.position + (deltaDistance * movementDirection);
            _fallingRay = new Ray(nextPosition, Vector3.down);
            _wallRay = new Ray(this.transform.position, this.transform.forward);
            if (!Physics.Raycast(_fallingRay, out _walkingHit, rayDistance) || Physics.Raycast(_wallRay, rayDistance)) {
                Rotate();
            }
            else {
                _rigidbody.MovePosition(nextPosition);
            }
        }

    }

    public void Jump(float delta ) {
        switch ( groundedState ) {
            case GroundedState.GROUNDED:
                _rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
                groundedState = GroundedState.ON_AIR;
                break;
        }
    }

    public void Rotate() {
        this.transform.forward = -this.transform.forward;
    }

    void OnCollisionEnter(Collision coll) {
        if (coll.transform.CompareTag("PuzzleElement")) {
            Rotate();
        }
    }

    public void FrozenRotation(float rotation) {
        return;
    }

    public void Freeze() {
        this._rigidbody.isKinematic = true;
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void Unfreeze() {
        this._rigidbody.isKinematic = false;
        GetComponent<Renderer>().material.color = Color.red;
    }
}
