using UnityEngine;

public class UI_GameWon : MonoBehaviour
{
    [SerializeField]
    private Transform _UiSceneRoot;

    private void Awake()
    {
        ToggleGameWonScreen(false);
        GameManager.OnGameWonEvent += ToggleGameWonScreen;
        
    }

    private void ToggleGameWonScreen(bool isVisible)
    {
        _UiSceneRoot.gameObject.SetActive(isVisible);
    }

    private void OnDestroy()
    {
        GameManager.OnGameWonEvent -= ToggleGameWonScreen;
    }
}
