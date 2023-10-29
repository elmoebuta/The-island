using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public string color = "Red"; // Variable pública para el color del objeto.
    public float destroyRadius = 5f; // Radio de destrucción cuando el jugador se acerca.
    public string playerTag = "Player"; // Tag del jugador.
    public GameObject canvasFeedPrefab; // Referencia al prefab del CanvasFeed.
    private GameObject canvasFeedInstance;

    private void Start()
    {
        // Agrega código adicional de inicialización si es necesario.
    }

    private void Update()
    {
        // Imprime la posición del objeto "Rock" y el color.
       //Debug.Log("Posición de Rock: " + transform.position);

        // Busca todos los objetos con el tag "Player" en el rango de destrucción.
        Collider[] colliders = Physics.OverlapSphere(transform.position, destroyRadius);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(playerTag))
            {
                if (canvasFeedInstance == null )
                {
                    canvasFeedInstance = Instantiate(canvasFeedPrefab, transform.position, Quaternion.identity);
                }
                // Incrementa el contador correspondiente según el color.
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (color == "blue")
                    {
                        GameManager.contadorAzul++;
                    }
                    else if (color == "pink")
                    {
                        GameManager.contadorRosado++;
                    }

                    // Destruye el objeto "Rock" si el jugador está en el rango.
                    Destroy(gameObject);
                    Destroy(canvasFeedInstance);
                    break; // Sal del bucle ya que el objeto "Rock" se ha destruido.}

                }
            }
            else
            {
                Destroy(canvasFeedInstance);
                canvasFeedInstance = null;

            }

           // Debug.Log("contadorAzul: " + GameManager.contadorAzul);
            //Debug.Log("contadorRosado: " + GameManager.contadorRosado);
        }
    }
}