using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject Item;

        public List<GameObject> items = new List<GameObject>();
        public int space = 20;

        public delegate void OnItemChanged();
        public OnItemChanged onItemChangedCallback;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                //Ativar/Desativar inventário
            }
        }

        public bool Add(GameObject item)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory is full");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
            return true;
        }

        public void Remove(GameObject item)
        {
            items.Remove(item);
            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    
   


}
public class InventoryItem
{
    public string itemName;
    public Sprite icon;
    public string description;

    public InventoryItem(string name, Sprite sprite, string desc)
    {
        itemName = name;
        icon = sprite;
        description = desc;
    }
}
