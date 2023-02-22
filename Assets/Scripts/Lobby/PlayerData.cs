using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int lastCharacter;

    public PlayerData(CharacterSelection Player)
    {
        lastCharacter = Player.lastCharacter;
        
    }
    
}
