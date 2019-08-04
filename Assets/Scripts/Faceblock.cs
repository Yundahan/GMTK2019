using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faceblock : MonoBehaviour
{
	bool move = false;
	
	float origY;
	
	public float jumpY;
	public float moveY;
	
	public float speed;
	
	bool jumpDone = false;
	
    // Start is called before the first frame update
    void Start()
    {
        origY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if(move && !jumpDone)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + jumpY, 0);
			jumpDone = true;
		}
		if(move && origY + moveY + jumpY < transform.position.y && speed < 0)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
		}
		if(move && origY + moveY + jumpY > transform.position.y && speed > 0)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
		}
    }
	
	public void moveBlock()
	{
		move = true;
	}
}
