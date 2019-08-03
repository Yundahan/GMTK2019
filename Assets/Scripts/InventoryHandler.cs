using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
	string currItem = "";
	
	public GameObject player;
	
	public SpriteRenderer sr;
	
	public GameObject DisplayMessage;
	
	public Sprite sword;
	
	public bool swordMessage = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currItem)
		{
			case "sword":
				sr.sprite = sword;
				float desiredScale = 0.8f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			default:
				sr.sprite = null;
				break;
		}
    }
	
	void ChangeItem(string itemType)
	{
		currItem = itemType;
		
		switch(currItem)
		{
			case "sword":
				if(!swordMessage)
				{
					DisplayMessage.SendMessage("SwordMessage");
				}
				break;
			default:
				break;
		}
	}
}
