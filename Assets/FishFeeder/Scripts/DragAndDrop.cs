using UnityEngine;
using System.Collections.Generic;

public class DragAndDrop : MonoBehaviour {

    private bool currentlyDragging;
    private Transform tankLocations;
    private Transform filterLocations;
    private GameObject draggingGameObject;
    private bool draggingFilter;
    private bool draggingFish;
    
    public enum ItemType
    {
        none,
        change,
        red,
        blue
    };

    public enum FilterType
    {
        none,
        change,
        food,
        salt
    }

    public struct FishType
    {
        public ItemType fish;
        public bool salt;
    };

    public ItemType foodType;
    public FishType fishType;
    public ItemType fishTemp;
    public bool fishHasSaltTemp;
    public FilterType filterType;
    public bool saltType;

    void Start()
    {
        currentlyDragging = false;
        draggingFilter = false;
        draggingFish = false;
        tankLocations = GameObject.Find("TankLocations").transform;
        filterLocations = GameObject.Find("FilterLocations").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            draggingGameObject.transform.position = mousePos;
        }
    }

    public void PressDown()
    {
        fishType.fish = fishTemp;
        fishType.salt = fishHasSaltTemp;

        int typeCount = 0;
        if(foodType != ItemType.none)
        {
            typeCount++;
        } else if (filterType != FilterType.none)
        {
            typeCount++;
        } else if (fishType.fish != ItemType.none)
        {
            typeCount++;
        } else if (saltType)
        {
            typeCount++;
        }

        if(typeCount > 1)
        {
            print("ERROR: Too many types were selected");
        } else if(typeCount == 0)
        {
            print("ERROR: One type was not selected");
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentlyDragging = true;
        mousePos.z = 0;
        if (foodType != ItemType.none)
        {
            draggingGameObject = Instantiate(transform.parent.GetComponent<Items>().GetFoodGameObject(foodType), mousePos, Quaternion.identity) as GameObject;
        } else if (filterType != FilterType.none)
        {
            draggingFilter = true;
            draggingGameObject = Instantiate(transform.parent.GetComponent<Items>().GetFilterGameObject(filterType), mousePos, Quaternion.identity) as GameObject;
        } else if(fishType.fish != ItemType.none)
        {
            draggingGameObject = Instantiate(transform.parent.GetComponent<Items>().GetFishGameObject(fishType), mousePos, Quaternion.identity) as GameObject;
            draggingFish = true;
        } else if(saltType)
        {
            draggingGameObject = Instantiate(transform.parent.GetComponent<Items>().GetSaltGameObject(), mousePos, Quaternion.identity) as GameObject;
        }
    }

    public void PressUp()
    {
        currentlyDragging = false;
        Destroy(draggingGameObject);

        if (!draggingFilter)
        {
            foreach (Transform tank in tankLocations)
            {
                if(draggingFish)
                {

                    tank.GetComponent<FishTank>().AddFish(Input.mousePosition, fishType, saltType);
                } else
                {
                    tank.GetComponent<FishTank>().ChangesBox(Input.mousePosition, foodType, filterType, saltType);
                }
            }
        } else
        {
            foreach (Transform tankFilter in filterLocations)
            {
                tankFilter.GetComponent<TankFilter>().ChangesFilterBox(Input.mousePosition, foodType, filterType, saltType);
            }

        }
        draggingFilter = false;
        draggingFish = false;
    }


}
