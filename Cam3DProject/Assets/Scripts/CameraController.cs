using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float verticalSpeed; // look speed up and down
    public float xRotation; // axis to rotate around
    public GameObject player; // so we can have access to some player stuff
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Player>().inputSwitch == false && Input.GetKey(KeyCode.Tab)) // mouse and keyboard
        {
            float mouseY = Input.GetAxis("Mouse Y"); // get the y axis
            xRotation = mouseY * verticalSpeed * Time.deltaTime; // new x rotation
            Vector3 cameraRotation = transform.rotation.eulerAngles;
            cameraRotation.x -= xRotation; // set the x rotation
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
        if(player.GetComponent<Player>().inputSwitch == true) // controller input rotation
        {
            float stickY = Input.GetAxis("RightStick Y"); // get the y axis
            xRotation = stickY * verticalSpeed * Time.deltaTime; // new xrotation
            Vector3 cameraRotation = transform.rotation.eulerAngles;
            cameraRotation.x += xRotation;
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
        // lerp the rotation back as an else
        // account for rotation with controller
    }
}
