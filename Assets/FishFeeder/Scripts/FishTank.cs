using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FishTank : MonoBehaviour {

    
    public GameObject[] connection;
    private FishTank[] fishTankScript;
    private BoxCollider2D boxCollider2D;
    private SpriteManager spriteManagerScript;

    public List<DragAndDrop.ItemType> tankFoodType = new List<DragAndDrop.ItemType>();       //DragAndDrop.ItemType
    public DragAndDrop.FishType tankFishType;
    public DragAndDrop.FilterType tankFilterType;
    public bool tankSalt;

    public List<DragAndDrop.ItemType> foodTypeSeed = new List<DragAndDrop.ItemType>();       //TODO: Turn into array
    public bool saltTypeSeed;



    public enum Type
    {
        food,
        salt,
        fish,
        filter
    }
	// Use this for initialization
	void Start ()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteManagerScript = GameObject.Find("Canvas").GetComponent<SpriteManager>();
	}


    public void ChangesBox(Vector3 mousePos, DragAndDrop.ItemType foodType, DragAndDrop.FilterType filterType, bool saltType)
    {
        if (IsMouseOverBox(mousePos))
        {
            foodTypeSeed.Add(foodType);
            saltTypeSeed = saltType;
            if (foodType != DragAndDrop.ItemType.none)
            {
                if(!tankFoodType.Contains(foodType))
                {
                    tankFoodType.Add(foodType);
                }
            }  else if(saltType)
            {
                tankSalt = saltType;
            }
            FlowableObjects(tankFoodType, tankSalt);

            //else if (fishType != DragAndDrop.ItemType.none)
            //{
            //    tankFishType = fishType;
            //}
        }
    }

    public void AddFish(Vector3 mousePos, DragAndDrop.FishType fishType, bool saltType)
    {
        if (IsMouseOverBox(mousePos))
        {
            Transform fishPos = transform.FindChild("FishPosition");
            tankFishType = fishType;

            fishPos.transform.localScale = new Vector3(fishPos.GetComponent<BoxCollider2D>().size.x - fishPos.transform.localScale.x, fishPos.GetComponent<BoxCollider2D>().size.y - fishPos.transform.localScale.y, 1);
            transform.FindChild("FishPosition").GetComponent<SpriteRenderer>().sprite = spriteManagerScript.GetSpriteFishType(fishType);
        }
    }

    public void FlowableObjects(List<DragAndDrop.ItemType> foodType, bool saltType)
    {
        tankFoodType = foodType;
        tankSalt = saltType;

        for(int i = 0; i<foodTypeSeed.Count; i++)
        {
            if (foodTypeSeed[i] != DragAndDrop.ItemType.none)
            {
                if(!tankFoodType.Contains(foodTypeSeed[i]))
                {
                    tankFoodType.Add(foodTypeSeed[i]);
                }
            }
        }

        if(saltTypeSeed)
        {
            tankSalt = saltTypeSeed;
        }

        transform.FindChild("FoodPosition").GetComponent<SpriteRenderer>().sprite = spriteManagerScript.GetSpriteFoodType(tankFoodType);

        for(int i = 0; i < connection.Length; i++)
        {
            connection[i].GetComponent<TankFilter>().FlowableFilterObjects(tankFoodType, tankSalt);
        }
    }

    private bool IsMouseOverBox(Vector3 mousePos3D)
    {
        Vector2 boxColliderPos2D = new Vector2(boxCollider2D.transform.position.x, boxCollider2D.transform.position.y);
        Vector2 boxColliderSize2D = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y);
        Vector3 mouse3D = Camera.main.ScreenToWorldPoint(mousePos3D);
        Vector2 mousePosition = new Vector2(mouse3D.x, mouse3D.y);

        Rect bounds = new Rect(boxColliderPos2D.x - (boxColliderSize2D.x / 2), boxColliderPos2D.y - (boxColliderSize2D.y / 2), boxColliderSize2D.x, boxColliderSize2D.y);

        return bounds.Contains(mousePosition);
    }

    public List<DragAndDrop.ItemType> GetTankFoodType()
    {
        return tankFoodType;
    }

    public bool GetTankSalt()
    {
        return tankSalt;
    }

    public DragAndDrop.FishType getTankFishType()
    {
        return tankFishType;
    }

    public GameObject[] GetConnections()
    {
        return connection;
    }
    
}
