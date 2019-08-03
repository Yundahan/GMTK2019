using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour1 : MonoBehaviour
{
	bool right = false;
	
	public GameObject player;
	public Movement move;
	
	public GameObject DisplayMessage;
	
	public GameObject CameraController;
	
	public float leftX;
	public float rightX;
	
	public Animator animator;
	
	bool dead = false;
	float time;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Time.time - time >= 1.0f && dead)
		{
			Destroy(gameObject);
			return;
		}
		if(dead)
		{
			return;
		}
        if(right && transform.position.x < rightX)
		{
			transform.position += new Vector3(0.03f, 0, 0);
		}
		else if(right)
		{
			right = false;
			float x = transform.localScale.x * -1;
			transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
		}
		else if(!right && transform.position.x > leftX)
		{
			transform.position += new Vector3(-0.03f, 0, 0);
		}
		else if(!right)
		{
			right = true;
			float x = transform.localScale.x * -1;
			transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
		}
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(!GameObject.ReferenceEquals(col.gameObject, player))
		{
			return;
		}
		if(dead)
		{
			return;
		}
		if(!move.fighting)
		{
			DisplayMessage.SendMessage("DeathMessage");
			CameraController.SendMessage("setCameraMovement", false);
		}
		else{
			if(player.transform.position.y - transform.position.y >= 1.3f)
			{
				dead = true;
				animator.SetBool("dead", true);
				time = Time.time;
			}
			else{
				DisplayMessage.SendMessage("DeathMessage");
				CameraController.SendMessage("setCameraMovement", false);
			}
		}
	}
}
