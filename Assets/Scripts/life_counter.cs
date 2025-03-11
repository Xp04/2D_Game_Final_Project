using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class life_counter : MonoBehaviour    //score_manager
{
    public static life_counter instance;
    public TMP_Text score_text;
    int score = 0;
    
    public GameObject player;
    public TMP_Text life_text;
    public int life = 3;
    

    private void Awake()
    {
        instance = this;
    }
    public void updateUI()
        {
            score_text.text = "Points: " + score.ToString();
            life_text.text = "Lives: " + life.ToString();
        }

    void Start()
    {
        updateUI();
    }

    public void addPoints()
    {
        score++;
        updateUI();
    }

    public void addLife()
    {
        life++;
        updateUI();
    }

    public void subLife()
    {
        life--;
        updateUI();
        if (life <= 0)
        {
            Destroy(player);  // Hides the player
            // Alternatively: player.SetActive(false);
        }
    }
    
}