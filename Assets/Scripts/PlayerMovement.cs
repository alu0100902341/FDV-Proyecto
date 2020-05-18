using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    KeyCode lastKeyPressed;
    [SerializeField] private float speed_;
    Vector2 movement;

    // Usar awake cuando no se requieren datos de otros scripts. Awake se ejecuta antes que start.
    // Es bueno utilizarlo para inicializaciones y luego acceder esos valores en el start de otro script.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2();
        speed_ = 4f;
    }

    private void Update()
    {
        movement.x = 0;
        movement.y = 0;

        if (Input.GetKeyDown(KeyCode.W))
            lastKeyPressed = KeyCode.W;

        if (Input.GetKeyDown(KeyCode.A))
            lastKeyPressed = KeyCode.A;

        if (Input.GetKeyDown(KeyCode.S))
            lastKeyPressed = KeyCode.S;

        if (Input.GetKeyDown(KeyCode.D))
            lastKeyPressed = KeyCode.D;

        if (Input.GetKey(KeyCode.W) && lastKeyPressed == KeyCode.W)
            movement.y = 1;

        if (Input.GetKey(KeyCode.A) && lastKeyPressed == KeyCode.A)
            movement.x = -1;

        if (Input.GetKey(KeyCode.S) && lastKeyPressed == KeyCode.S)
            movement.y = -1;

        if (Input.GetKey(KeyCode.D) && lastKeyPressed == KeyCode.D)
            movement.x = 1;

    }

    // Mientras que Update es llamado una vez por frame, FixedUpdate es llamado una vez por frame en un intervalo de tiempo fijo.
    // Se suele utilizar para los cálculos de físiscas porque inmediatamente después de su llamada los cálculos de físicas son realizados.
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed_ * Time.deltaTime);
        FindObjectOfType<PlayerAnimation>().SetDirection(movement);
    }
}
