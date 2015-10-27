using UnityEngine;
using System.Collections;

public class FishTank : MonoBehaviour {

    
    public GameObject[] connection;
    public GameObject redFood;
    public GameObject blueFood;
    private FishTank[] fishTankScript;
    public bool waterHasSalt;
    private BoxCollider2D boxCollider2D;


    

    public DragAndDrop.ItemType food;
	// Use this for initialization
	void Start ()
    {
        food = DragAndDrop.ItemType.none;
        boxCollider2D = GetComponent<BoxCollider2D>();
        waterHasSalt = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(previousFood != food)
        //{
        //    previousFood = food;
        //    SetFishFood(food);
        //}
	}

    public void SetFishFood(DragAndDrop.ItemType foodType, bool hasSalt)
    {
        food = foodType;
        waterHasSalt = hasSalt;

        GetComponent<SpriteRenderer>().sprite = transform.parent.GetComponent<FishTankManager>().GetSpriteFoodType(foodType);
        //Instantiate(redFood, mousePos, Quaternion.identity);
        DefineConnections();
    }

    public void DefineConnections()
    {
        fishTankScript = new FishTank[connection.Length];
        if (connection.Length > 0)
        {
            for (int i = 0; i < connection.Length; i++)
            {
                if (connection[i].GetComponent<TankFilter>() != null)
                {
                    connection[i].GetComponent<TankFilter>().ClearFishFood(food, waterHasSalt);
                }
                else
                {
                    print("ERROR: One of your gameobjects does not have a tankFilterScript attached");
                }
            }
        }
    }

    public void ChangesBox(Vector3 mousePos, DragAndDrop.ItemType foodType, bool hasSalt)
    {
        if(IsMouseOverBox(mousePos))
        {
            SetFishFood(foodType, hasSalt);
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
}
