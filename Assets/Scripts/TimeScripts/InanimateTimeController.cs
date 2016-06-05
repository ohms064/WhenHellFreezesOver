using UnityEngine;
using System.Collections;
[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : TimeBound {
    private Rigidbody _rigidbody;
    private Vector3 _velocityAtStop, _angularVelocityAtStop;
    private bool _frozen;
    // Use this for initialization
    void Start() {
        this._rigidbody = this.GetComponent<Rigidbody>();
        _frozen = false;
    }

    public override void FrozenRotation() {
        throw new System.NotImplementedException();
    }

    public override void ToggleFreeze() {
        _frozen = !_frozen;
        if ( _frozen ) {
            _velocityAtStop = this._rigidbody.velocity;
            _angularVelocityAtStop = this._rigidbody.angularVelocity;
        }
        this._rigidbody.isKinematic = _frozen;
        if ( !_frozen ) {
            this._rigidbody.velocity = _velocityAtStop;
            this._rigidbody.angularVelocity = _angularVelocityAtStop;
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmo() {
        if ( _frozen ) {
            Gizmos.color = new Color32( 106, 206, 240, 255 );
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
        }
        else {
            print("Mirad"  );
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
        }
    }
#endif

}
