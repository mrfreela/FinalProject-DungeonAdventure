using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagScript : MonoBehaviour
{

	public int xspeed;
	public int yspeed;
	
    void Start()
    {
        
    }
	
	void moveLeft()
	{
		if(Input.GetKey(KeyCode.A))
		{
			xspeed = 5;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			xspeed = -5;
		}
		else
		{
			xspeed = 0;
		}
	}

    void Update()
    {
        
    }
}
