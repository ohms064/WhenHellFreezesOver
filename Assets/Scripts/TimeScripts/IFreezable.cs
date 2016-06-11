using UnityEngine;
using System.Collections;

public interface IFreezable {
    void FrozenRotation();
    void ToggleFreeze();
    void Freeze( bool state );
}
