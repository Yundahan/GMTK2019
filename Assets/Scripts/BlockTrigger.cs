using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
	public GameObject faceblock;
	
	public GameObject player;
	
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
			faceblock.SendMessage("moveBlock");
		}
	}
}
