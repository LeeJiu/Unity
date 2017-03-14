using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource efxSource;

    private static SoundManager sInstance;

    public static SoundManager Instance = null;
    //{
    //    get
    //    {
    //        if(sInstance == null)
    //        {
    //            GameObject gObject = new GameObject("_SoundManager");
    //            sInstance = gObject.AddComponent<SoundManager>();
    //        }
    //        return sInstance;
    //    }
    //}

    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;


	void Awake ()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this.gameObject);
        }
        //씬이 넘어가도 살아 있는다. / 게임이 살아있다면 계속 살아 있는다.
        DontDestroyOnLoad(gameObject);

        musicSource.loop = true;
        efxSource.loop = false;
	}
	
    public void PlayEfx(AudioClip clip)
    {
        efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void PlayRandomEfx(AudioClip[] clips)
    {
        int randIndex = Random.Range(0, clips.Length);

        efxSource.clip = clips[randIndex];
        efxSource.Play();
    }

    public void StopEfx()
    {
        efxSource.Stop();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlayRandomMusic(AudioClip[] clips)
    {
        int randIndex = Random.Range(0, clips.Length);

        musicSource.clip = clips[randIndex];
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void MusicVolumeUp()
    {
        if(musicSource.volume < 1.0f)
        {
            musicSource.volume += 0.1f;
        }
    }

    public void MusicVolumeDown()
    {
        if (musicSource.volume > 0.0f)
        {
            musicSource.volume -= 0.1f;
        }
    }
}
