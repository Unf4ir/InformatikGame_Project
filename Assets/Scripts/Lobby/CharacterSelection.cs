using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    public GameObject[] characters;
    int selectedCharacter = 1;
    public int lastCharacter;

    private void Start()
    {
        laden();
        selectedCharacter = lastCharacter;
        characters[selectedCharacter].SetActive(true);
    }
    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        lastCharacter = selectedCharacter;
        SaveSystem.SavePlayer(this);
    }
    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter = 2;
        }
        characters[selectedCharacter].SetActive(true);
        lastCharacter = selectedCharacter;
        SaveSystem.SavePlayer(this);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void laden()
    {
        PlayerData data =  SaveSystem.LoadPlayer();
        lastCharacter = data.lastCharacter;
    }
    
        public void StartGame()
    { 
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
