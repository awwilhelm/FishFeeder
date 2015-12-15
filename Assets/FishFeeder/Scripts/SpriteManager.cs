using UnityEngine;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour
{

    public Sprite blueSprite;
    public Sprite redSprite;
    public Sprite multipleFoodSprite;
    public Sprite defaultSprite;

    public Sprite foodFilterSprite;
    public Sprite saltFilterSprite;

    public Sprite blueSaltWaterFish;
    public Sprite blueFreshWaterFish;
    public Sprite redSaltWaterFish;
    public Sprite redFreshWaterFish;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite GetSpriteFoodType(List<DragAndDrop.ItemType> foodType)
    {
        if (foodType.Count == 1)
        {
            if (foodType[0] == DragAndDrop.ItemType.blue)
            {
                return blueSprite;
            }
            else if (foodType[0] == DragAndDrop.ItemType.red)
            {
                return redSprite;
            }
        } else if(foodType.Count > 1)
        {
            return multipleFoodSprite;
        }
        return defaultSprite;
    }

    public Sprite GetSpriteFishType(DragAndDrop.FishType fishType)
    {
        if (fishType.fish == DragAndDrop.ItemType.blue)
        {
            if (fishType.salt)
            {
                return blueSaltWaterFish;
            }
            else
            {
                return blueFreshWaterFish;
            }
        }
        else if (fishType.fish == DragAndDrop.ItemType.red)
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
        return defaultSprite;
    }

    public Sprite GetSpriteFilterType(DragAndDrop.FilterType filterType)
    {
        if (filterType == DragAndDrop.FilterType.food)
        {
            return foodFilterSprite;
        }
        else if (filterType == DragAndDrop.FilterType.salt)
        {
            return saltFilterSprite;
        }
        return defaultSprite;
    }
}
