using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talker : MonoBehaviour {
    public List<string> dialogues;
    public int current;
    public TextDisplayer text;

    public ProximityDetector proximityDetector;
    public bool canTalk = false;
    public bool isTalking = false;
    public GameObject canTalkIndicator;

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
        text.DisplayText(dialogues[current]);
    }

    public void StopTalking () {
        isTalking = false;
        text.Hide();
    }

    public bool IsDoneTalking () {
        return isTalking;
    }
}
