using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField]
    private Spell spell;

    [SerializeField]
    private string enemyTag;

    private bool wait = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && wait == false)
        {
            wait = true;
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        spell.magic(enemyTag);
        yield return new WaitForSecondsRealtime(2f);
        wait = false;
    }
}
