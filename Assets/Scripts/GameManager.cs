using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

       
{
    public List<GameObject> enemiesInScreen;
    
       void Update(){
        if(Input.GetKeyDown(KeyCode.R)) Nuke();
    }

    public void Nuke(){
        foreach(GameObject enemy in enemiesInScreen){
            Destroy(enemy);
        }
    }
    public bool isGameOver;

    public Text coinText;
    int coins;
    
    public void GameOver()
    {
        isGameOver = true;
    }

    public void AddCoin()
    {
        coins++;
        coinText.text = coins.ToString();
    }

    
 
}
