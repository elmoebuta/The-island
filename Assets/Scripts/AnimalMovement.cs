
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private float walkTime = 25f; // Tiempo que camina
    private float idleTime = 5f; // Tiempo que se queda quieto
    private bool isWalking = false; // Indica si el animal est� caminando actualmente
    private float timer = 0f; // Temporizador para rastrear el tiempo
    private float moveSpeed = 0.5f; // Velocidad de movimiento
    private float rotationSpeed = 90f; // Velocidad de rotaci�n
    private Vector3 moveDirection; // Direcci�n de movimiento actual
    private Vector2 center = new Vector2(250f, 250f); // Centro de la circunferencia
    private float maxRadius = 210f; // Radio m�ximo de la circunferencia
    public bool isActive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        // Iniciar la animaci�n de caminar al comienzo
        SetRandomMoveDirection();
    }

    private void Update()
    {
        // Actualizar el temporizador
        timer += Time.deltaTime;

        if (isActive)
        {
            if (isWalking)
            {
                // Si ha caminado el tiempo suficiente, cambia a la animaci�n de estar quieto
                if (timer >= walkTime)
                {
                    animator.SetInteger("GoIdle", 1);
                    animator.SetInteger("GoWalk", 0);
                    isWalking = false;
                    timer = 0f; // Reiniciar el temporizador
                    rigidbody.velocity = Vector3.zero; // Detener el movimiento
                }
                else
                {
                    // Mover al animal hacia adelante mientras camina
                    RotateTowardsDirection(moveDirection);
                    rigidbody.velocity = moveDirection * moveSpeed;
                    // Rotar gradualmente hacia la direcci�n de movimiento

                    // Limitar el movimiento dentro de la circunferencia
                    Vector2 currentPos = new Vector2(transform.position.x, transform.position.z);
                    float distanceToCenter = Vector2.Distance(currentPos, center);

                    if (distanceToCenter > maxRadius)
                    {
                        // El animal est� fuera de la circunferencia, cambiar de direcci�n
                        Vector2 directionToCenter = (center - currentPos).normalized;
                        moveDirection = new Vector3(directionToCenter.x, 0f, directionToCenter.y);
                        RotateTowardsDirection(moveDirection);
                    }
                }
            }
            else
            {
                // Si ha estado quieto el tiempo suficiente, cambia a la animaci�n de caminar
                if (timer >= idleTime)
                {
                    animator.SetInteger("GoIdle", 0);
                    animator.SetInteger("GoWalk", 1);
                    isWalking = true;
                    timer = 0f; // Reiniciar el temporizador
                    rigidbody.velocity = Vector3.zero; // Detener el movimiento
                                                       // Inicializar una nueva direcci�n de movimiento aleatoria
                    SetRandomMoveDirection();
                }
            }


        }

       
    }

    // Establecer una direcci�n de movimiento aleatoria
    private void SetRandomMoveDirection()
    {
        // Generar una rotaci�n aleatoria en el plano horizontal (solo en el eje Y)
        float randomRotation = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0f, randomRotation, 0f) * Vector3.forward;
    }

    // Rotar gradualmente hacia la direcci�n de movimiento
    private void RotateTowardsDirection(Vector3 targetDirection)
    {
        // Obtener la rotaci�n actual sin incluir la inclinaci�n hacia arriba o hacia abajo
        Quaternion currentRotation = transform.rotation;
        currentRotation.x = 0;
        currentRotation.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}








































/*using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    private float walkTime = 25f; // Tiempo que camina
    private float idleTime = 5f; // Tiempo que se queda quieto
    private bool isWalking = false; // Indica si el animal est� caminando actualmente
    private float timer = 0f; // Temporizador para rastrear el tiempo
    private float moveSpeed = 0.5f; // Velocidad de movimiento
    private float rotationSpeed = 90f; // Velocidad de rotaci�n
    private Vector3 moveDirection; // Direcci�n de movimiento actual

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        // Iniciar la animaci�n de caminar al comienzo
        SetRandomMoveDirection();
    }

    private void Update()
    {
        // Actualizar el temporizador
        timer += Time.deltaTime;

        if (isWalking)
        {
            // Si ha caminado el tiempo suficiente, cambia a la animaci�n de estar quieto
            if (timer >= walkTime)
            {
                animator.SetInteger("GoIdle", 1);
                animator.SetInteger("GoWalk", 0);
                isWalking = false;
                timer = 0f; // Reiniciar el temporizador
                rigidbody.velocity = Vector3.zero; // Detener el movimiento
            }
            else
            {
                // Mover al animal hacia adelante mientras camina
                RotateTowardsDirection(moveDirection);
                rigidbody.velocity = moveDirection * moveSpeed;
                // Rotar gradualmente hacia la direcci�n de movimiento
                
            }
        }
        else
        {
            // Si ha estado quieto el tiempo suficiente, cambia a la animaci�n de caminar
            if (timer >= idleTime)
            {
                animator.SetInteger("GoIdle", 0);
                animator.SetInteger("GoWalk", 1);
                isWalking = true;
                timer = 0f; // Reiniciar el temporizador
                rigidbody.velocity = Vector3.zero; // Detener el movimiento
                // Inicializar una nueva direcci�n de movimiento aleatoria
                SetRandomMoveDirection();
            }
        }
    }

    // Establecer una direcci�n de movimiento aleatoria
    private void SetRandomMoveDirection()
    {
        // Generar una rotaci�n aleatoria en el plano horizontal (solo en el eje Y)
        float randomRotation = Random.Range(0f, 360f);
        moveDirection = Quaternion.Euler(0f, randomRotation, 0f) * Vector3.forward;
    }

    // Rotar gradualmente hacia la direcci�n de movimiento
    private void RotateTowardsDirection(Vector3 targetDirection)
    {
        // Obtener la rotaci�n actual sin incluir la inclinaci�n hacia arriba o hacia abajo
        Quaternion currentRotation = transform.rotation;
        currentRotation.x = 0;
        currentRotation.z = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}*/
