using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    float randY;
    Vector3 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0;
    float enemNum = 0;
    int randTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
<<<<<<< HEAD
        
=======
        if(Time.time > nextSpawn && enemNum < 5)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-25f, 25f);

            

            whereToSpawn = new Vector3(randX, 25, -1);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            enemNum = enemNum + 1;
            randTime = Random.Range(1, 12);
        }
>>>>>>> ddef0b811d582d22ec5e2292def9634dd2ac9f2f

    }
}
