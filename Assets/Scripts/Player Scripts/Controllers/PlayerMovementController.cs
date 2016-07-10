using System.Collections;
using UnityEngine;

public enum GroundedState {
    GROUNDED,
    ON_AIR,
    SEMI_GROUNDED
}

[RequireComponent( typeof( Rigidbody ) )]
public class PlayerMovementController : MonoBehaviour {
    private Rigidbody _rigidbody;
    private bool _isJumping;
    private bool _jumpButtonDown;
    private Ray _groundRay;
    private GroundedState _grounded;
    private float _movement;

    public float runningThresold = 5.0f;
    public float runningMultiplier = 1.5f;
    public float jumpTime = 0.1f;
    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;

    // Use this for initialization
    private void Start() {
        _rigidbody = this.GetComponent<Rigidbody>();
        _groundRay = new Ray( this.transform.position - this.transform.localScale / 2, -this.transform.up );
    }

    // Update is called once per frame
    private void FixedUpdate() {
        _movement = Input.GetAxis( "Horizontal" );
        _groundRay.origin = this.transform.position - (this.transform.localScale.y / 2) * Vector3.up;
        if(Physics.Raycast( _groundRay, 0.65f ) ) {
            _grounded = GroundedState.GROUNDED;
        }
        else if( TimeManager.isFrozen && Physics.Raycast( _groundRay, 0.7f, 1 << 10 )){
            _grounded = GroundedState.SEMI_GROUNDED;
        }  
        else {
            _grounded = GroundedState.ON_AIR;
        }

        _rigidbody.MovePosition( _rigidbody.position + (Vector3.right * Time.deltaTime * movementSpeed * _movement) );
        if(_movement < 0 ) {
            PlayerManager.animator.StartRunning();
            this.transform.right = Vector3.forward;
        }
        else if (_movement > 0){
            PlayerManager.animator.StartRunning();
            this.transform.right = -Vector3.forward;
        }else {
            PlayerManager.animator.StopRunning();
        }

        _jumpButtonDown = Input.GetKey( KeyCode.Space );
        if ( _jumpButtonDown && !_isJumping ) {
            switch ( _grounded ) {
                case GroundedState.GROUNDED:
                    _isJumping = true;
                    StartCoroutine( "JumpCoroutine", jumpForce );
                    break;
                case GroundedState.SEMI_GROUNDED:
                    _isJumping = true;
                    StartCoroutine( "JumpCoroutine", jumpForce * 0.75f );
                    break;
                case GroundedState.ON_AIR:
                    break;
            }
        }
    }

    private IEnumerator JumpCoroutine(float force) {
        _rigidbody.velocity = Vector2.zero;
        float timer = 0.0f;
        float jumpPercentage;
        Vector3 frameForce;
        while ( _jumpButtonDown && timer < jumpTime ) {
            jumpPercentage = timer / jumpTime;
            frameForce = Vector2.Lerp( Vector2.up * force, Vector2.zero, jumpPercentage );
            _rigidbody.AddForce( frameForce, ForceMode.VelocityChange );
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _isJumping = false;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos() {
        if ( Application.isPlaying ) {
            switch ( _grounded ) {
                case GroundedState.GROUNDED:
                    Gizmos.color = Color.green;
                    break;
                case GroundedState.SEMI_GROUNDED:
                    Gizmos.color = Color.magenta;
                    break;
                case GroundedState.ON_AIR:
                    Gizmos.color = Color.red;
                    break;
            }
            Gizmos.DrawRay( _groundRay );
            Gizmos.color = Color.blue;
            Gizmos.DrawRay( this.transform.position, this.transform.right );
        }
    }

#endif
}