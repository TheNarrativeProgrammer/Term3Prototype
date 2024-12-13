using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Health _playerHealth;

    [SerializeField]
    private Image _fillBarImg;
    void Update()
    {
        _fillBarImg.fillAmount = _playerHealth == null ? 0f : _playerHealth.HealthPercentage;
    }
}
