using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public float interactionDistance = 3f; // Distancia máxima de interacción.
    private Animator duckAnimator; // Animator del pato.
    private bool isEating = false; // Indica si el pato está comiendo actualmente.
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
        // Detecta si el personaje principal está dentro de la distancia de interacción.
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
                        canvasFeedInstance = Instantiate(canvasFeedPrefab, transform.position, Quaternion.identity);
                    }

                    

                    // Si el jugador presiona la tecla de interacción (por ejemplo, "F") y está dentro de la distancia de interacción, ejecuta el cuack del pato.
                    if (Input.GetKeyDown(KeyCode.F) && distance <= interactionDistance && comido ==false)
                    {
                        // Cambiar la transición a "GoEat".
                        duckAnimator.SetInteger("GoEat", 1);

                        Destroy(canvasFeedInstance);
                        comido = true;
                        GameManager.contadorAlimentar++;
                        duckAnimator.SetInteger("GoWalk", 0);
                        duckAnimator.SetInteger("GoIdle", 0);
                        
                        animalMovement.isActive = false;
                        isEating = true;
                        
                        Debug.Log(GameManager.contadorAlimentar);
                       
                        // Marca que la interacción ya ha ocurrido.

                        //  Debug.Log("Interacción realizada");

                        // Sal del bucle foreach.

                        // Desactivar el movimiento del pato.
                    }
                }

                else
                {
                    Destroy(canvasFeedInstance);
                    canvasFeedInstance = null;
                    
                }
               

            }


        }


        // Comprobar si el pato está en modo "Eat" para controlar el retorno al movimiento.
        if (isEating==true)
        {
            // Si la animación de "Eat" ha terminado, volver al movimiento.
            AnimatorStateInfo stateInfo = duckAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("eat"))
            {

                if (stateInfo.normalizedTime >= 0.9f)
                {

                    // Reiniciar la variable "GoEat".
                    duckAnimator.SetInteger("GoEat", 0);
                    duckAnimator.SetInteger("GoWalk", 1);
                    duckAnimator.SetInteger("GoIdle", 1);
                    animalMovement.isActive = true;
                    

                    isEating = false;

                    // Reactivar el movimiento del pato.
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruye el canvasFeedInstance cuando el jugador sale del área del Collider.
            if (canvasFeedInstance != null)
            {
                Destroy(canvasFeedInstance);
                canvasFeedInstance = null;
            }
        }
    }
}