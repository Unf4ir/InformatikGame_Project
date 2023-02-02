using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Tutorial: https://www.youtube.com/watch?v=9tePzyL6dgc&list=RDCMUCYbK_tjZ2OrIZFBvU6CCMiA&start_radio=1&rv=9tePzyL6dgc&t=135
    public float radius = 3f;
    public GameObject _interactable;
    public GameObject _player;
    Transform player;
    bool hasInteracted = false;

    private void Update()
    {
        float distance = Vector3.Distance(_interactable.transform.position, _player.transform.position);
        if (hasInteracted == false) { 
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            } 
        } else if (distance >= radius)
        {
            hasInteracted = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    
    }
    public virtual void Interact()
    {
        //This method is meant ot be overwritten
        Debug.Log("Interaktion");
    }

}
