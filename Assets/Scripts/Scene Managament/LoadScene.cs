using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public Scenes sceneToLoad;
    public float waitTime;
    public Scenes sceneToSave;
    public bool saveOnLoad;

    void OnTriggerEnter(Collider col) {
        InvokeScene();
    }

    public void SceneLoad() {
        SceneManager.LoadScene( (int)sceneToLoad );
        if ( saveOnLoad ) {
            FileManager files = FileManager.instance;
            files.currentGameStatusJson.lastLevel = sceneToSave;
            files.SaveGameStatusJson();
        }
    }

    public void InvokeScene() {
        Invoke( "SceneLoad", waitTime );
    }

}
