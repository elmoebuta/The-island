using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasFrasesController : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    public TMP_Text textoFrase;
    public List<string> frasesMotivacionales = new List<string>();
    private int indiceActual = 0;

    void Start()
    {
        MostrarSiguienteFrase();
        Invoke("sacarFondo", 5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MostrarSiguienteFrase();
        }

    }

    private void MostrarSiguienteFrase()
    {
        if (frasesMotivacionales.Count == 0)
        {
            Debug.LogError("La lista de frases motivacionales está vacía. Añade algunas frases en el Inspector.");
            return;
        }

        textoFrase.text = frasesMotivacionales[indiceActual];
        indiceActual = (indiceActual + 1) % frasesMotivacionales.Count;
    }

    void sacarFondo()
    {
        canvas.SetActive(false);
    }
}
