using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenjiS : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 force = new Vector2(0, 5);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (rb)
            {
                rb.AddForce(force,ForceMode2D.Impulse);
            }
        }
    }
}
