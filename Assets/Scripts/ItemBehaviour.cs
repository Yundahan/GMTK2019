using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
	public GameObject player;
	
	public GameObject InventoryHandler;
	
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
		if(GameObject.ReferenceEquals(col.gameObject, player) && Input.GetKey(KeyCode.E))
		{
			InventoryHandler.SendMessage("ChangeItem", "sword");
			InventoryHandler.SendMessage("ChangeItem", "sword");
			Destroy(gameObject);
		}
	}
}
