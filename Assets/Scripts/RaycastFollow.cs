using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFollow : MonoBehaviour
{
    public float visionRadius = 3.5f;
    public float attackRadius = 1f;
    public float speed = 1.5f;

    GameObject player;
    Rigidbody2D rb2d;
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Establecemos como posición objetvo la posición inicial por defecto.
        Vector3 targetPosition = initialPosition;

        // forward es un vector en la dirección del player generado a partir de la diferencia de posiciones entre el jugador y el enemigo.
        Vector3 forward = player.transform.position - transform.position;

        // Proyectamos el raycast pasándole primero el origen del rayo, luego un vector hasta el objetivo, la distancia máxima . 
        // El último parámetro es la capa en la que queremos que se aplique el rayo.
        // Queremos que se aplique en la capa donde se encuentran todos los colliders (paredes, jugador).
        // Es importante cambiarle la capa al propio enemigo pues el rayo se lanza desde su posición y como tiene un collider el raycast lo detectaría también.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, forward, visionRadius, 1 << LayerMask.NameToLayer("Raycast"));


        // Pintamos el rayo hasta el jugador.
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            // Comprobamos si el rayo ha chocado con algo.
            // Solo nos interesa que se mueva cuando con lo que ha chocado es el jugador.
            // Hay que especificar esto porque el rayo puede chocar con los colliders de las paredes.
            //Debug.Log("Tag: " + hit.collider.tag);

            if(hit.collider.tag == "Player")
                targetPosition = player.transform.position;
        }

        // Calculamos la distancia entre el objetivo y la posición del enemigo.
        float distance = Vector3.Distance(targetPosition, transform.position);
        // Calculamos el vector de dirección de su visión de módulo 1.
        Vector3 visionDir = (targetPosition - transform.position).normalized;

        if (targetPosition != initialPosition && distance < attackRadius)
        {
            //Debug.Log("Hit");

        }
        else
        {
            //Debug.Log("Move");
            rb2d.MovePosition(transform.position + visionDir * speed * Time.deltaTime);
        }


        if (targetPosition == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;
        }

        Debug.DrawLine(transform.position, targetPosition, Color.green);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * 0.5f;
    }

}

