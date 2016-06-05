using UnityEngine;
using System.Collections;

public abstract class TimeBound : MonoBehaviour {
    public abstract void FrozenRotation();
    public abstract void ToggleFreeze();
}
