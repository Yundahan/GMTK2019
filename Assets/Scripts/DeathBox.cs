using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
	public GameObject player;
	
	public GameObject DisplayMessage;
	
	public GameObject CameraController;
	
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
			DisplayMessage.SendMessage("DeathMessage");
			CameraController.SendMessage("setCameraMovement", false);
		}
	}
}
