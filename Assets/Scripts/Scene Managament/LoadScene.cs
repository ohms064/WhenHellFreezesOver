using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public Scenes sceneToLoad;
    public float waitTime;
    public Scenes sceneToSave;
    public bool saveOnLoad;

    [HideInInspector]
    public static Scenes currentScene = Scenes.MAIN_MENU;

    void OnTriggerEnter(Collider col) {
        InvokeScene();
    }

    public void SceneLoad() {
        SceneManager.LoadScene( (int)sceneToLoad );
        currentScene = sceneToLoad;
        if ( saveOnLoad ) {
            FileManager files = FileManager.instance;
            files.currentGameStatusJson.lastLevel = sceneToSave;
            files.SaveGameStatusJson();
        }
    }

    public void InvokeScene() {
        Invoke( "SceneLoad", waitTime );
    }

    public static void ReloadScene() {
        SceneManager.LoadScene( (int)currentScene );
    }

    public static void Load(Scenes scene ) {
        SceneManager.LoadScene( (int)scene );
    }

}
