using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{

    public float interactionDistance = 3f; // Distancia m�xima de interacci�n.
    private Animator duckAnimator; // Animator del pato.
    private bool isEating = false; // Indica si el pato est� comiendo actualmente.
    private AnimalMovement animalMovement; // Referencia al script AnimalMovement.
    private bool hasInteracted = false;
    public GameObject canvasFeedPrefab; // Referencia al prefab del CanvasFeed.
    private GameObject canvasFeedInstance;
    private bool comido = false;
    private void Start()
    {
        duckAnimator = GetComponent<Animator>();
        animalMovement = GetComponent<AnimalMovement>();
        
    }

    private void Update()
    {
        // Detecta si el personaje principal est� dentro de la distancia de interacci�n.
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance);
        

        if (isEating == false) // Verifica que no se haya interactuado previamente.
        {
            foreach (Collider col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    // Calcula la distancia entre el pato y el jugador.
                    float distance = Vector3.Distance(transform.position, col.transform.position);
                    if (canvasFeedInstance == null && comido==false)
                    {
                        Debug.Log("Se creo el canvas");
                        canvasFeedInstance = Instantiate(canvasFeedPrefab, transform.position, Quaternion.identity);
                    }

                    // Si el jugador presiona la tecla de interacci�n (por ejemplo, "F") y est� dentro de la distancia de interacci�n, ejecuta el cuack del pato.
                    if (Input.GetKeyDown(KeyCode.F) && distance <= interactionDistance)
                    {
                        //Debug.Log("Pato: Cuack");

                        // Cambiar la transici�n a "GoEat".
                        duckAnimator.SetInteger("GoEat", 1);

                        Destroy(canvasFeedInstance);
                        comido = true;
                        duckAnimator.SetInteger("GoWalk", 0);
                        duckAnimator.SetInteger("GoIdle", 0);
                        
                        animalMovement.isActive = false;
                        isEating = true;
                         // Marca que la interacci�n ya ha ocurrido.

                      //  Debug.Log("Interacci�n realizada");

                        // Sal del bucle foreach.
                        
                        // Desactivar el movimiento del pato.
                    }

                    Debug.Log(isEating);

                    
                }

                else
                {

                }
               

            }


        }


        // Comprobar si el pato est� en modo "Eat" para controlar el retorno al movimiento.
        if (isEating==true)
        {
            // Si la animaci�n de "Eat" ha terminado, volver al movimiento.
            AnimatorStateInfo stateInfo = duckAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("eat"))
            {
                Debug.Log("Estado actual: Eat");
                Debug.Log("Normalized Time: " + stateInfo.normalizedTime);

                if (stateInfo.normalizedTime >= 0.9f)
                {
                    Debug.Log("Final de la animaci�n Eat alcanzado.");

                    // Reiniciar la variable "GoEat".
                    duckAnimator.SetInteger("GoEat", 0);
                    duckAnimator.SetInteger("GoWalk", 1);
                    duckAnimator.SetInteger("GoIdle", 1);
                    animalMovement.isActive = true;
                    

                    isEating = false;

                    // Reactivar el movimiento del pato.
                }
            }
            else
            {
                Debug.Log("Estado actual no es Eat.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruye el canvasFeedInstance cuando el jugador sale del �rea del Collider.
            if (canvasFeedInstance != null)
            {
                Debug.Log("Se destruy� el canvas");
                Destroy(canvasFeedInstance);
                canvasFeedInstance = null;
            }
        }
    }
}