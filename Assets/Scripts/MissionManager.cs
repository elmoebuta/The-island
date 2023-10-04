using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public int ContadorAnimalesComiendo = 0;
    private AudioSource audioSource;
    public TextMeshProUGUI textoMisionMusica;
    public TextMeshProUGUI textoMisionRoca;
    public TextMeshProUGUI textoMisionAnimales;

    private string cancionActual = ""; // Guarda el nombre de la canción actual
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
        MisionEscucharMusica();
        MisionAcariciarAnimales();
 
    }


    public void MisionEscucharMusica()
    {
        textoMisionMusica.text = "Escucha musica " + countCanciones + "/2";
        // Verifica si la canción actual ha cambiado
        if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name != cancionActual)
        {
            cancionActual = audioSource.clip.name;
            Debug.Log("Canción cambiada a: " + cancionActual);
            countCanciones++;

            if (countCanciones >= 2)
            {
                CompletarMision();
            }
        }
    }

    public void MisionAcariciarAnimales()
    {
        textoMisionAnimales.text = "Alimenta a animales " + ContadorAnimalesComiendo + "/5";
    }

    public void MisionRecolectarRocas()
    {
    }

    private void CompletarMision()
    {
        // Implementa las acciones que se deben realizar cuando se completa la misión aquí.
        Debug.Log("Misión completada!");
    }
}