using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager :Singleton<ShaftManager>
{
    [SerializeField] private GameObject shaftPrefab;
    [SerializeField] private List<GameObject> shaftsInScene;
    [SerializeField] private float yPosOfNewShaft;
    [SerializeField] private float newShaftCost = 5000f;
    [SerializeField] private float shaftCostMultiplier = 10f;

    public float currentShaftCost { get; set; }

    private int currentShaftIndex = 0;

    private void Start()
    {
        currentShaftCost = newShaftCost;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            AddNewShaft();
        }
    }
    //method to spawn shaft
    public void AddNewShaft()
    {  
        //define x position and y position to spawn
        float xPos = shaftsInScene[currentShaftIndex].transform.position.x;
        float yPos = shaftsInScene[currentShaftIndex].transform.position.y + yPosOfNewShaft;
        Vector3 spawnPos = new Vector3(xPos, yPos);

        var newShaft = Instantiate(shaftPrefab, spawnPos, Quaternion.identity);

        //add just spawned shaft to the list of shafts and increment the counter of shafts
        shaftsInScene.Add(newShaft);
        currentShaftIndex++;

        //update the current shaft cost (how much it now costs to add a shaft)
        currentShaftCost *= shaftCostMultiplier;

        
        var currShaftUI = shaftsInScene[currentShaftIndex].GetComponent<ShaftUI>();

        //set the shaft ID text of the just spawned shaft
        currShaftUI.SetShaftID(currentShaftIndex);

        //set the updated shaft cost
        currShaftUI.SetShaftCost(currentShaftCost);


    }
}
