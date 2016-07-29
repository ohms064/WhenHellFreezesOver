using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
//Uses enum grounded state
public class EnemyController : MonoBehaviour {
    private Rigidbody _rigidbody;
    public GroundedState groundedState;
    public bool isJumping;
    public float jumpTime;
	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();        
	}
	
	public void Move(float delta) {
        _rigidbody.MovePosition( _rigidbody.position + (Vector3.right * delta * Time.deltaTime) );
    }

    public void Jump(float delta ) {
        switch ( groundedState ) {
            case GroundedState.GROUNDED:
                StartCoroutine( "JumpCorotine" );
                break;
        }
    }

    private IEnumerator JumpCoroutine( float force ) {
        _rigidbody.velocity = Vector2.zero;
        float timer = 0.0f;
        float jumpPercentage;
        Vector3 frameForce;
        while ( timer < jumpTime ) {
            jumpPercentage = timer / jumpTime;
            frameForce = Vector2.Lerp( Vector2.up * force, Vector2.zero, jumpPercentage );
            _rigidbody.AddForce( frameForce, ForceMode.VelocityChange );
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        isJumping = false;
    }
}
