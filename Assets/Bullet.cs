using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public float deadZoneX1 = -12;
    public float deadZoneX2 = 12;
    public float deadZoneY1 = -7;
    public float deadZoneY2 = 7;

    public int damageAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < deadZoneX1 || transform.position.x > deadZoneX2 || transform.position.y < deadZoneY1 || transform.position.y > deadZoneY2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            
            if (asteroid != null)
            {
                asteroid.TakeDamage(damageAmount);
            }
        } 
        
        if (collision.gameObject.CompareTag("PowerAsteroid"))
        {
            PowerAsteroid powerAsteroid = collision.gameObject.GetComponent<PowerAsteroid>();

            if (powerAsteroid != null)
            {
                powerAsteroid.TakeDamage(damageAmount);
            }
        }
            
        Destroy (gameObject);
    }
}
