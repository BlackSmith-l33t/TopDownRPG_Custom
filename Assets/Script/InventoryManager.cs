using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    
    public static InventoryManager instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
    }

    public List<ItemData> items = new List<ItemData>();

    public int maxSize = 20;

    public bool Add(ItemData item)
    {
        if (items.Count >= maxSize)
        {
            return false;
        }
        items.Add(item);
        return true;
    }

    public void Remove()
    {

    }
}
