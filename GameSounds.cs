using UnityEngine;
using System.Collections.Generic;

public class GameSounds : MonoBehaviour
{
    public static GameSounds instance;

    [Header("Audio Sources")]
    public AudioSource music;
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public enum SoundEffect
    {
        Error, Click, Hover, Alert, Good, Bad, Money, Buy, Sell, YearEnd, Impact, Iron, Dismiss
    }

    [System.Serializable]
    public struct AudioClipData
    {
        public SoundEffect soundEffect;
        public AudioClip audioClip;
    }

    [Header("Audio Clips")]
    public List<AudioClipData> audioClips;

    private Dictionary<SoundEffect, AudioClip> audioClipDict;

    private void Awake()
    {
        instance = this;
        audioClipDict = new Dictionary<SoundEffect, AudioClip>();

        foreach (AudioClipData audioClipData in audioClips)
        {
            audioClipDict.Add(audioClipData.soundEffect, audioClipData.audioClip);
        }
    }

    public void PlaySound(SoundEffect soundEffect, AudioSource audioSource, float volume = 0.7f, bool isOneShot = false)
    {
        if (audioClipDict.ContainsKey(soundEffect))
        {
            AudioClip clip = audioClipDict[soundEffect];

            if (isOneShot)
            {
                audioSource.PlayOneShot(clip, volume);
            }
            else
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
