using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAsteroid : MonoBehaviour
{

    public float moveSpeed;
    public float deadZone = -7;

    public float health = 100;

    public Logic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        logic.AddEnergy(5);
        Destroy(gameObject);
    }
}
