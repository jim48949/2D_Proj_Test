using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D rb2d;
    Vector2 movementVec;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementVec.x = Input.GetAxisRaw("Horizontal");
        movementVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movementVec * movementSpeed * Time.fixedDeltaTime);
    }
}
