using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField]
    private Text coinText;
    private int coinCount = 0;
   void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    public void IncrementScore()
    {
        coinCount++;
        coinText.text = "x" + coinCount;
    }
    public void RestartGame()
    {
        Invoke("restarting", 3f);
    }
     void restarting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
