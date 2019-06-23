using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource.time = _audioSource.clip.length * 0.45f;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
