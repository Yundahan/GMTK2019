using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
	string currItem = "";
	
	float desiredScale = 1.0f;
	
	public GameObject DisplayMessage;
	
	public Image image;
	
	public Sprite sword;
	public Sprite jumpThing;
	
	public bool swordMessage = false;
	public bool jumpMessage = false;
	
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currItem)
		{
			case "fight enabler":
				image.sprite = sword;
				desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			case "jump enabler":
				image.sprite = jumpThing;
				desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			default:
				image.sprite = null;
				break;
		}
    }
	
	void ChangeItem(string itemType)
	{
		image.enabled = true;
		currItem = itemType;
		
		switch(currItem)
		{
			case "fight enabler":
				if(!swordMessage)
				{
					DisplayMessage.SendMessage("SwordMessage");
				}
				break;
			case "jump enabler":
				if(!jumpMessage)
				{
					DisplayMessage.SendMessage("JumpMessage");
				}
				break;
			default:
				break;
		}
	}
}