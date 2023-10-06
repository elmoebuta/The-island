using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public int ContadorAnimalesComiendo = 0;
    private AudioSource audioSource;
    public TextMeshProUGUI textoMisionMusica;
    private bool musicaMisionReproducida = false;
    public GameObject confirmationPrompt;

    public TextMeshProUGUI textoMisionRoca;
    public TextMeshProUGUI textoMisionAnimales;
    public GameObject ValidadorMisionAnimales;

    private AudioSource componenteAudio;
    [SerializeField] private AudioClip musicaMision;

    private string cancionActual = ""; // Guarda el nombre de la canci�n actual
    private int countCanciones = 1;  


    private void Start()
    {
        componenteAudio = GetComponent<AudioSource>();
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
        if (GameManager.contadorAlimentar < 5)
        {
            MisionAcariciarAnimales();
        }
        else
        {
            if (!musicaMisionReproducida)
            {
                StartCoroutine(MisionCompletada());

                componenteAudio.PlayOneShot(musicaMision);
                musicaMisionReproducida = true;
                
            }
            ValidadorMisionAnimales.SetActive(true);
        }
 
    }

    public IEnumerator MisionCompletada()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(5);
        confirmationPrompt.SetActive(false);

    }

    public void MisionEscucharMusica()
    {
        textoMisionMusica.text = "Escucha musica " + countCanciones + "/2";
        // Verifica si la canci�n actual ha cambiado
        if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name != cancionActual)
        {
            cancionActual = audioSource.clip.name;
            Debug.Log("Canci�n cambiada a: " + cancionActual);
            countCanciones++;

            if (countCanciones >= 2)
            {
                CompletarMision();
            }
        }
    }

    public void MisionAcariciarAnimales()
    {
        textoMisionAnimales.text = "Alimenta a animales " + GameManager.contadorAlimentar + "/5";
    }

    public void MisionRecolectarRocas()
    {
    }

    private void CompletarMision()
    {
        // Implementa las acciones que se deben realizar cuando se completa la misi�n aqu�.
        Debug.Log("Misi�n completada!");
    }
}