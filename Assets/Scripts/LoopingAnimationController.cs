using UnityEngine;

public class LoopAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Obtén el componente Animator del objeto
        animator = GetComponent<Animator>();

        // Inicia la animación en un loop
        PlayAnimationLoop("swan_goose_walk_anim");
    }

    private void PlayAnimationLoop(string animationName)
    {
        // Comprueba si el Animator tiene la animación
        if (animator.HasState(0, Animator.StringToHash(animationName)))
        {
            // Configura la animación para que se repita en un loop
            animator.Play(animationName, 0, 0f);
            animator.speed = 1f; // Asegura que la animación se reproduzca a velocidad normal
        }
        else
        {
            Debug.LogWarning("La animación " + animationName + " no se encontró en el Animator.");
        }
    }
}