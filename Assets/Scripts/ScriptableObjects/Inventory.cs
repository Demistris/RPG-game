using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item CurrentItem;
    public int _numberOfKeys;
    [SerializeField] private List<Item> _items = new List<Item>();

    public void AddItem(Item itemToAdd)
    {
        if(itemToAdd.IsKey)
        {
            _numberOfKeys++;
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
