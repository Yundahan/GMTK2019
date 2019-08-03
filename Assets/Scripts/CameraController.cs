using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	
	public bool cameraMoves = true;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		if(cameraMoves)
		{
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
		}
    }
	
	void setCameraMovement(bool value)
	{
		cameraMoves = value;
	}
}
