using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    [SerializeField]
    private Transform _UiRootGameOver;

    private void Awake()
    {
        ToggleGameOverScreen(false);                                //turn off visibility of GameOver Ui when game starts
        GameManager.OnGameOverEvent += ToggleGameOverScreen;        //BINDING EVENT                                         bind ToggleGameOverScreen to OnGameOverEvent
    }

    private void ToggleGameOverScreen(bool isVisible)
    {
        _UiRootGameOver.gameObject.SetActive(isVisible);
    }

    private void OnDestroy()
    {
        GameManager.OnGameOverEvent -= ToggleGameOverScreen;        //UNSUBSCRIBE FROM BINDING EVENT
    }
}
