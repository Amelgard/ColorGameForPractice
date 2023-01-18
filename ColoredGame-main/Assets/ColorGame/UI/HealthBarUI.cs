using UnityEngine;
using UnityEngine.UI;
using ColorGame.Player;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] ScoreDB _score;
    [SerializeField] Score ScoreUI;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    
    void Update()
    {
        image.fillAmount = player.health / 100;
        if (player.health < 0) 
        {
            GameOverMenu.SetActive(true);
            if (ScoreUI._score > _score.BestScore) 
            {
                _score.BestScore = ScoreUI._score;
            }
            Destroy(player.gameObject);
            Time.timeScale = 0f;
        }
    }
}
