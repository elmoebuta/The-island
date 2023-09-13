using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactionDistance = 3f; // Distancia máxima de interacción.
    private Animator duckAnimator; // Animator del pato.
    private bool isEating = false; // Indica si el pato está comiendo actualmente.
    public AnimalMovement animalMovement; // Referencia al script AnimalMovement.

    private void Start()
    {
        duckAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detecta si el personaje principal está dentro de la distancia de interacción.
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                // Calcula la distancia entre el pato y el jugador.
                float distance = Vector3.Distance(transform.position, col.transform.position);

                // Si el jugador presiona la tecla de interacción (por ejemplo, "F") y está dentro de la distancia de interacción, ejecuta el cuack del pato.
                if (Input.GetKeyDown(KeyCode.F) && distance <= interactionDistance)
                {
                    Debug.Log("Pato: Cuack");

                    // Cambiar la transición a "GoEat".
                    duckAnimator.SetInteger("GoEat", 1);
                    isEating = true;

                    // Desactivar el movimiento del pato.
                   // animalMovement.isActive = false;
                }
            }
        }

        // Comprobar si el pato está en modo "Eat" para controlar el retorno al movimiento.
        if (isEating)
        {
            // Si la animación de "Eat" ha terminado, volver al movimiento.
            AnimatorStateInfo stateInfo = duckAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Eat") && stateInfo.normalizedTime >= 1f)
            {
                // Reiniciar la variable "GoEat".
                duckAnimator.SetInteger("GoEat", 0);
                isEating = false;

                // Reactivar el movimiento del pato.
               // animalMovement.isActive = true;
            }
        }
    }
}



