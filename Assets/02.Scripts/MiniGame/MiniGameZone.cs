using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MiniGameType { Ship, Farm, Dungeon }
public class MiniGameZone : MonoBehaviour
{
    [SerializeField] private MiniGameType miniGameType;
    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private Button startButton;

    void Awake()
    {
        startButton.onClick.AddListener(StartMiniGame);
        infoCanvas.SetActive(false);
    }

    void Start()
    {
        switch (miniGameType)
        {
            case MiniGameType.Ship:
                goalText.text = GameManager.Instance.ShipGame_Goal.ToString();
                break;

            case MiniGameType.Farm:
                goalText.text = GameManager.Instance.FarmGame_Goal.ToString();
                break;

            case MiniGameType.Dungeon:
                break;
        }
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
        switch (miniGameType)
        {
            case MiniGameType.Ship:
                GameManager.Instance.PlayShipGame();
                break;

            case MiniGameType.Farm:
                GameManager.Instance.PlayFarmGame();
                break;
                
            case MiniGameType.Dungeon:
                break;
        }
    }
}
