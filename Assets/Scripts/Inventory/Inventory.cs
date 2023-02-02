using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7
    #region Singleton
    public static Inventory instance;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback; 

    public int space = 2;

    public List<Item> items = new List<Item>();

    private void Awake()
    {
        instance = this;  
    }
    #endregion
    public bool Add (Item item)
        {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room for another item");
            return false;
        }
        items.Add(item);
        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;    
    }
        
        public void Remove (Item item)
        {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
}
