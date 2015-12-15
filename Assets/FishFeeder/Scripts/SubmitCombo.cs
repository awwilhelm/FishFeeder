using UnityEngine;
using System.Collections;

public class SubmitCombo : MonoBehaviour {

    private FishTank fishTankScript;
    public GameObject head;

    void Start()
    {
        fishTankScript = head.GetComponent<FishTank>();
    }

	public void Verify()
    {
        if(fishTankScript.getTankFishType().fish == DragAndDrop.ItemType.blue || fishTankScript.getTankFishType().fish == DragAndDrop.ItemType.red)
        {
            bool containsFood = false;
            for(int i = 0; i < fishTankScript.GetTankFoodType().Count; i++)
            {
                if((fishTankScript.getTankFishType().fish == DragAndDrop.ItemType.blue && fishTankScript.GetTankFoodType()[i] == DragAndDrop.ItemType.blue) 
                    || (fishTankScript.getTankFishType().fish == DragAndDrop.ItemType.red && fishTankScript.GetTankFoodType()[i] == DragAndDrop.ItemType.red))
                {
                    containsFood = true;
                }
            }
            if(!containsFood)
            {
                print("false");
            }
            if(fishTankScript.getTankFishType().salt && !fishTankScript.GetTankSalt())
            {
                print("false");
            }
        }
        GameObject[] connection = fishTankScript.GetConnections();
        for (int i = 0; i < connection.Length; i++)
        {
            //TODO: Follow connections and add new functions to both fishTank and fishFilter

            //connection[i].GetComponent<TankFilter>().FlowableFilterObjects(tankFoodType, tankSalt);
        }
    }
}
