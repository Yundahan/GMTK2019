using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	
	public bool cameraMoves = true;
	
	public bool zoomOut = false;
	
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
		
		if(!zoomOut && Camera.main.orthographicSize > 5)
		{
			Camera.main.orthographicSize -= 0.05f;
		}
		if(zoomOut && Camera.main.orthographicSize < 8)
		{
			Camera.main.orthographicSize += 0.05f;
		}
    }
	
	void setCameraMovement(bool value)
	{
		cameraMoves = value;
	}
}
