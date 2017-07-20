using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Perico {
    public class Listener : MonoBehaviour {
        public ProximityDetector talkerDetector;
        public Talker activeTalker;
        public List<Talker> inRangeTalker;

        private PlayerControl _movement;

        void Start () {
            talkerDetector.OnEnterDetection += FoundTalker;
            talkerDetector.OnExitDetection += LostTalker;
            _movement = GetComponent<PlayerControl>();
        }

        void Update () {
            // dangerous piece of code. Can get executed a lot of times.
            if (inRangeTalker.Count > 0) {
                float minAngle = Mathf.Infinity;
                int minIndex = 0;

                for (int i=0; i<inRangeTalker.Count; i++) {
                    float angle = Vector3.Angle(transform.forward, transform.position - inRangeTalker[i].transform.position);
                    if (angle < minAngle) {
                        angle = minAngle;
                        minIndex = i;
                    }
                }

                SetActiveTalker(inRangeTalker[minIndex]);
            }

            if (activeTalker != null && Input.GetKeyDown(KeyCode.Space)) {
                activeTalker.Talk();
                _movement.isControlled = !activeTalker.isTalking;
            }
        }

        public void UnsetAsActiveTalker (Talker talker) {
            talker.canTalk = false;
            talker.StopTalking();
        }
        
        public void SetActiveTalker (Talker talker) {
            if (activeTalker != null && activeTalker != talker) {
                UnsetAsActiveTalker(activeTalker);
            }

            activeTalker = talker;
            activeTalker.canTalk = true;
        }

        public void FoundTalker (GameObject talker) {
            inRangeTalker.Add(Util.FindParentWithTag(talker.transform, "controller").GetComponent<Talker>());
        }

        public void LostTalker (GameObject talker) {
            Talker t = Util.FindParentWithTag(talker.transform, "controller").GetComponent<Talker>();
            UnsetAsActiveTalker(t);
            inRangeTalker.Remove(t);
        }
    }
}
