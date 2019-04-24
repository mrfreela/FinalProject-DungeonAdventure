using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
	Rigidbody2D selfBody;
	public float speed = 4.0f;
	public float horizontal = 0.0f;
	public float vertical = 0.0f;
	public int slimeHealth = 20;
	private bool isHit = false;
	private int count = 0;
	public AudioClip slimeDeath;
	public AudioClip slimeHurt;
	public AudioSource audio;
	
	
    // Start is called before the first frame update
    void Start()
    {
        selfBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		
		if (isHit == true)
		{
			slimeHealth = slimeHealth - 1;
			audio.clip = slimeHurt;
			audio.Play();			
			while (count < 20)
	   		{	
	   			count = count + 1;
	   		}
			isHit = false;
			count = 0;
		}
		
		if (slimeHealth <= 0)
		{	
			
			gameObject.SetActive(false);
			
		}
       
    }
	
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "LeftWall")
		{
			horizontal = 1;
		}
		if (collision.gameObject.tag == "RightWall")
		{
			horizontal = -1;
		}
		if (collision.gameObject.tag == "UpperWall")
		{
			vertical = -1;
		}
		if (collision.gameObject.tag == "LowerWall")
		{
			vertical = 1;
		}
		if (collision.gameObject.tag == "Slime")
		{
			horizontal = horizontal * -1;
			vertical = vertical * -1;
		}
		if (collision.gameObject.name == "SwordSprite_0" || collision.gameObject.name == "SwordSprite_1" || collision.gameObject.name == "SwordSprite_2" || collision.gameObject.name == "SwordSprite_3")
		{
			isHit = true;
		}
	}
	
	private void FixedUpdate()
	{
		selfBody.velocity = new Vector2(horizontal * speed, vertical * speed);
	}
}
