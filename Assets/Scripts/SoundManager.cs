using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource, effectSource;
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioClip[] musicClips;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.volume = .5f;
    }
    public void PlayMusic(string name)
    {
        foreach (var clip in musicClips)
        {
            if (name == clip.name)
            {
                musicSource.clip = clip;
                musicSource.Play();
            }
        }
    }
    public void PlayMusic()
    {
        if (musicSource.clip != null)
        {
            musicSource.UnPause();
        }
    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public bool IsPlayingMusic()
    {
        return musicSource.isPlaying;
    }
    public void PlaySound(string name)
    {
        foreach (var clip in sfxClips)
        {
            if (name == clip.name)
            {
                effectSource.PlayOneShot(clip);
            }
        }
    }
    public float GetSoundLength(string name)
    {
        foreach (var clip in sfxClips)
        {
            if (name == clip.name)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}
