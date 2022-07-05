using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEffect()); // when the effect is spawned
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(2); // let it be on screen for 2 seconds
        Destroy(gameObject); // then destroy
    }
}
