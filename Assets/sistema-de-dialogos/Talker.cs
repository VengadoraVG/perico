using UnityEngine;
using System.Collections;

public class Talker : MonoBehaviour {
    public TextAsset[] rawDialogue;
    public int current;
    public TextDisplayer text;

    public ProximityDetector proximityDetector;
    public bool canTalk = false;
    public bool isTalking = false;
    public GameObject canTalkIndicator;

    private Dialogue[] _dialogue;

    void Start () {
        _DigestDialogue();

        for (int i=0; i<_dialogue.Length; i++) {
            _dialogue[i].Reset();
        }
    }

    void Update () {
        canTalkIndicator.SetActive(canTalk);
    }

    private void _DigestDialogue () {
        _dialogue = new Dialogue[rawDialogue.Length];

        for (int i=0; i<rawDialogue.Length; i++) {
            _dialogue[i] = JsonUtility.FromJson<Dialogue>(rawDialogue[i].text);
        }
    }

    public void Talk () {
        if (IsDoneTalking()) {
            StopTalking();
        } else {
            KeepTalking();
        }
    }

    public void KeepTalking () {
        isTalking = true;
        _dialogue[current].Next();
        text.DisplayText(_dialogue[current].CurrentStatement.message);
    }

    public void StopTalking () {
        isTalking = false;
        text.Hide();
        _dialogue[current].Cancel();
    }

    public bool IsDoneTalking () {
        return !_dialogue[current].HasNext();
    }
}
