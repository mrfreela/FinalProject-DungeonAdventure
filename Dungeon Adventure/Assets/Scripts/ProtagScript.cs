using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagScript : MonoBehaviour
{
	
	Rigidbody2D selfBody;
	float horizontal;
	float vertical;
	float moveLimiter = 0.7f;
	public float speed = 5.0f;
	
    void Start()
    {
        selfBody = GetComponent<Rigidbody2D>();
    }
	
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
   		vertical = Input.GetAxisRaw("Vertical");
    }
	
	private void FixedUpdate()
	{
		if (horizontal != 0 && vertical != 0) // Check for diagonal movement
   		{
     		 // limit movement speed diagonally, so you move at 70% speed
      		horizontal *= moveLimiter;
      		vertical *= moveLimiter;
   		}

   		selfBody.velocity = new Vector2(horizontal * speed, vertical * speed);
	}
}
