using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // the destinations for our thing
    [SerializeField] public Vector3 startPoint;
    [SerializeField] public Vector3 endPoint;
    [SerializeField] public Vector3 moveDirection; // where the platform should move to
    [SerializeField] public float distance; // how far it is from the desired point
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = endPoint; // make the platform move towards the end point to start
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, 2 * Time.deltaTime); // move the platform
        distance = Vector3.Distance(transform.position, moveDirection); // how far the platform is from its target
        if(distance <= 1)
        {
            if(moveDirection == startPoint) // if the platform reached the start point
            {
                moveDirection = endPoint; // switch to end point
            }
            else if(moveDirection == endPoint)
            {
                moveDirection = startPoint;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.transform.SetParent(transform); // anchor or make the platform the parent of the player so player moves with the platform
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.transform.SetParent(null); // unparent the player from the platform
        }
    }
}
