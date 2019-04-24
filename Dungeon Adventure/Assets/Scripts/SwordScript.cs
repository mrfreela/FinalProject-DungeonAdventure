using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{

	public GameObject protag;
	private ProtagScript protagscript;
	private bool isUp = false;
	private bool isDown = false;
	private bool isRight = false;
	private bool isLeft = false;
	
    // Start is called before the first frame update
    void Start()
    {
		isDown = true;
	}

    // Update is called once per frame
    void Update()
    {	
		if (isUp == true)
			transform.position = new Vector2(protag.transform.position.x,protag.transform.position.y + 1);

		if (isDown == true)
			transform.position = new Vector2(protag.transform.position.x,protag.transform.position.y - 1);

		if (isLeft == true)
			transform.position = new Vector2(protag.transform.position.x - 1,protag.transform.position.y);

		if (isRight == true)
			transform.position = new Vector2(protag.transform.position.x + 1,protag.transform.position.y);


        if (Input.GetKeyDown("up"))
        	{
			isUp = true;
			isDown = false;
			isRight = false;
			isLeft = false;
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
			gameObject.transform.GetChild(2).gameObject.SetActive(false);
			gameObject.transform.GetChild(3).gameObject.SetActive(false);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown("down"))
        {
			isUp = false;
			isDown = true;
			isRight = false;
			isLeft = false;
			gameObject.transform.GetChild(3).gameObject.SetActive(true);
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
			gameObject.transform.GetChild(2).gameObject.SetActive(false);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown("left"))
        {
			isUp = false;
			isDown = false;
			isRight = false;
			isLeft = true;
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
			gameObject.transform.GetChild(2).gameObject.SetActive(false);
			gameObject.transform.GetChild(3).gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown("right"))
        {
			isUp = false;
			isDown = false;
			isRight = true;
			isLeft = false;
			gameObject.transform.GetChild(2).gameObject.SetActive(true);
			gameObject.transform.GetChild(3).gameObject.SetActive(false);
			gameObject.transform.GetChild(1).gameObject.SetActive(false);
			gameObject.transform.GetChild(0).gameObject.SetActive(false);
		}

    }
}
