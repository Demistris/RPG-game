using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item CurrentItem;
    public int NumberOfKeys;
    public int Coins;

    public float MaxMagic = 10f;
    public float CurrentMagic = 10f;

    [SerializeField] private List<Item> _items = new List<Item>();

    public void AddItem(Item itemToAdd)
    {
        if(itemToAdd.IsKey)
        {
            NumberOfKeys++;
        }
        else
        {
            if(!_items.Contains(itemToAdd))
            {
                _items.Add(itemToAdd);
            }
        }
    }
}
