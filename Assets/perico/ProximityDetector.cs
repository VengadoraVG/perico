using UnityEngine;
using System.Collections;

namespace Perico {
    public class ProximityDetector : MonoBehaviour {
        public bool triggered = false;

        public delegate void EnterDetection (GameObject detected);
        public EnterDetection OnEnterDetection;

        public delegate void ExitDetection (GameObject detected);
        public EnterDetection OnExitDetection;

        void OnTriggerEnter (Collider c) {
            triggered = true;

            if (OnEnterDetection != null) {
                OnEnterDetection(c.gameObject);
            }
        }

        void OnTriggerExit (Collider c) {
            triggered = false;

            if (OnExitDetection != null) {
                OnExitDetection(c.gameObject);
            }
        }
    }
}
