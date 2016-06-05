using UnityEngine;
using System.Collections;

public interface ITimeMaster {
    void FreezeTime();
    void SlowTime();
    void HasteTime();
    void RewindTime();
}
