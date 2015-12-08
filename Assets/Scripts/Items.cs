using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {

    public GameObject redFood;
    public GameObject blueFood;
    public GameObject defaultFood;
    public GameObject saltGameObject;
    public GameObject foodFilterGameObject;
    public GameObject saltFilterGameObject;

    public GameObject blueSaltWaterFish;
    public GameObject blueFreshWaterFish;
    public GameObject redSaltWaterFish;
    public GameObject redFreshWaterFish;

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

    public GameObject GetFishGameObject(DragAndDrop.FishType fishType)
    {
        if(fishType.fish == DragAndDrop.ItemType.blue)
        {
            if(fishType.salt)
            {
                return blueSaltWaterFish;
            } else
            {
                return blueFreshWaterFish;
            }
        } else if (fishType.fish == DragAndDrop.ItemType.red)
        {
            if (fishType.salt)
            {
                return redSaltWaterFish;
            }
            else
            {
                return redFreshWaterFish;
            }
        }
        return defaultFood;
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
