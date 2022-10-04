using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance; // allows other scripts to access this script
    private void Awake() // before we play the level
    {
        if(instance != null) // if we have a sound effect manager already then destroy the level's sound effect manager
        {
            Destroy(gameObject);
        }
        else // otherwise use this sound effect manager
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // different sound effects
    public float volume; // will help control all the sound fx volumes
    public AudioSource playerHurt;
    public AudioSource enemyHurt;
    public AudioSource jumpSound;
    public AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
