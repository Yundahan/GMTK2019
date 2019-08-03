using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	Vector3 offset = new Vector3(0.0f, 0.0f, 0.0f);
	
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f);
		offset = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, 0.0f) - offset;
    }
}
