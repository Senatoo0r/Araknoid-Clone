    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public float speed = 150;
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        return (ballPos.x - racketPos.x) / racketWidth;
    }
    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Racket")
        {
            float x = hitFactor(transform.position,
                col.transform.position,
                col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }


    }
    // Update is called once per frame

    void Update()
    {

    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
}