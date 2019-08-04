using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoomer : MonoBehaviour
{
	public GameObject player;
	
	public CameraController camcon;
	
	public bool zoomOutOnRight;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(GameObject.ReferenceEquals(col.gameObject, player))
		{
			if(zoomOutOnRight)
			{
				if(player.transform.position.x > transform.position.x)
				{
					camcon.zoomOut = true;
				}
				else{
					camcon.zoomOut = false;
				}
			}
			else{
				if(player.transform.position.x > transform.position.x)
				{
					camcon.zoomOut = false;
				}
				else{
					camcon.zoomOut = true;
				}
			}
		}
	}
}
