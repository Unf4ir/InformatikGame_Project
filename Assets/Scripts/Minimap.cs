using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    // Tutorial: https://www.youtube.com/watch?v=28JTTXqMvOU
    public Transform player;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        
        // Für den Fall, dass sich die Minimap mitdrehen soll 
        // transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
