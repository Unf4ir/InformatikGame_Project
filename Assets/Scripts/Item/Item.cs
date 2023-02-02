using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use the item
        //Something might happen

        Debug.Log("Using " + name);
    }
    //Test Video
    public enum ItemType
    {
        bluePotion,
        RedPotion,
        orangePotion,
    }
    public ItemType itemType;
    public int amount;
}
