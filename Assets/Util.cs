using UnityEngine;
using System.Collections;

public class Util {
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
