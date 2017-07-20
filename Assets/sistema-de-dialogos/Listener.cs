using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DialogueSystem {
    public class Listener : MonoBehaviour {
        public ProximityDetector talkerDetector;
        public Displayer uniqueTextDisplayer;
        public Talker activeTalker;

        private PlayerControl _movement;

        void Start () {
            talkerDetector.OnEnterDetection += FoundTalker;
            talkerDetector.OnExitDetection += LostTalker;
            _movement = GetComponent<PlayerControl>();
        }

        void Update () {
            if (activeTalker != null && Input.GetKeyDown(KeyCode.Space)) {
                activeTalker.Talk();
                _movement.isControlled = !activeTalker.isTalking;
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
}
