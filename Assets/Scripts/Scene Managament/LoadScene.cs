using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    Scenes sceneToLoad;
    public float waitTime;

    void OnTriggerEnter(Collider col) {
        Invoke( "SceneLoad", waitTime );
    }

    private void SceneLoad() {
        SceneManager.LoadScene( (int)sceneToLoad );
    }

}
