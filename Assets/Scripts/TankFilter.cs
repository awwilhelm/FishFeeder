using UnityEngine;
using System.Collections;

public class TankFilter : MonoBehaviour {

    public bool foodFilter;
    public bool saltFilter;
    public GameObject[] connection;
    private FishTank fishTankScript;

    // Use this for initialization
    void Start()
    {
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void ClearFishFood(DragAndDrop.ItemType foodType, bool hasSalt)
    {
        if(foodFilter)
        {
            foodType = DragAndDrop.ItemType.none;
        }
        if(saltFilter)
        {
            hasSalt = false;
        }

        if (connection.Length > 0)
        {
            for (int i = 0; i < connection.Length; i++)
            {
                if (connection[i].GetComponent<FishTank>() != null)
                {
                    connection[i].GetComponent<FishTank>().SetFishFood(foodType, hasSalt);
                }
                else
                {
                    print("ERROR: One of your gameobjects does not have a fishTankScript attached");
                }
            }
        }

    }
}
