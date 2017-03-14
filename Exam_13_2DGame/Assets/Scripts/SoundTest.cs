using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundTest : MonoBehaviour
{
    public AudioClip[] musicClips;
    public AudioClip[] efxClips;


	void Update ()
    {
        //Background
		if(Input.GetKeyDown(KeyCode.Alpha1) && musicClips[0])
        {
            SoundManager.Instance.PlayMusic(musicClips[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && musicClips[1])
        {
            SoundManager.Instance.PlayMusic(musicClips[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && musicClips[2])
        {
            SoundManager.Instance.PlayMusic(musicClips[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && musicClips[3])
        {
            SoundManager.Instance.PlayMusic(musicClips[3]);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SoundManager.Instance.StopMusic();
        }


        //Effect
        if (Input.GetKeyDown(KeyCode.Q) && efxClips[0])
        {
            SoundManager.Instance.PlayEfx(efxClips[0]);
        }
        else if (Input.GetKeyDown(KeyCode.W) && efxClips[1])
        {
            SoundManager.Instance.PlayEfx(efxClips[1]);
        }
        else if (Input.GetKeyDown(KeyCode.E) && efxClips[2])
        {
            SoundManager.Instance.PlayEfx(efxClips[2]);
        }
        else if (Input.GetKeyDown(KeyCode.R) && efxClips[3])
        {
            SoundManager.Instance.PlayEfx(efxClips[3]);
        }
    }
}
