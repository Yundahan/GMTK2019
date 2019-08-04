using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
	public GameObject b1;
	public GameObject b2;
	public GameObject b3;
	
	public GameObject player;
	
	public SpriteRenderer sr;
	
	public Sprite leverDown;
	
	bool leverpulled = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerStay2D(Collider2D col)
	{
		if(leverpulled)
		{
			return;
		}
		if(GameObject.ReferenceEquals(col.gameObject, player) && Input.GetKey(KeyCode.E))
		{
			b1.SendMessage("moveBlock");
			b2.SendMessage("moveBlock");
			b3.SendMessage("moveBlock");
			leverpulled = true;
			sr.sprite = leverDown;
		}
	}
}
