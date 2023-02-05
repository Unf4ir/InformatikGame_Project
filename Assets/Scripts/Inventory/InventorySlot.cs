using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Image TimerIcon;
    public Image FillIcon;
    public Button removeButton;
    Item item;
    public Transform bulletSpawnPoint;
    public GameObject FireballPrefab;
    public GameObject IceballPrefab;
    public float fireSpeed = 10f;
    private bool waitFireball = false;
    private bool waitIceball = false;

    [SerializeField]
    Timer timer;

    private void Start()
    {
        TimerIcon.enabled = false;
        FillIcon.enabled = false;


    }
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
        //Tutorial: https://www.youtube.com/watch?v=EwiUomzehKU
        if (item.name == "Protein Riegel" && waitFireball == false) 
        {
            item.Use();
            TimerIcon.enabled = true;
            FillIcon.enabled = true;

            var FeuerBall = Instantiate(FireballPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            FeuerBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
            StartCoroutine(FireTimer());
        }

        if (item.name == "Protein Injektion" && waitIceball == false)
        {
            item.Use();
            TimerIcon.enabled = true;
            FillIcon.enabled = true;

            var IceBall = Instantiate(IceballPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            IceBall.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * fireSpeed;
            StartCoroutine(IceTimer());
        }
    }
    IEnumerator FireTimer()
    {
        
        waitFireball = true;
        timer.SetDuration(3).Begin();
        yield return new WaitForSecondsRealtime(3f);
        waitFireball = false;
        TimerIcon.enabled = false;
        FillIcon.enabled = false;
        
    }
    IEnumerator IceTimer()
    {
        waitIceball = true;
        timer.SetDuration(5).Begin();
        yield return new WaitForSecondsRealtime(5f);
        waitIceball = false;
        TimerIcon.enabled = false;
        FillIcon.enabled = false;
    }
}
