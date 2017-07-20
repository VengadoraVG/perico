using UnityEngine;
using System;
using System.Collections;

namespace DialogueSystem {
    public class Util {
        public static AvatarController FindAvatarController () {
            AvatarController controller = null;

            try {
                controller = GameObject.FindWithTag("GameController")
                    .GetComponent<AvatarController>();
            } catch (NullReferenceException) {
                throw new Exception("couldn't find a game object with the tag GameController.");
            }

            if (controller == null) {
                throw new Exception("couldn't find GameController with AvatarController");
            }

            return controller;
        }

        public static GameObject FindParentWithTag (Transform t, string tag) {
            while (t.parent != null) {
                if (t.parent.gameObject.CompareTag(tag)) {
                    return t.parent.gameObject;
                }

                t = t.parent;
            }

            return null;
        }

        // BFS
        public static T FindComponentOnChildren<T> (Transform t) where T : Behaviour {
            T found = null;

            for (int i=0; i<t.childCount; i++) {
                found = t.GetChild(i).gameObject.GetComponent<T>();
                if (found != null) {
                    return found;
                }
            }

            for (int i=0; i<t.childCount; i++) {
                found = FindComponentOnChildren<T>(t.GetChild(i));
                if (found != null) {
                    return found;
                }
            }

            return found;
        }

    }
}
