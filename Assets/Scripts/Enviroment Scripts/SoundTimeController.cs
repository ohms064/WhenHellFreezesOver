using UnityEngine;
using System.Collections;
using System;

public class SoundTimeController : MonoBehaviour, IFreezable {
    private AudioSource _source;

    // Use this for initialization
    void Start() {
        _source = GetComponent<AudioSource>();
    }

    public void Freeze() {
        _source.Stop();
    }

    public void FrozenRotation( float rotation ) {
        return;
    }

    public void Unfreeze() {
        _source.Play();
    }

}
