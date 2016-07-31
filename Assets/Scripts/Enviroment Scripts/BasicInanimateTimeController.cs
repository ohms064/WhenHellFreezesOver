using UnityEngine;
using System.Collections;
using System;

public class BasicInanimateTimeController : MonoBehaviour, IFreezable {

    private Rigidbody _rigidbody;
    private Vector3 _torqueAtStop;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Freeze() {
        _torqueAtStop = _rigidbody.angularVelocity;
        _rigidbody.isKinematic = true;
    }

    public void FrozenRotation( float rotation ) {
        Debug.Log( "Not available" );
    }

    public void Unfreeze() {
        _rigidbody.AddTorque( _torqueAtStop, ForceMode.VelocityChange );
        _rigidbody.isKinematic = false;
    }
}
