using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public GameObject obstacle;

    private float rndY;

    private Vector2 whereToSpawn;

    // The rate at which the objects should be spawned
    public float spawnRate;

    // The value that should be subtracted from the spawnrate at a given time
    public float spawnRateChange;

    // That time that the spawnrate should be changed
    public float spawnRateChangeTime;

    private float newSpawnRate;

    private float nextSpawn = 0.0f;

    private int spriteType;

    private SpriteRenderer spriteRenderer;

    public Sprite[] obstacles = new Sprite[5];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        newSpawnRate += Time.deltaTime;

        if (Time.time > nextSpawn && Time.time > 14)
        {
            nextSpawn = Time.time + spawnRate;
            rndY = Random.Range(-7f, -1f);
            whereToSpawn = new Vector2(transform.position.x, rndY);

            GameObject gameObject = Instantiate(obstacle, whereToSpawn, Quaternion.identity);
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteType = Random.Range(0, 5);
            spriteRenderer.sprite = obstacles[spriteType];
        }

        if (newSpawnRate > spawnRateChangeTime && spawnRate > 5)
        {
            spawnRate -= spawnRateChange;
            newSpawnRate = 0;
        }

    }
}
