using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    private int spawnTimer = 0;
    [Header("toSpawn")]
    public GameObject octopus;
    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer++;

        if (spawnTimer >= 100)
        {

            int choose = Random.Range(0, 2);
            if (choose == 0)
            {
                GameObject newObject = Instantiate(octopus);

            }
            else
            {

                GameObject newObject = Instantiate(fish);

            }
            spawnTimer = 0;

        }
    }
}
