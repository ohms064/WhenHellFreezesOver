using UnityEngine;
using System.Collections;

public interface IFreezable {
    void FrozenRotation( float rotation );
    void Freeze();
    void Unfreeze();
}
