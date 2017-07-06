using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Talker : MonoBehaviour {
    public List<string> dialogues;
    public int current;
    public TextDisplayer text;

    public bool isTalking = false;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isTalking) {
                Talk();
            } else {
                StopTalking();
            }
        } 
    }

    public void Talk () {
        isTalking = true;
        text.DisplayText(dialogues[current]);
    }

    public void StopTalking () {
        isTalking = false;
        text.Hide();
    }
}
