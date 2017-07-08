using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Listener : MonoBehaviour {
    public ProximityDetector talkerDetector;
    public TextDisplayer uniqueTextDisplayer;
    public Talker activeTalker;

    void Start () {
        talkerDetector.OnEnterDetection += FoundTalker;
        talkerDetector.OnExitDetection += LostTalker;
    }

    void Update () {
        if (activeTalker != null && Input.GetKeyDown(KeyCode.Space)) {
            activeTalker.Talk();
        }
    }

    public void FoundTalker (GameObject talker) {
        if (activeTalker == null) {
            activeTalker = Util.FindParentWithTag(talker.transform, "controller").GetComponent<Talker>();
            activeTalker.canTalk = true;

            if (uniqueTextDisplayer != null) {
                activeTalker.text = uniqueTextDisplayer;
            }
        }
    }

    public void LostTalker (GameObject talker) {
        if (activeTalker == Util.FindParentWithTag(talker.transform, "controller").GetComponent<Talker>()) {
            activeTalker.canTalk = false;
            activeTalker.StopTalking();
            activeTalker = null;
        }
    }
}
