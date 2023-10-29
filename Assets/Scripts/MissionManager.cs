using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int ContadorAnimalesComiendo = 0;
    private AudioSource audioSource;
    public GameObject ValidadorMisionMusica;
    public TextMeshProUGUI textoMisionMusica;
    public int ContarMisiones = 0;


    private bool musicaMisionAnimalesReproducida = false;
    private bool musicaMisionRosadoReproducida = false;
    private bool musicaMisionCelesteReproducida = false;
    private bool musicaMisionMusicaReproducida = false;


    public GameObject confirmationPrompt;

    public GameObject ValidadorMisionRocaRosas;
    public TextMeshProUGUI textoMisionRocaRosada;

    public GameObject ValidadorMisionRocaCeleste;
    public TextMeshProUGUI textoMisionRocaCeleste;

    public GameObject ValidadorMisionAnimales;
    public TextMeshProUGUI textoMisionAnimales;

    private AudioSource componenteAudio;
    [SerializeField] private AudioClip musicaMision;

    private string cancionActual = ""; // Guarda el nombre de la canción actual
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
        if (ContarMisiones>=4)
        {
            Invoke("JuegoCompletado", 10f);
        }

        if (countCanciones <= 1)
        {
            MisionEscucharMusica();
        }
        else
        {
            if (!musicaMisionMusicaReproducida)
            {
                MisionEscucharMusica();
                StartCoroutine(MisionCompletada());
                componenteAudio.PlayOneShot(musicaMision);
                musicaMisionMusicaReproducida = true;
                ContarMisiones++;
            }
            ValidadorMisionMusica.SetActive(true);
        }

        if (GameManager.contadorRosado <= 2)
        {
            MisionRecolectarRocasRosadas();
        }
        else
        {
            if (!musicaMisionRosadoReproducida)
            {
                MisionRecolectarRocasRosadas();
                StartCoroutine(MisionCompletada());

                componenteAudio.PlayOneShot(musicaMision);
                musicaMisionRosadoReproducida = true;
                ContarMisiones++;
            }
            ValidadorMisionRocaRosas.SetActive(true);
        }

        if (GameManager.contadorAzul <= 2)
        {
            MisionRecolectarRocasCelestes();
        }
        else
        {
            if (!musicaMisionCelesteReproducida)
            {
                MisionRecolectarRocasCelestes();
                StartCoroutine(MisionCompletada());

                componenteAudio.PlayOneShot(musicaMision);
                musicaMisionCelesteReproducida = true;
                ContarMisiones++;
            }
            ValidadorMisionRocaCeleste.SetActive(true);
        }

        if (GameManager.contadorAlimentar <= 4)
        {
            MisionAcariciarAnimales();
        }
        else
        {
            if (!musicaMisionAnimalesReproducida)
            {
                MisionAcariciarAnimales();
                StartCoroutine(MisionCompletada());

                componenteAudio.PlayOneShot(musicaMision);
                musicaMisionAnimalesReproducida = true;
                ContarMisiones++;
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
        // Verifica si la canción actual ha cambiado
        if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name != cancionActual)
        {
            cancionActual = audioSource.clip.name;
            Debug.Log("Canción cambiada a: " + cancionActual);
            countCanciones++;
        }
    }

    public void MisionAcariciarAnimales()
    {
        textoMisionAnimales.text = "Alimenta a animales " + GameManager.contadorAlimentar + "/5";
    }

    public void MisionRecolectarRocasCelestes()
    {
        textoMisionRocaCeleste.text = "Recolecta rocas celestes " + GameManager.contadorAzul + "/3";
    }
    public void MisionRecolectarRocasRosadas()
    {
        textoMisionRocaRosada.text = "Recolecta rocas rosadas " + GameManager.contadorRosado + "/3";
    }
    public void JuegoCompletado()
    {
        SceneManager.LoadScene("JuegoCompletado");
    }
}