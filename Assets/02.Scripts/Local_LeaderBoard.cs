using TMPro;
using UnityEngine;

public class Local_LeaderBoard : MonoBehaviour
{
    [SerializeField] GameObject leaderBoard;
    [SerializeField] GameObject keyText;
    [SerializeField] TextMeshProUGUI shipBestText;
    [SerializeField] TextMeshProUGUI farmBestText;
    [SerializeField] TextMeshProUGUI dungeonBestText;
    bool isTrigger = false;

    void Awake()
    {
        leaderBoard.SetActive(false);
        keyText.SetActive(false);
    }

    void Start()
    {
        shipBestText.text = PlayerPrefsHandler.GetShipBestScore().ToString();
        farmBestText.text = PlayerPrefsHandler.GetFarmBestScore().ToString();
        dungeonBestText.text = PlayerPrefsHandler.GetDungeonBestScore().ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isTrigger)
        {
            leaderBoard.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keyText.SetActive(true);
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            keyText.SetActive(false);
            isTrigger = false;
            leaderBoard.SetActive(false);
        }
    }
}
