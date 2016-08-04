using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
//Uses enum grounded state
public class EnemyController : MonoBehaviour, IFreezable {
    [HideInInspector]public Rigidbody rigidbody;
    public GroundedState groundedState;
    [HideInInspector]public bool isJumping;
    public float jumpForce;
    public float deltaDistance = 1.0f;
    public float walkingRayDistance = 2.0f;
    public float fallingRayDistance = 2.0f;
    public float wallRayDistance = 2.0f;

    private RaycastHit _walkingHit;
    private Vector3 nextPosition;
    private Ray _fallingRay, _wallRay, _walkingRay;

    // Use this for initialization
    public void Start () {
        rigidbody = GetComponent<Rigidbody>();
        _fallingRay = new Ray(Vector3.zero, Vector3.down);
    }
	
    private void Update() {
        if (groundedState != GroundedState.GROUNDED || this.rigidbody.isKinematic) return;
        _walkingRay = new Ray(this.transform.position, -this.transform.up);
        if (Physics.Raycast(_walkingRay, out _walkingHit, walkingRayDistance)) {
            Vector3 movementDirection = Vector3.ProjectOnPlane(this.transform.forward, _walkingHit.normal);


            nextPosition = this.transform.position + (deltaDistance * movementDirection);
            _fallingRay = new Ray(nextPosition, Vector3.down);
            _wallRay = new Ray(this.transform.position, this.transform.forward);
            if (!Physics.Raycast(_fallingRay, out _walkingHit, fallingRayDistance) || Physics.Raycast(_wallRay, wallRayDistance, 1535)) {
                Rotate();
            }
            else {
                rigidbody.MovePosition(nextPosition);
            }
        }

    }

    public void Jump(float delta ) {
        switch ( groundedState ) {
            case GroundedState.GROUNDED:
                rigidbody.AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
                groundedState = GroundedState.ON_AIR;
                break;
        }
    }

    public void Rotate() {
        this.transform.forward = -this.transform.forward;
    }

    void OnCollisionEnter(Collision coll) {
        if (coll.transform.CompareTag("Puzzle Cube")) {
            Rotate();
        }
    }

    public void FrozenRotation(float rotation) {
        return;
    }

    public virtual void Freeze() {
        this.rigidbody.isKinematic = true;
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    public virtual void Unfreeze() {
        this.rigidbody.isKinematic = false;
        GetComponent<Renderer>().material.color = Color.red;
    }


#if UNITY_EDITOR
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_walkingRay);
    }
#endif
}
