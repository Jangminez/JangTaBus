using UnityEngine;
using UnityEngine.UI;

public enum MiniGameType { Ship, Dungeon }
public class MiniGameZone : MonoBehaviour
{
    [SerializeField] private MiniGameType miniGameType;
    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private Button startButton;

    void Awake()
    {
        startButton.onClick.AddListener(StartMiniGame);
        infoCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        infoCanvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        infoCanvas.SetActive(false);      
    }

    void StartMiniGame()
    {
        switch(miniGameType)
        {
            case MiniGameType.Ship:
                GameManager.Instance.PlayShipGame();
            break;

            case MiniGameType.Dungeon:
            break;
        }
    }
}
