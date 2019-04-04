using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawn : MonoBehaviour
{
    public Transform explosion;

    // Start is called before the first frame update
    void Start()
    {
        explosion.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            explosion.GetComponent<ParticleSystem>().Play();
        }        
    }

    IEnumerable stopExplosion()
    {
        yield return new WaitForSeconds(0.4f);
    }
}
