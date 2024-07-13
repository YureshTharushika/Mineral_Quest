using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Spawner : MonoBehaviour
{

    public GameObject asteroid;
    public float spawnRate;
    private float timer = 0;
    public float widthOffset = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (Logic.Instance.IsGameOn()) 
            {
                SpawnAsteroid();
                
            }
            timer = 0;
        }
    }

    void SpawnAsteroid()
    {
        float leftMostPoint = transform.position.x - widthOffset;
        float rightMostPoint = transform.position.x + widthOffset;

        GameObject spawnedAsteroid = Instantiate(asteroid, new Vector3(Random.Range(leftMostPoint,rightMostPoint), transform.position.y, transform.position.z), transform.rotation);

        spawnedAsteroid.tag = "Asteroid";
    }
}
