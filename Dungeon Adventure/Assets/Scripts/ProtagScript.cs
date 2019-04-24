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
	private Animator selfAnimator;
	private int isheld = 0;
	private int count = 0;
	public GameObject Sword;
	public int ProtagHealth = 30;
	private AudioSource playerHurt;

	
    void Start()
    {
		selfAnimator = GetComponent<Animator>();
        selfBody = GetComponent<Rigidbody2D>();
		playerHurt = GetComponent<AudioSource>();
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
		
		PlayerMovementAnim();	
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Slime")
		{
			ProtagHealth = ProtagHealth - 1;	
			playerHurt.Play();	
		}
	}
	
	void PlayerMovementAnim()
	{
		if (Input.GetKeyDown("up")) //check for downward input
		{		
			selfAnimator.SetTrigger("WalkUp");	
		}

		
		if (Input.GetKeyDown("down")) //check for upward input
		{		
			selfAnimator.SetTrigger("WalkDown");	
		}

		
		if (Input.GetKeyDown("right")) //check for leftward input
		{		
			selfAnimator.SetTrigger("WalkRight");	
		}

		
		if (Input.GetKeyDown("left")) //check for rightward input
		{	
			selfAnimator.SetTrigger("WalkLeft");		
		}
	}
	
}
