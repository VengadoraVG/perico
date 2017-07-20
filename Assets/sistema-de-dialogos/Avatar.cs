using UnityEngine;
using System.Collections;

namespace DialogueSystem {
    public class Avatar : MonoBehaviour {
        public string key;
        public string displayName;

        public GameObject cameraPosition;
        public AudioClip[] voice;

        public Vector2 spaceBetweenPhonemas = new Vector2(0.1f, 0.05f);
        public float lettersBySecond = 15;

        public GameObject model;

        private AvatarController _controller;
        private AudioSource _speaker;
        public Animator _animator;

        void Start () {
            _controller = DialogueSystem.Util.FindAvatarController();
            _controller.Register(this);
            _speaker = GetComponent<AudioSource>();
            _animator = Util.FindComponentOnChildren<Animator>(this.transform);
        }

        public void GetFocused (GameObject avatarCamera, Statement statement) {
            avatarCamera.transform.position = cameraPosition.transform.position;
            avatarCamera.transform.rotation = cameraPosition.transform.rotation;

            if (voice.Length > 0) {
                StopAllCoroutines();
                StartCoroutine(PlayVoice(statement.message));
            }

            if (_animator != null) {
                _animator.SetTrigger(statement.emotion);
            }
        }

        IEnumerator PlayVoice (string message) {
            float startingTime = Time.time;
            float elapsedTime = 0;
            float estimatedDuration = message.Length / lettersBySecond;

            do {
                AudioClip choosen = voice[Random.Range(0, voice.Length)];

                elapsedTime = Time.time - startingTime;
                _speaker.PlayOneShot(choosen);
                yield return new WaitForSeconds(choosen.length +
                                                Random.Range(spaceBetweenPhonemas.x, spaceBetweenPhonemas.y));

            } while (elapsedTime < estimatedDuration);

            if (_animator != null) {
                _animator.SetTrigger("stop");
            }
        }
    }
}
