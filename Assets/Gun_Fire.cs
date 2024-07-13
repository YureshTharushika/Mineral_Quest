using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Fire : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Shoot();
        //}

        //if (timer < Logic.Instance.fireRate)
        //{
        //    timer = timer + Time.deltaTime;
        //}
        //else
        //{
        //    if (Logic.Instance.IsGameOn())
        //    {
        //        Shoot();

        //    }
        //    timer = 0;
        //}

        if (Logic.Instance.IsGameOn())
        {
            timer += Time.deltaTime;

            // Calculate the time interval based on the fire rate
            float timeInterval = 1f / Logic.Instance.fireRate;

            // Check if the timer exceeds the time interval
            if (timer >= timeInterval)
            {
                Shoot();
                timer = 0f; // Reset the timer after shooting
            }
        }


    }

    void Shoot()
    {
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Instantiate a bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

        // Rotate the bullet according to the gun's rotation (and adjust 90 degrees)
        bullet.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90f);

    }

    
}
