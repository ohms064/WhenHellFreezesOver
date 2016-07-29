using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour {

    [SerializeField] private Text  _textPercentage;
    [SerializeField] private Image _progressBar;
    private Material _progressMaterial { get { return _progressBar.material; } }

#if UNITY_EDITOR
    [SerializeField] private Color _progressColor;
    [Range( 0.0f, 1.0f )] public float initialPercentage = 0.5f;
    [Range( 0.0f, 1.0f )] public float initialInnerSize = 0.5f;

    void Update () { //Called only when chaged.
        if (_textPercentage == null || _progressBar == null || _progressMaterial == null || Application.isPlaying)
            return;
        _progressMaterial.SetFloat( "_TransVal", initialInnerSize );
        _progressMaterial.SetColor( "_Color2", _progressColor );
        SetPercentage( initialPercentage );
    }
#endif

    public void SetPercentage(float percentage) {
        percentage = Mathf.Clamp( percentage, 0.0f, 1.0f );
        _progressMaterial.SetFloat( "_ProgressionVal", percentage );
        _textPercentage.text = string.Format("{0} %", (int)(percentage * 100));
        Debug.Log( _progressMaterial.GetFloat( "_ProgressionVal" ) );
    }
}
