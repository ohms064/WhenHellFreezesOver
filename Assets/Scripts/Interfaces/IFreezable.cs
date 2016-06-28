using UnityEngine;
using System.Collections;

public interface IFreezable {
    void FrozenRotation(Vector3 rotation);
    void Freeze();
    void Unfreeze();
}
