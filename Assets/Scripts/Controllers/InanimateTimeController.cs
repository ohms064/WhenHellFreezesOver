using UnityEngine;
using System.Collections;
using System;

[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : MonoBehaviour, IFreezable {
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

    public void Unfreeze() {
        this._rigidbody.isKinematic = false;
        _rigidbody.AddForce(_velocityAtStop, ForceMode.VelocityChange);
        _rigidbody.AddTorque(_angularVelocityAtStop, ForceMode.VelocityChange);
    }

    public void Freeze() {
        _velocityAtStop = this._rigidbody.velocity;
        _angularVelocityAtStop = this._rigidbody.angularVelocity;
        this._rigidbody.isKinematic = true;
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
