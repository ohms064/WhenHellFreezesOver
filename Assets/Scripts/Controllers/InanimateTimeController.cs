using UnityEngine;
using System.Collections;
using System;

[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : MonoBehaviour, IFreezable, IHasteable {
    private Rigidbody _rigidbody;
    private Vector3 _velocityAtStop, _angularVelocityAtStop;
    private bool _frozen;
    // Use this for initialization
    void Start() {
        this._rigidbody = this.GetComponent<Rigidbody>();
        _frozen = false;
    }

    public void FrozenRotation() {
        throw new System.NotImplementedException();
    }

    public void ToggleFreeze() {
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

    public void Freeze( bool state ) {
        _frozen = state;
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

    public void Haste() {
        throw new NotImplementedException();
    }

    public void Unhaste() {
        throw new NotImplementedException();
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
