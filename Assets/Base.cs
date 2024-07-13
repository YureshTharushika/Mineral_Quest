using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public Rigidbody2D rigidBody;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public float moveSpeed;

    float minX;
    float maxX;
    float minY;
    float maxY;

    // Start is called before the first frame update
    void Start()
    {
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Logic.Instance.IsGameOn())
        {
            MoveBase();
        }
        else
        {
            StopBase();
        }
        
    }


    public void MoveBase()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.zero;
        Vector2 position = (Vector2)transform.position;

        if (horizontalMove == 1 && position.x < maxX)
        {
            movement += Vector2.right;
        }
        else if (horizontalMove == -1 && position.x > minX)
        {
            movement += Vector2.left;
        }

        if (verticalMove == 1 && position.y < maxY)
        {
            movement += Vector2.up;
        }
        else if (verticalMove == -1 && position.y > minY)
        {
            movement += Vector2.down;
        }

        rigidBody.velocity = movement.normalized * moveSpeed;


    }

    public void StopBase()
    {
        // Stop the base movement by setting input to zero
        horizontalMove = 0f;
        verticalMove = 0f;
        rigidBody.velocity = Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        Logic.Instance.DecreaseHealth(damage);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            //Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            
            TakeDamage(25);
            
        }

        if (collision.gameObject.CompareTag("PowerAsteroid"))
        {
            //PowerAsteroid powerAsteroid = collision.gameObject.GetComponent<PowerAsteroid>();

            TakeDamage(50);
        }
    }
}
