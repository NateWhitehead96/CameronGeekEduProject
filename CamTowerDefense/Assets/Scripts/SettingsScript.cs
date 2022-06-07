using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public Slider soundFX;
    public Slider music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundVolumeMaster.instance.soundFXVolume = soundFX.value; // whatever value the slider is at, will be the sound fx volume
        SoundVolumeMaster.instance.musicVolume = music.value; // whatever the value of the slider is at, will be the music volume
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
