using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private void Start()
    {
        Score.OnScoreEvent += SetScoreOnUI;                         //bind/Register a listener
    }

    private void OnEnable()
    {
        _scoreText.text = Score.GetScore().ToString();              // set initial score when game starts
    }

    private void SetScoreOnUI(int newScore)
    {
        _scoreText.text = newScore.ToString();
    }

    private void OnDestroy()
    {
        Score.OnScoreEvent -= SetScoreOnUI;                     //Unbind listener
    }
}
