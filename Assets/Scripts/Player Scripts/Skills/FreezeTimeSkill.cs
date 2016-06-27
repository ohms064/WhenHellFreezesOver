using UnityEngine;
using System.Collections;

public class  FreezeTimeSkill : Skill  {
    public override void Activate() {
        TimeManager.FreezeScene(true);
    }
    public override void Deactivate() {
        TimeManager.FreezeScene(false);
    }
    public override void Start() {
        Debug.Log( "Not available" );
    }
}
