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

    }
}
