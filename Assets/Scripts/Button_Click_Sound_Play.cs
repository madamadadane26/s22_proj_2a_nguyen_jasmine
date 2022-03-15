using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Click_Sound_Play : MonoBehaviour
{
    public AudioSource buttonClickSound;

    void Start()
    {
        
    }

     void Update()
    {
        
    }

    public void PlayButtonClickSound()
    {
        buttonClickSound.Play();
    }



}
