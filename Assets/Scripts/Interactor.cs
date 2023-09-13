using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactionDistance = 3f; // Distancia m�xima de interacci�n.
    private Animator duckAnimator; // Animator del pato.
    private bool isEating = false; // Indica si el pato est� comiendo actualmente.
    public AnimalMovement animalMovement; // Referencia al script AnimalMovement.

    private void Start()
    {
        duckAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detecta si el personaje principal est� dentro de la distancia de interacci�n.
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                // Calcula la distancia entre el pato y el jugador.
                float distance = Vector3.Distance(transform.position, col.transform.position);

                // Si el jugador presiona la tecla de interacci�n (por ejemplo, "F") y est� dentro de la distancia de interacci�n, ejecuta el cuack del pato.
                if (Input.GetKeyDown(KeyCode.F) && distance <= interactionDistance)
                {
                    Debug.Log("Pato: Cuack");

                    // Cambiar la transici�n a "GoEat".
                    duckAnimator.SetInteger("GoEat", 1);
                    isEating = true;

                    // Desactivar el movimiento del pato.
                   // animalMovement.isActive = false;
                }
            }
        }

        // Comprobar si el pato est� en modo "Eat" para controlar el retorno al movimiento.
        if (isEating)
        {
            // Si la animaci�n de "Eat" ha terminado, volver al movimiento.
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



