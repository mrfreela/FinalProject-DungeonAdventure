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
	public int ProtagHealth = 10;
	private AudioSource playerHurt;
    private string direction = "down";

	
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

        //-----------------------------------------

        if (Input.GetKeyDown("up"))
        {

            direction = "up";

        }
        if (Input.GetKeyDown("down"))
        {

            direction = "down";

        }
        if (Input.GetKeyDown("right"))
        {

            direction = "right";

        }
        if (Input.GetKeyDown("left"))
        {

            direction = "left";

        }

        //-----------------------------------------
        print(direction);

        if (direction == "up")
        {
            selfAnimator.SetBool("WalkUp", true);
            selfAnimator.SetBool("WalkDown", false);
            selfAnimator.SetBool("WalkRight", false);
            selfAnimator.SetBool("WalkLeft", false);
        }
        else if (direction == "down")
        {
            selfAnimator.SetBool("WalkDown", true);
            selfAnimator.SetBool("WalkUp", false);
            selfAnimator.SetBool("WalkRight", false);
            selfAnimator.SetBool("WalkLeft", false);
        }
        else if (direction == "left")
        {
            selfAnimator.SetBool("WalkLeft", true);
            selfAnimator.SetBool("WalkDown", false);
            selfAnimator.SetBool("WalkRight", false);
            selfAnimator.SetBool("WalkUp", false);
        }
        else if (direction == "right")
        {
            selfAnimator.SetBool("WalkRight", true);
            selfAnimator.SetBool("WalkDown", false);
            selfAnimator.SetBool("WalkUp", false);
            selfAnimator.SetBool("WalkLeft", false);
        }

        if (ProtagHealth <= 0)
        {
            gameObject.SetActive(false);
        }

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
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Slime")
		{
			ProtagHealth = ProtagHealth - 1;	
			playerHurt.Play();	
		}
	}
	
	
}
