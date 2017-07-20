using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DialogueSystem {
    public class Displayer : MonoBehaviour {
        public GameObject dialogueBox;
        public GameObject messageBox;
        public GameObject nameBox;

        private Text _uiMessage;
        private Text _uiName;
        private AvatarController _avatarController;

        void Start () {
            _avatarController = DialogueSystem.Util.FindAvatarController();
            _uiMessage = messageBox.GetComponent<Text>();
            _uiName = nameBox.GetComponent<Text>();
            Hide();
        }

        public void Display (Statement statement) {
            if (_uiMessage != null) {
                _uiMessage.text = statement.message;
            }

            if (_uiName != null) {
                _uiName.text = _avatarController.GetName(statement);
            }

            _avatarController.Display(statement);
            Show();
        }

        public void Show () {
            dialogueBox.SetActive(true);
        }

        public void Hide () {
            dialogueBox.SetActive(false);
        }
    }
}
