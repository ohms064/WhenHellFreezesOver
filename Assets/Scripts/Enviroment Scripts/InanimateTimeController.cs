using UnityEngine;
using System.Collections;
using System;

[RequireComponent((typeof(Rigidbody)))]
public class InanimateTimeController : MonoBehaviour, IFreezable {
    private Rigidbody _rigidbody;
    private Vector3 _directionAtStop, _angularVelocityAtStop;
    private float _speedAtStop;
    //private PhysicMaterial _phsxMat;
    private float _forceUpAngle;
    [HideInInspector] public bool isHarmful = false;
    private float damage;

    private Color originalColor;

    // Use this for initialization
    void Start() {
        this._rigidbody = this.GetComponent<Rigidbody>();
        originalColor = this.GetComponent<Renderer>().material.color;
        //_phsxMat = this.GetComponent<Collider>().material;
    }

    public void FrozenRotation(float rotation) {
        this.transform.localEulerAngles = new Vector3( 0.0f, 0.0f, rotation );
        Quaternion quat = Quaternion.AngleAxis( _forceUpAngle, this.transform.forward );
        _directionAtStop = quat * this.transform.up;
    }

    public void Freeze() {
        if (isHarmful) {
            isHarmful = false;
            StopCoroutine("ActiveDamage");
        }
        _directionAtStop = this._rigidbody.velocity;
        _speedAtStop = _directionAtStop.magnitude;
        if (Mathf.Abs(_speedAtStop) > 0.0f) {
            _directionAtStop /= _speedAtStop;
        }
        _angularVelocityAtStop = this._rigidbody.angularVelocity;
        _forceUpAngle = Vector3.Angle(this.transform.up, _directionAtStop);
        //_phsxMat.dynamicFriction = 0.0f; //Para que el personaje no se pegue a el.
        //_phsxMat.staticFriction = 0.0f;
        this._rigidbody.isKinematic = true;
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    public void Unfreeze() {
        this._rigidbody.isKinematic = false;
        if ( Mathf.Abs(_speedAtStop) > 0.0f) {
            this._rigidbody.AddForce( _directionAtStop * _speedAtStop, ForceMode.VelocityChange );
            this._rigidbody.AddTorque( _angularVelocityAtStop, ForceMode.VelocityChange );
        }
        
        if (Mathf.Abs(_speedAtStop) > 0.5f) {
            StartCoroutine("ActiveDamage");
        }
        else {
            GetComponent<Renderer>().material.color = originalColor;
        }
        //_phsxMat.dynamicFriction = 1.0f;
        //_phsxMat.staticFriction = 1.0f;
    }

    void OnCollisionEnter(Collision coll) {
        if (coll.transform.CompareTag("Enviroment")) {
            isHarmful = false;
        }
    }

    IEnumerator ActiveDamage() {
        isHarmful = true;
        Renderer ren = GetComponent<Renderer>();
        ren.material.color = Color.red;
        damage = PlayerManager.enviroment.objectsDamage;
        while(damage > 0.0f || isHarmful) {
            yield return new WaitForFixedUpdate();
            damage = Mathf.InverseLerp(0.0f, _speedAtStop, _rigidbody.velocity.magnitude);
        }
        ren.material.color = originalColor;
        isHarmful = false;

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
