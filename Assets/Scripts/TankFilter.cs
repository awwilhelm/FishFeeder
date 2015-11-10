using UnityEngine;
using System.Collections;

public class TankFilter : MonoBehaviour {

    public DragAndDrop.FilterType filter;
    public bool saltFilter;
    public GameObject[] connection;
    private World worldScript;
    private BoxCollider2D boxCollider2D;
    private SpriteManager spriteManagerScript;


    // Use this for initialization
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        worldScript = GameObject.Find("Canvas").GetComponent<World>();
        spriteManagerScript = GameObject.Find("Canvas").GetComponent<SpriteManager>();
    }
	// Update is called once per frame
	void Update () {
	
	}


    public void ChangesFilterBox(Vector3 mousePos, DragAndDrop.ItemType foodType, DragAndDrop.ItemType fishType, DragAndDrop.FilterType filterType, DragAndDrop.SaltType saltType)
    {
        if (IsMouseOverBox(mousePos))
        {
            filter = filterType;


            GetComponent<SpriteRenderer>().sprite = spriteManagerScript.GetSpriteFilterType(filterType);
            

            for (int i = 0; i < connection.Length; i++)
            {
                FishTank tempTank = connection[i].GetComponent<FishTank>();
                foodType = tempTank.GetTankFood();
                saltType = tempTank.GetTankSalt();

                if(filter == DragAndDrop.FilterType.food)
                {
                    foodType = DragAndDrop.ItemType.none;
                } else if(filter == DragAndDrop.FilterType.salt)
                {
                    saltType = DragAndDrop.SaltType.none;
                }

                tempTank.FlowableObjects(foodType, saltType);
            }

        }
    }
    public void FlowableFilterObjects(DragAndDrop.ItemType foodType, DragAndDrop.SaltType saltType)
    {
        if (filter == DragAndDrop.FilterType.food)
        {
            foodType = DragAndDrop.ItemType.none;
        } else if (filter == DragAndDrop.FilterType.salt)
        {
            saltType = DragAndDrop.SaltType.doesNotHaveSalt;
        }
        
        for (int i = 0; i < connection.Length; i++)
        {
            connection[i].GetComponent<FishTank>().FlowableObjects(foodType, saltType);
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

    public void SetFoodFilter(DragAndDrop.ItemType foodFilterType)
    {
        if (filter == DragAndDrop.FilterType.food)
        {
            foodFilterType = DragAndDrop.ItemType.none;
        }
    }

    public void SetSaltFilter(DragAndDrop.ItemType saltFilterType)
    {
        if (filter == DragAndDrop.FilterType.salt)
        {
            saltFilterType = DragAndDrop.ItemType.none;
        }
    }



}
