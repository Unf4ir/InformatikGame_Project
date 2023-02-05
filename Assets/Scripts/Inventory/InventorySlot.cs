using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;
    Item item;

    public Transform bulletSpawnPoint;
    public GameObject FireballPrefab;
    public GameObject IceballPrefab;
    public float fireSpeed = 10f;


    
    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }
    public void UseItem()
    {
        if(item.name == "Protein Riegel") 
        {
            item.Use();
            var FireBall = Instantiate(FireballPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            FireBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
        }
        if(item.name == "Protein Injektion")
        {
            item.Use();
            var IceBall = Instantiate(IceballPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            IceBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
         
        }

    }
}
