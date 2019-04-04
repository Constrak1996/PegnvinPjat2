using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixPackTrashMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (transform.position.x <= -12)
            {
                Destroy(gameObject);
            }
        }
    }
}
