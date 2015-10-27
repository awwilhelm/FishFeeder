using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public GameObject redFood;
    public GameObject blueFood;
    public GameObject defaultFood;
    public GameObject saltGameObject;

    public GameObject GetFoodGameObject(DragAndDrop.ItemType foodType)
    {
        if(foodType == DragAndDrop.ItemType.red)
        {
            return redFood;
        } else if(foodType == DragAndDrop.ItemType.blue)
        {
            return blueFood;
        }
        return defaultFood;
    }
}
