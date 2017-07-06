using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextDisplayer : MonoBehaviour {
    public GameObject displayer;

    private TextMesh _mesh;
    private Text _ui;

    void Start () {
        _mesh = displayer.GetComponent<TextMesh>();
        _ui = displayer.GetComponent<Text>();
        Hide();
    }

    public void DisplayText (string text) {
        if (_mesh != null) {
            _mesh.text = text;
        }

        if (_ui != null) {
            _ui.text = text;
        }

        Show();
    }

    public void Show () {
        displayer.SetActive(true);
    }

    public void Hide () {
        displayer.SetActive(false);
    }
}
