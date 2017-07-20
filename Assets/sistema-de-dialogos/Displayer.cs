using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DialogueSystem {
    public class Displayer : MonoBehaviour {
        public GameObject dialogueBox;
        public GameObject displayer;

        private Text _ui;
        private AvatarController _avatarController;

        void Start () {
            _avatarController = DialogueSystem.Util.FindAvatarController();
            _ui = displayer.GetComponent<Text>();
            Hide();
        }

        public void Display (Statement statement) {
            if (_ui != null) {
                _ui.text = statement.message;
            }

            _avatarController.Display(statement.key);
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
