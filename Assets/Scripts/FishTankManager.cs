using UnityEngine;
using System.Collections;

public class FishTankManager : MonoBehaviour {

    public Sprite blueSprite;
    public Sprite redSprite;
    public Sprite defaultSprite;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Sprite GetSpriteFoodType(DragAndDrop.ItemType foodType)
    {
        if(foodType == DragAndDrop.ItemType.blue)
        {
            return blueSprite;
        } else if(foodType == DragAndDrop.ItemType.red)
        {
            return redSprite;
        }
        return defaultSprite;
    }
}
