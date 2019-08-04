using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour2 : MonoBehaviour
{
	bool right = false;
	
	public GameObject player;
	public Movement move;
	public AudioSource pop;
	public GameObject DisplayMessage;
	
	public GameObject CameraController;
	
	public Vector3 leftV;
	public Vector3 rightV;
	private Vector3 dir = new Vector3(0, 0, 0);

	public Animator animator;
	
	bool dead = false;
	float time;
	
    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(rightV.x - leftV.x, rightV.y - leftV.y, 0.0f);
		dir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	void FixedUpdate()
	
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
			if(right && (transform.position.x < rightV.x || transform.position.y < rightV.y))
			{
				transform.position += dir * 0.03f;
			}
			else if(right)
			{
				right = false;
				float x = transform.localScale.x * -1;
				transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
			}
			else if(!right && (transform.position.x > leftV.x || transform.position.y > leftV.y))
			{
				transform.position -= dir * 0.03f;
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
			move.ded=true;
			CameraController.SendMessage("setCameraMovement", false);
		}
		
		else{
			if(player.transform.position.y - transform.position.y >= 0.8f)
			{
				pop.Play();
				dead = true;
				animator.SetBool("dead", true);
				time = Time.time;
				move.controller.m_Grounded = true;
				move.controller.m_Rigidbody2D.velocity = Vector2.zero;
				Physics2D.gravity = new Vector2(0, -14.7f);
				move.controller.Move(move.hmove * Time.fixedDeltaTime, false, true);
				Physics2D.gravity = new Vector2(0, -9.8f);
			}
			else{
				DisplayMessage.SendMessage("DeathMessage");
				move.ded=true;
				CameraController.SendMessage("setCameraMovement", false);
			}
		}
	}
}
