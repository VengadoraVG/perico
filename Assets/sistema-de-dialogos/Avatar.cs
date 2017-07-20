using UnityEngine;
using System;
using System.Collections;

namespace DialogueSystem {
    public class Avatar : MonoBehaviour {
        public string key;
        public string displayName;

        public GameObject cameraPosition;

        private AvatarController _controller;

        void Start () {
            _controller = DialogueSystem.Util.FindAvatarController();
            _controller.Register(this);
        }

        public void GetFocused (GameObject avatarCamera) {
            avatarCamera.transform.position = cameraPosition.transform.position;
            avatarCamera.transform.rotation = cameraPosition.transform.rotation;
        }
    }
}
