using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDroppedAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void getDroppedAt(Vector2 param)
	{
		transform.position = new Vector3(param.x, param.y, 0);
	}
}
