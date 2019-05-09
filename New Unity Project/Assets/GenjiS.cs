using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenjiS : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 force = new Vector2(0, 5);
    Vector2 desp = new Vector2(0.1f, 0);
    Sprite sp;
    public GameObject t; //this
    bool tienePU; //Es para saber si ya recogió el Power Up
    public Sprite pu;
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
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(desp, ForceMode2D.Impulse);

            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-desp, ForceMode2D.Impulse);
            GetComponent<SpriteRenderer>().flipX = true;

        }

    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            tienePU = true;
            GetComponent<SpriteRenderer>().sprite = pu;     
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
