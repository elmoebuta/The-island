using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource; // Referencia al AudioSource de la música
    public List<AudioClip> musicTracks; // Lista de pistas de audio

    private int currentTrackIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cambia la música al índice especificado
    public void ChangeMusic(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < musicTracks.Count)
        {
            currentTrackIndex = trackIndex;
            musicSource.clip = musicTracks[currentTrackIndex];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Índice de pista de audio fuera de rango");
        }
    }

    // Cambia la música al siguiente track
    public void NextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Count;
        musicSource.clip = musicTracks[currentTrackIndex];
        musicSource.Play();
    }

    // Cambia la música al track anterior
    public void PreviousTrack()
    {
        currentTrackIndex = (currentTrackIndex - 1 + musicTracks.Count) % musicTracks.Count;
        musicSource.clip = musicTracks[currentTrackIndex];
        musicSource.Play();
    }
    public string SongName()
    {
        return musicSource.name;
    }
}
