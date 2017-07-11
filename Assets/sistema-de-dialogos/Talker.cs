using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talker : MonoBehaviour {
    public List<Dialogue> dialogue;
    public int current;
    public TextDisplayer text;

    public ProximityDetector proximityDetector;
    public bool canTalk = false;
    public bool isTalking = false;
    public GameObject canTalkIndicator;

    void Start () {
        for (int i=0; i<dialogue.Count; i++) {
            dialogue[i].Reset();
        }
    }

    void Update () {
        canTalkIndicator.SetActive(canTalk);
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
        dialogue[current].Next();
        text.DisplayText(dialogue[current].CurrentStatement);
    }

    public void StopTalking () {
        isTalking = false;
        text.Hide();
        dialogue[current].Cancel();
    }

    public bool IsDoneTalking () {
        return !dialogue[current].HasNext();
    }
}
