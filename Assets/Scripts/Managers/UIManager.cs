using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
    public Canvas mainMenu;
    public Canvas storeMenu;
    public LoadScene loadScene;

    void Start() {
        loadScene.sceneToLoad = FileManager.instance.currentGameStatusJson.lastLevel;
    }

    public void ShowMainMenu() {
        mainMenu.enabled = true;
        storeMenu.enabled = false;
    }

    public void ShowStoreMenu() {
        mainMenu.enabled = false;
        storeMenu.enabled = true;
    }

}
