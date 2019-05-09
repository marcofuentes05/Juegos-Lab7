using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenjiS : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 force = new Vector2(0, 5);
    Vector2 desp = new Vector2(1, 0);
    Sprite sp;
    public GameObject t; //this
    bool tienePU; //Es para saber si ya recogió el Power Up
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
            rb.AddForce(force, ForceMode2D.Impulse);
        }
        
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(desp, ForceMode2D.Impulse);
            
            GetComponent<SpriteRenderer>().flipX=false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-desp, ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            tienePU = true;
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (tienePU)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(t);
            }
        }
    }
}
