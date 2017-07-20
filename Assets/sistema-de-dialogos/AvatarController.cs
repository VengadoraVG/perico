using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DialogueSystem {
    public class AvatarController : MonoBehaviour {
        public Dictionary<string, Avatar> avatar = new Dictionary<string, Avatar>();
        public GameObject avatarCamera;

        public void Display (Statement statement) {
            avatar[statement.key].GetFocused(avatarCamera, statement);
        }

        public void Register (Avatar avatar) {
            this.avatar[avatar.key] = avatar;
        }
    }
}
