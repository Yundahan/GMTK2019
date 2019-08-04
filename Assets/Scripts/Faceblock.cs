using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faceblock : MonoBehaviour
{
	bool move = false;
	
	float origY;
	
    // Start is called before the first frame update
    void Start()
    {
        origY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(move && origY - 3 < transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, 0);
		}
    }
	
	public void moveBlock()
	{
		move = true;
	}
}
