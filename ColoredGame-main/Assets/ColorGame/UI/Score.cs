using System;
using ColorGame.Player;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] float healthDecreaseMultiplier;
    public float _score = 0;
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "Score: 0";

        player.OnColorChange += OnPlayerColorChange;
    }

    private void OnDestroy()
    {
        player.OnColorChange -= OnPlayerColorChange;
    }

    private void Update()
    {
        _score += player.Velocity.y * Time.deltaTime;
        player.health -= Time.deltaTime * healthDecreaseMultiplier;
        _text.text = "Score: " + (int)_score;
    }

    private void OnPlayerColorChange(Color color)
    {
        _score += 10;
    }
}
