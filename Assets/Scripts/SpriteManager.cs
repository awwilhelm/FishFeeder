using UnityEngine;
using System.Collections;

public class SpriteManager : MonoBehaviour
{

    public Sprite blueSprite;
    public Sprite redSprite;
    public Sprite defaultSprite;

    public Sprite foodFilterSprite;
    public Sprite saltFilterSprite;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite GetSpriteFoodType(DragAndDrop.ItemType foodType)
    {
        if (foodType == DragAndDrop.ItemType.blue)
        {
            return blueSprite;
        }
        else if (foodType == DragAndDrop.ItemType.red)
        {
            return redSprite;
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
