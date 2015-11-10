using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

    private bool currentlyDragging;
    private Transform tankLocations;
    private Transform filterLocations;
    private GameObject draggingGameObject;
    private bool draggingFilter;
    
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

    public enum SaltType
    {
        none,
        hasSalt,
        doesNotHaveSalt
    }

    public ItemType foodType;
    public ItemType fishType;
    public FilterType filterType;
    public SaltType saltType;

    void Start()
    {
        currentlyDragging = false;
        draggingFilter = false;
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
        int typeCount = 0;
        if(foodType != ItemType.none)
        {
            typeCount++;
        } else if (filterType != FilterType.none)
        {
            typeCount++;
        } else if (fishType != ItemType.none)
        {
            typeCount++;
        } else if (saltType == SaltType.hasSalt)
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
        } else if(fishType != ItemType.none)
        {

        } else if(saltType  == SaltType.hasSalt)
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
                tank.GetComponent<FishTank>().ChangesBox(Input.mousePosition, foodType, fishType, filterType, saltType);
            }
        } else
        {
            foreach (Transform tankFilter in filterLocations)
            {
                tankFilter.GetComponent<TankFilter>().ChangesFilterBox(Input.mousePosition, foodType, fishType, filterType, saltType);
            }

        }
        draggingFilter = false;
    }


}
