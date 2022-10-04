using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBridge : MonoBehaviour
{
    public MeshRenderer mesh; // the visible mesh of the gameobject
    public PushableBlock blockOne, blockTwo; // my 2 trigger blocks to show my mesh
    // Start is called before the first frame update
    void Start()
    {
        mesh.enabled = false; // hide the mesh
        GetComponent<BoxCollider>().enabled = false; // disable colliders
    }

    // Update is called once per frame
    void Update()
    {
        if(blockOne.onPad == true && blockTwo.onPad == true)
        {
            mesh.enabled = true; // show the bridge
            GetComponent<BoxCollider>().enabled = true; // enable the colliders
        }
    }
}
