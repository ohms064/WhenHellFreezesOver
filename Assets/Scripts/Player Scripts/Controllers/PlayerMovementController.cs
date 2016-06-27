using System.Collections;
using UnityEngine;

[RequireComponent( typeof( Rigidbody ) )]
public class PlayerMovementController : MonoBehaviour {
    private Rigidbody _rigidbody;
    private bool _jumping;
    private bool _jumpButtonDown;
    private Ray _groundRay;
    private bool _grounded;

    public float jumpTime;
    public float movementSpeed = 5.0f;
    public float jumpForce = 5.0f;

    // Use this for initialization
    private void Start() {
        _rigidbody = this.GetComponent<Rigidbody>();
        _groundRay = new Ray( this.transform.position - this.transform.localScale / 2, -this.transform.up );
    }

    // Update is called once per frame
    private void FixedUpdate() {
        _groundRay.origin = this.transform.position - (this.transform.localScale.y / 2) * Vector3.up;
        _grounded = Physics.Raycast( _groundRay, 0.55f );
        _jumpButtonDown = Input.GetKey( KeyCode.Space );
        _rigidbody.MovePosition( _rigidbody.position + (Vector3.right * Time.deltaTime * movementSpeed * Input.GetAxis( "Horizontal" )) );
        if ( _jumpButtonDown && !_jumping && _grounded ) {
            _jumping = true;
            StartCoroutine( "JumpCoroutine" );
        }
    }

    private IEnumerator JumpCoroutine() {
        _rigidbody.velocity = Vector2.zero;
        float timer = 0.0f;
        float jumpPercentage;
        Vector3 frameForce;
        while ( _jumpButtonDown && timer < jumpTime ) {
            jumpPercentage = timer / jumpTime;
            frameForce = Vector2.Lerp( Vector2.up * jumpForce, Vector2.zero, jumpPercentage );
            _rigidbody.AddForce( frameForce, ForceMode.VelocityChange );
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _jumping = false;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos() {
        if ( Application.isPlaying ) {
            Gizmos.color = _grounded ? Color.red : Color.green;
            Gizmos.DrawRay( _groundRay );
        }
    }

#endif
}