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
        if(player.GetComponent<Player>().inputSwitch == false && Input.GetKey(KeyCode.Tab))
        {
            float mouseY = Input.GetAxis("Mouse Y"); // get the y axis
            xRotation = mouseY * verticalSpeed * Time.deltaTime; // new x rotation
            Vector3 cameraRotation = transform.rotation.eulerAngles;
            cameraRotation.x -= xRotation; // set the x rotation
            transform.rotation = Quaternion.Euler(cameraRotation);
        }
    }
}
