using UnityEngine;
using System.Collections;

[System.Serializable]
public class FreezeJson {
    public float freezeTime;

    public FreezeJson() { }

    public FreezeJson(float freezeTime ) {
        this.freezeTime = freezeTime;
    }
}
