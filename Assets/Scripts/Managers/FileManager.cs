using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class FileManager : MonoBehaviour {

    [HideInInspector] public static FileManager instance;
    public string frozenJsonFileName;
    [SerializeField]
    public FreezeJson frozenDefaultJson;

    // Use this for initialization
    void Start () {
        instance = this;
        DontDestroyOnLoad( this.gameObject );
	}

    public FreezeJson LoadFrozenJson() {
        if ( !File.Exists( frozenJsonFileName )) return frozenDefaultJson;
        StreamReader sr = new StreamReader( frozenJsonFileName );
        string fileString = sr.ReadToEnd();
        return JsonUtility.FromJson<FreezeJson>( fileString );
    }

    void SaveFrozenJson( FreezeJson frozenJson) {
        StreamWriter sw = new StreamWriter( frozenJsonFileName );
        sw.Write( JsonUtility.ToJson( frozenJson ) );
    }
	
	
}
