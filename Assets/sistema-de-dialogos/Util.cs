using UnityEngine;
using System;
using System.Collections;

namespace DialogueSystem {
    public class Util {
        public static T FindComponentWithTag<T> (string tag) where T : Behaviour {
            T component = null;
            try {
                component = GameObject.FindWithTag(tag).GetComponent<T>();
            } catch (NullReferenceException) {
                throw new Exception("couldn't find a game objecti with the tag " + tag + ".");
            }

            if (component == null) {
                throw new Exception("there is not that component attached to that game object.");
            }

            return component;
        }

        public static AvatarController FindAvatarController () {
            return FindComponentWithTag<AvatarController>("GameController");
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
