using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public GameObject redFood;
    public GameObject blueFood;
    public GameObject defaultFood;
    public GameObject saltGameObject;
    public GameObject foodFilterGameObject;
    public GameObject saltFilterGameObject;

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
    
    public GameObject GetSaltGameObject()
    {
        return saltGameObject;
    }

    public GameObject GetFilterGameObject(DragAndDrop.FilterType filterType)
    {
        if(filterType == DragAndDrop.FilterType.food)
        {
            return foodFilterGameObject;
        } else if(filterType == DragAndDrop.FilterType.salt)
        {
            return saltFilterGameObject;
        }
        return defaultFood;
    }
}
