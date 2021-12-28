using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeScreen()
    {
        animator.SetBool("fading", true); // fade the screen to solid colour
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(2); // after 2 seconds fade back from solid colour to invisible
        animator.SetBool("fading", false);
    }
}
