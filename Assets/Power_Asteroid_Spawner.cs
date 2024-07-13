using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Power_Asteroid_Spawner : MonoBehaviour
{

    public GameObject powerAsteroid;
    public float spawnRate;
    private float timer = 0;
    public float widthOffset = 10;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerAsteroid();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (Logic.Instance.IsGameOn()) 
            {
                SpawnPowerAsteroid();
                
            }
            timer = 0;
        }

    }

    void SpawnPowerAsteroid()
    {
        float leftMostPoint = transform.position.x - widthOffset;
        float rightMostPoint = transform.position.x + widthOffset;

        GameObject spawnedPowerAsteroid = Instantiate(powerAsteroid, new Vector3(Random.Range(leftMostPoint, rightMostPoint), transform.position.y, transform.position.z), transform.rotation);

        spawnedPowerAsteroid.tag = "PowerAsteroid";
    }

    
}
