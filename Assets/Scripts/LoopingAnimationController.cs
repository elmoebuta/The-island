using UnityEngine;

public class LoopAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Obt�n el componente Animator del objeto
        animator = GetComponent<Animator>();

        // Inicia la animaci�n en un loop
        PlayAnimationLoop("swan_goose_walk_anim");
    }

    private void PlayAnimationLoop(string animationName)
    {
        // Comprueba si el Animator tiene la animaci�n
        if (animator.HasState(0, Animator.StringToHash(animationName)))
        {
            // Configura la animaci�n para que se repita en un loop
            animator.Play(animationName, 0, 0f);
            animator.speed = 1f; // Asegura que la animaci�n se reproduzca a velocidad normal
        }
        else
        {
            Debug.LogWarning("La animaci�n " + animationName + " no se encontr� en el Animator.");
        }
    }
}