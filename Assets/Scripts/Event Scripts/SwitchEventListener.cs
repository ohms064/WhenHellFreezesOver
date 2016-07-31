using UnityEngine;
using System.Collections;

public abstract class SwitchEventListener : MonoBehaviour {

    public abstract void onActivated(Switch fromWho);
    public abstract void OnDeactivated( Switch fromWho );
}
