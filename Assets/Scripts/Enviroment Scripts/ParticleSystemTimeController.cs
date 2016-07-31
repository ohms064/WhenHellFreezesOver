using UnityEngine;
using System.Collections;
using System;

public class ParticleSystemTimeController : MonoBehaviour, IFreezable {

    private ParticleSystem _particles;
    private ParticleSystem.EmissionModule _emission;

    // Use this for initialization
    void Start() {
        _particles = GetComponent<ParticleSystem>();
        _emission = _particles.emission;
        _particles.Play();
    }

    void Update() {
        print(_emission.enabled);
    }

    public void Freeze() {
        _particles.Pause( true );
    }

    public void FrozenRotation( float rotation ) {
        return;
    }

    public void Unfreeze() {
        _particles.Play( true );        
    }


}
