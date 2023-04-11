using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayer : MonoBehaviour
{
    public string apiURL;
    public AudioSource audioSource;
    private List<string> playedSongs = new List<string>();
    private string currentSong;

    void Start()
    {
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get(apiURL);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                yield return new WaitForSeconds(5);
                continue;
            }

            string[] songs = www.downloadHandler.text.Split('\n');
            string songToPlay = GetRandomSong(songs);

            while (playedSongs.Contains(songToPlay))
            {
                songToPlay = GetRandomSong(songs);
            }

            playedSongs.Add(songToPlay);
            if (playedSongs.Count > 10)
            {
                playedSongs.RemoveAt(0);
            }

            currentSong = songToPlay;
            audioSource.clip = null;
            audioSource.clip = GetAudioClip(songToPlay);
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);
        }
    }

    private string GetRandomSong(string[] songs)
    {
        int index = Random.Range(0, songs.Length);
        return songs[index];
    }

    private AudioClip GetAudioClip(string songURL)
    {
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(songURL, AudioType.MPEG);
        www.SendWebRequest();

        while (!www.isDone)
        {
            yield return null;
        }

        AudioClip audioClip = DownloadHandlerAudioClip.GetContent(www);
        return audioClip;
    }
}
