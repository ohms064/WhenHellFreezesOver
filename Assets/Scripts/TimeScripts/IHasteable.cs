using UnityEngine;
using System.Collections;

public interface IHasteable {
    void Haste();
    void Unhaste();
    IEnumerator HasteMode();
}
