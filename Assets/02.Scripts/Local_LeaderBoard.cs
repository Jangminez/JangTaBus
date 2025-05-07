using TMPro;
using UnityEngine;

public class Local_LeaderBoard : MonoBehaviour
{
    [SerializeField] GameObject leaderBoardCanvas;
    [SerializeField] TextMeshProUGUI shipBestText;
    [SerializeField] TextMeshProUGUI farmBestText;
    [SerializeField] TextMeshProUGUI dungeonBestText;

    void Awake()
    {
        leaderBoardCanvas.SetActive(false);
    }

    void Start()
    {
        shipBestText.text = PlayerPrefs.GetInt("SHIP_BESTSCORE", 0).ToString();
        farmBestText.text = PlayerPrefs.GetInt("FARM_BESTSCORE" ,0).ToString();
        dungeonBestText.text = PlayerPrefs.GetInt("DUNGEON_BESTSCORE", 0).ToString();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            leaderBoardCanvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            leaderBoardCanvas.SetActive(false);
    }
}
