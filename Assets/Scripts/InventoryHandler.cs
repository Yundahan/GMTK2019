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
	public Sprite dashThing;
	public Sprite gravityThing;
	public Sprite coin;
	public Sprite clover;
	
	public bool swordMessage = false;
	public bool jumpMessage = false;
	public bool dashMessage = false;
	public bool gravityMessage = false;
	public bool invincibilityMessage = false;
	public bool victoryMessage = false;
	
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
			case "dash enabler":
				image.sprite = dashThing;
				desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			case "gravity enabler":
				image.sprite = gravityThing;
				desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			case "invincibility enabler":
				image.sprite = coin;
				desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			case "victory enabler":
				image.sprite = clover;
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
					swordMessage = true;
				}
				break;
			case "jump enabler":
				if(!jumpMessage)
				{
					DisplayMessage.SendMessage("JumpMessage");
					jumpMessage = true;
				}
				break;
			case "dash enabler":
				if(!dashMessage)
				{
					DisplayMessage.SendMessage("DashMessage");
					dashMessage = true;
				}
				break;
			case "gravity enabler":
				if(!gravityMessage)
				{
					DisplayMessage.SendMessage("GravityMessage");
					gravityMessage = true;
				}
				break;
			case "invincibility enabler":
				if(!invincibilityMessage)
				{
					DisplayMessage.SendMessage("InvincibilityMessage");
					invincibilityMessage = true;
				}
				break;
			case "victory enabler":
				if(!victoryMessage)
				{
					DisplayMessage.SendMessage("VictoryMessage");
					victoryMessage = true;
				}
				break;
			default:
				break;
		}
	}
}