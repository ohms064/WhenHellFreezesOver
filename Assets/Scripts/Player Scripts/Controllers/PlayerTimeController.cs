using UnityEngine;
using System.Collections;

public class PlayerTimeController : MonoBehaviour {
    private TimeMaster spells;
    private FreezeJson freezeData;
    public ProgressBar frozenBar;

	// Use this for initialization
	void Start () {
        spells = new TimeMaster( new FreezeTimeSkill(), new Skill(), new Skill(), new Skill() );
	}
	
	// Update is called once per frame
	void Update () {
        if ( PlayerManager.enviroment.grabStatus != GrabStatus.HANDS_FREE )
            return;
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) ) {
            if (TimeManager.isFrozen) {
                spells.Freeze.Deactivate();
                StopCoroutine("FreezeDuration");
            }
            else {
                spells.Freeze.Activate();
                StartCoroutine("FreezeDuration");
            }
	    }
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) ) {
            spells.Haste.Activate();
        }
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) ) {
            spells.Slow.Activate();
        }
        if ( Input.GetKeyDown( KeyCode.Alpha4 ) ) {
            spells.Rewind.Start();
        }
    }

    IEnumerator FreezeDuration() {
        float initTime = Time.time;
        while (Time.time - initTime < 5.0f) {
            yield return new WaitForEndOfFrame();
            frozenBar.SetPercentage(Mathf.InverseLerp(5.0f, 0.0f, Time.time - initTime));
        }
        if (TimeManager.isFrozen) {
            spells.Freeze.Deactivate();
        }
    }
}
