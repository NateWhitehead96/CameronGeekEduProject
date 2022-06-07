using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolumeMaster : MonoBehaviour
{
    public static SoundVolumeMaster instance;

    public float soundFXVolume;
    public float musicVolume;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
