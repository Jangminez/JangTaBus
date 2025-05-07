using UnityEngine;
using UnityEngine.UI;

public class TabBtn : MonoBehaviour
{
    private enum Tabs { Ship, Farm, Dungeon};
    [SerializeField] Tabs _tab;

    private Button _myBtn;
    public Transform _myTab;
    public Transform[] _otherTabs;

    private void Awake()
    {
        _myBtn = GetComponent<Button>();

        _myBtn.onClick.AddListener(OpenTab);

        if (_tab == Tabs.Ship)
        {
            _myTab.gameObject.SetActive(true);
        }

    }

    void OpenTab()
    {   
        _myTab.gameObject.SetActive(true);

        foreach(Transform other in _otherTabs)
        {
            other.gameObject.SetActive(false);
        }
    }
}
