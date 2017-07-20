using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Perico {
    public class AvatarController : MonoBehaviour {
        public Dictionary<string, Avatar> avatar = new Dictionary<string, Avatar>();
        public GameObject avatarCamera;

        public void Display (Statement statement) {
            avatar[statement.key].GetFocused(avatarCamera, statement);
        }

        public void Register (Avatar avatar) {
            this.avatar[avatar.key] = avatar;
        }

        public string GetName (Statement statement) {
            if (avatar.ContainsKey(statement.key)) {
                return avatar[statement.key].displayName;
            }

            return "";
        }
    }
}
