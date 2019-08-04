﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour3 : MonoBehaviour
{
	bool right = false;
	
	public GameObject player;
	public Movement move;
	
	public GameObject DisplayMessage;
	
	public GameObject CameraController;
	
	Vector3 rightV;
	Vector3 leftV;
	Vector3 apex;
	
	float jumpTime;
	
	public Animator animator;
	
	bool dead = false;
	float time;
	
    // Start is called before the first frame update
    void Start()
    {
        rightV = transform.position;
		leftV = new Vector3(rightV.x - 3.0f, rightV.y, 0);
		apex = new Vector3 (rightV.x - 1.5f, rightV.y + 2.25f, 0);
		jumpTime = Time.time;
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
		if(Time.time - jumpTime < 2.0f)
		{
			return;
		}
		float x = transform.position.x - apex.x;
		if(right)
		{
			x += 0.05f;
			transform.position = new Vector3(transform.position.x + 0.05f, apex.y - x * x, 0);
		}
		else{
			x -= 0.05f;
			transform.position = new Vector3(transform.position.x - 0.05f, apex.y - x * x, 0);
		}
		if(transform.position.y < rightV.y)
		{
			transform.position = new Vector3(transform.position.x, rightV.y, 0);
		}
		if(transform.position.y <= rightV.y)
		{
			right = !right;
			jumpTime = Time.time;
			return;
		}
    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(!GameObject.ReferenceEquals(col.gameObject, player))
		{
			return;
		}
		if(move.ibility)
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
			if(player.transform.position.y - transform.position.y >= 0.8f)
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