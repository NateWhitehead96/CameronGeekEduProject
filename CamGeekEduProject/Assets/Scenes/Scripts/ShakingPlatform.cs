using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingPlatform : MonoBehaviour
{

    public float shakeDuration = 1; // how long it will shake
    public float shakeMagnitude = 0.1f; // how strong the shake is
    public float damping = 1; // how fast we slow down the shaking
    public Vector3 initialPosition;
    public float fallTime = 5; // how long it falls for

    public bool falling; // is it falling or not
    //public float StartX;
    //public float StartY;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0 && falling) // shaking part
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * damping;
        }
        else if(shakeDuration <= 0 && falling) // falling part
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime);
            fallTime -= Time.deltaTime;
        }

        if(fallTime <= 0 && falling) // reset the platform to its original position
        {
            falling = false;
            shakeDuration = 1;
            fallTime = 5;
            transform.position = initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falling = true;
        }
    }
}
