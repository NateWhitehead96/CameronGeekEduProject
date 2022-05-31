using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager instance;
    // singleton design pattern to make sure this is the only sound effect manager in the game
    private void Awake()
    {
        if(instance != null) // if there is a sound effect manager, destroy the one in the level
        {
            Destroy(gameObject);
        }
        else // this one in the level becomes the only sound effect manager
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public float volume; // control the volume of all of our sound effects
    // the sound effects in our game
    public AudioSource waveIncoming;
    public AudioSource plantPlacement;
    public AudioSource zombieSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
