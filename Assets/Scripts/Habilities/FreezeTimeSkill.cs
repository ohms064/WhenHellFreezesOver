using UnityEngine;
using System.Collections;

public class  FreezeTimeSkill : Skill  {
    public override void Activate() {
        TimeManager.FreezeScene();
    }
    public override void Deactivate() {
        TimeManager.FreezeScene();
    }
    public override void Start() {
        Debug.Log( "Not available" );
    }
}
