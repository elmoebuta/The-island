using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{

    private AudioSource audioSource;
    private string cancionActual = ""; // Guarda el nombre de la canci�n actual
    private int countCanciones = 1;  

    private void Start()
    {
        audioSource = AudioManager.Instance.musicSource;
        cancionActual = audioSource.clip.name;
        Debug.Log("La cancion es: " + cancionActual);

        if (audioSource == null)
        {
            Debug.LogError("Este GameObject debe tener un componente AudioSource adjunto.");
        }
    }

    private void Update()
    {
        // Verifica si la canci�n actual ha cambiado
        if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name != cancionActual)
        {
            cancionActual = audioSource.clip.name;
            Debug.Log("Canci�n cambiada a: " + cancionActual);
            countCanciones++;

            if (countCanciones>=2)
            {
                CompletarMision();
            }
        }
    }

    private void CompletarMision()
    {
        // Implementa las acciones que se deben realizar cuando se completa la misi�n aqu�.
        Debug.Log("Misi�n completada!");
    }
}