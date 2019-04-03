using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScrapFish")
        {
            Destroy(this.gameObject);
        }
    }
}
