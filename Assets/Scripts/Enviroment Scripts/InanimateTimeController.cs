using UnityEngine;
using System.Collections;
using System;

[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : MonoBehaviour, IFreezable {
    private Rigidbody _rigidbody;
    private Vector3 _velocityAtStop, _angularVelocityAtStop;
    private PhysicMaterial _phsxMat;
    // Use this for initialization
    void Start() {
        this._rigidbody = this.GetComponent<Rigidbody>();
        _phsxMat = this.GetComponent<Collider>().material;
    }

    public void FrozenRotation(Vector3 rotation) {
        this.transform.LookAt( rotation );
    }

    public void Freeze() {
        _velocityAtStop = this._rigidbody.velocity;
        _angularVelocityAtStop = this._rigidbody.angularVelocity;
        _phsxMat.dynamicFriction = 0.0f; //Para que el personaje no se pegue a el.
        _phsxMat.staticFriction = 0.0f;
        this._rigidbody.isKinematic = true;
    }

    public void Unfreeze() {
        this._rigidbody.isKinematic = false;
        this._rigidbody.velocity = _velocityAtStop;
        this._rigidbody.angularVelocity = _angularVelocityAtStop;
        _phsxMat.dynamicFriction = 1.0f;
        _phsxMat.staticFriction = 1.0f;
    }

#if UNITY_EDITOR
    void OnDrawGizmos() {
        if ( TimeManager.frozen ) {
            Gizmos.color = new Color32( 106, 206, 240, 255 );
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
        }
        else {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere( this.transform.position, 1.0f );
        }
    }

    
#endif

}
