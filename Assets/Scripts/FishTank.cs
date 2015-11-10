using UnityEngine;
using System.Collections;

public class FishTank : MonoBehaviour {

    
    public GameObject[] connection;
    private FishTank[] fishTankScript;
    private BoxCollider2D boxCollider2D;
    private SpriteManager spriteManagerScript;

    public DragAndDrop.ItemType tankFoodType;
    public DragAndDrop.ItemType tankFishType;
    public DragAndDrop.FilterType tankFilterType;
    public DragAndDrop.SaltType tankSalt;

    public DragAndDrop.ItemType foodTypeSeed;
    public DragAndDrop.SaltType saltTypeSeed;



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


    public void ChangesBox(Vector3 mousePos, DragAndDrop.ItemType foodType, DragAndDrop.ItemType fishType, DragAndDrop.FilterType filterType, DragAndDrop.SaltType saltType)
    {
        if (IsMouseOverBox(mousePos))
        {
            foodTypeSeed = foodType;
            saltTypeSeed = saltType;
            if (foodType != DragAndDrop.ItemType.none)
            {
                tankFoodType = foodType;
            } else if (fishType != DragAndDrop.ItemType.none)
            {
                tankFishType = fishType;
            } else if(saltType != DragAndDrop.SaltType.none)
            {
                tankSalt = saltType;
            }
            FlowableObjects(tankFoodType, tankSalt);
        }
    }

    public void FlowableObjects(DragAndDrop.ItemType foodType, DragAndDrop.SaltType saltType)
    {
        tankFoodType = foodType;
        tankSalt = saltType;

        if(foodTypeSeed != DragAndDrop.ItemType.none)
        {
            tankFoodType = foodTypeSeed;
        }
        if(saltTypeSeed != DragAndDrop.SaltType.none)
        {
            tankSalt = saltTypeSeed;
        }

        if (saltType != DragAndDrop.SaltType.hasSalt)
        {
            GetComponent<SpriteRenderer>().sprite = spriteManagerScript.GetSpriteFoodType(tankFoodType);
        }

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

    public DragAndDrop.ItemType GetTankFood()
    {
        return tankFoodType;
    }

    public DragAndDrop.SaltType GetTankSalt()
    {
        return tankSalt;
    }
}
