using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    public static Camera mainCamera;
    [SerializeField]private Camera _camera;
	// Use this for initialization
	void Start () {
	    mainCamera = _camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
