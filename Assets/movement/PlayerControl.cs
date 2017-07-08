using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed = 10;
    public float torque = 360;

    void Update () {
        transform.position += (transform.forward * Input.GetAxisRaw("Vertical") +
                               transform.right * Input.GetAxisRaw("Horizontal")) * Time.deltaTime * speed;

        transform.Rotate(0,Input.GetAxisRaw("Mouse X") * Time.deltaTime * torque, 0);
    }
}
