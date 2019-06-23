using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A singleton to manage the background music
 */
public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;
    private static MusicClass instance = null;
    public static MusicClass Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
