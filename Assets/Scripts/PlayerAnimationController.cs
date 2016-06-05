using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {
    private Animator _animator;
    private float _movimiento;
    // Use this for initialization
    void Start() {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        _movimiento = Input.GetAxis( "Horizontal" );
        if ( _movimiento != 0 && !_animator.GetBool( "Running" ) ) { StartCoroutine( "Run" ); }
    }

    IEnumerator Run() {
        _animator.SetBool( "Running", true );

        do {
            this.transform.position += new Vector3( _movimiento * Time.deltaTime, 0.0f, 0.0f );
            yield return new WaitForEndOfFrame();
        }
        while ( _movimiento != 0.0f );
        _animator.SetBool( "Running", false );
    }
}
