using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource musicSource, effectSource;
    [SerializeField] private AudioClip[] sfxClip;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySound(string name)
    {
        foreach (var clip in sfxClip)
        {
            if (name == clip.name)
            {
                effectSource.PlayOneShot(clip);
            }
        }
    }
    public float GetSoundLength(string name)
    {
        foreach (var clip in sfxClip)
        {
            if (name == clip.name)
            {
                return clip.length;
            }
        }
        return 0f;
    }
}
