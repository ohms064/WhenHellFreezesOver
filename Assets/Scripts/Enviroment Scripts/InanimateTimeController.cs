using UnityEngine;
using System.Collections;
using System;

[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : MonoBehaviour, IFreezable {
    private Rigidbody _rigidbody;
    private Vector3 _directionAtStop, _angularVelocityAtStop;
    private float _speedAtStop;
    private PhysicMaterial _phsxMat;
    private float _forceUpAngle;

    // Use this for initialization
    void Start() {
        this._rigidbody = this.GetComponent<Rigidbody>();
        _phsxMat = this.GetComponent<Collider>().material;
    }

    public void FrozenRotation(float rotation) {
        this.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, rotation );
        Quaternion quat = Quaternion.AngleAxis( _forceUpAngle, this.transform.forward );
        _directionAtStop = quat * this.transform.up;
    }

    public void Freeze() {
        _directionAtStop = this._rigidbody.velocity;
        _speedAtStop = _directionAtStop.magnitude;
        _directionAtStop /= _speedAtStop;
        _angularVelocityAtStop = this._rigidbody.angularVelocity;
        _forceUpAngle = Vector3.Angle(this.transform.up, _directionAtStop);
        _phsxMat.dynamicFriction = 0.0f; //Para que el personaje no se pegue a el.
        _phsxMat.staticFriction = 0.0f;
        this._rigidbody.isKinematic = true;
    }

    public void Unfreeze() {
        this._rigidbody.isKinematic = false;
        this._rigidbody.AddForce( _directionAtStop * _speedAtStop, ForceMode.VelocityChange );
        this._rigidbody.AddTorque( _angularVelocityAtStop, ForceMode.VelocityChange );
        _phsxMat.dynamicFriction = 1.0f;
        _phsxMat.staticFriction = 1.0f;
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        if ( TimeManager.isFrozen ) {
            Gizmos.color = new Color32( 106, 206, 240, 255 );
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
            Gizmos.color = Color.blue;
            Gizmos.DrawLine( this.transform.position, this.transform.position + _directionAtStop );
        }
        else {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
        }
    }

    
#endif

}
