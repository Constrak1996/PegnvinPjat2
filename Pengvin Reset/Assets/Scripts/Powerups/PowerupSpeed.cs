using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpeed : MonoBehaviour
{
    public GameObject speedPrefab;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedWave());
    }

    private void SpawnSpeed()
    {
        GameObject s = Instantiate(speedPrefab) as GameObject;
        s.transform.position = new Vector2(20, Random.Range(-5, 3));
    }

    IEnumerator SpeedWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnSpeed();
        }
    }
}
