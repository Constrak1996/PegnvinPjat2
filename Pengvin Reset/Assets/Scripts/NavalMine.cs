using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavalMine : MonoBehaviour
{
    public GameObject Mine;

    private float newSpawnRate;

    private float rndY;

    private Vector2 whereToSpawn;

    // The rate at which the objects should be spawned
    public float spawnRate;

    // The value that should be subtracted from the spawnrate at a given time
    public float spawnRateChange;

    // That time that the spawnrate should be changed
    public float spawnRateChangeTime;

    private float nextSpawn = 0.0f;

    private int spriteType;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        newSpawnRate += Time.deltaTime;


        if (Time.time > nextSpawn && Time.time > 30)
        {
            nextSpawn = Time.time + spawnRate;
            rndY = Random.Range(-7f, -1f);
            whereToSpawn = new Vector2(transform.position.x, rndY);

            GameObject gameObject = Instantiate(Mine, whereToSpawn, Quaternion.identity);
        }

        if (newSpawnRate > spawnRateChangeTime && spawnRate > 15)
        {
            spawnRate -= spawnRateChange;
            newSpawnRate = 0;
        }

    }
}
