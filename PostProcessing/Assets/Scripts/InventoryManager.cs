using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Stack inventoryPOne;
    // Start is called before the first frame update
    void Start()
    {
        inventoryPOne = new Stack();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddInventoryPOne(GameObject item)
    {
        inventoryPOne.Push(item);
    }

    public GameObject GetInventoryPOne()
    {
        return inventoryPOne.Pop() as GameObject;
    }
}
