using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private bool a,b = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
		{
		 a = true;
		}
		if(Input.GetKeyUp(KeyCode.D))
		{
		 a = false;
		}
	 if(a)
		{
			Debug.Log("D key was pressed.");
			transform.Translate(Vector2.right * Time.deltaTime);
		}
	 if(Input.GetKeyDown(KeyCode.A))
		{
		 b = true;
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
		 b = false;
		}
		if(b)
		{
			Debug.Log("A key was pressed.");
			transform.Translate(Vector2.left * Time.deltaTime);
		}
    }
}
