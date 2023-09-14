using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Interactor : MonoBehaviour
{

    public float interactionDistance = 3f; // Distancia máxima de interacción.
    private Animator duckAnimator; // Animator del pato.
    private bool isEating = false; // Indica si el pato está comiendo actualmente.
    private AnimalMovement animalMovement; // Referencia al script AnimalMovement.
    private bool hasInteracted = false;

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

                    // Si el jugador presiona la tecla de interacción (por ejemplo, "F") y está dentro de la distancia de interacción, ejecuta el cuack del pato.
                    if (Input.GetKeyDown(KeyCode.F) && distance <= interactionDistance)
                    {
                        //Debug.Log("Pato: Cuack");

                        // Cambiar la transición a "GoEat".
                        duckAnimator.SetInteger("GoEat", 1);
                        
                        
                        duckAnimator.SetInteger("GoWalk", 0);
                        duckAnimator.SetInteger("GoIdle", 0);
                        
                        animalMovement.isActive = false;
                        isEating = true;
                         // Marca que la interacción ya ha ocurrido.

                      //  Debug.Log("Interacción realizada");

                        // Sal del bucle foreach.
                        
                        // Desactivar el movimiento del pato.
                    }

                    Debug.Log(isEating);
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
                Debug.Log("Estado actual: Eat");
                Debug.Log("Normalized Time: " + stateInfo.normalizedTime);

                if (stateInfo.normalizedTime >= 0.9f)
                {
                    Debug.Log("Final de la animación Eat alcanzado.");

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
}