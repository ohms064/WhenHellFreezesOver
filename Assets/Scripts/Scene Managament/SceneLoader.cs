using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public SceneLoader instance;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad( this.gameObject );
        instance = this;
    }

    public void loadMainMenu() {
        SceneManager.LoadScene( (int)Scenes.MAIN_MENU );
    }

    public void loadFirstLevel() {
        SceneManager.LoadScene( (int)Scenes.FIRST_LEVEL );
    }

    public void loadTestLevel() {
        SceneManager.LoadScene( (int)Scenes.TEST_LEVEL );
    }
}
