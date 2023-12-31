using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject optionPanel;

    [SerializeField] Button buttonPrefab;
    [SerializeField] int createCount = 4;

    [SerializeField] string [] titleName;
    [SerializeField] List<Button> buttons;
    [SerializeField] Transform createPosition;

    [SerializeField] UnityEvent callBack;

    // Start is called before the first frame update
    void Start()
    {
        buttons.Capacity = 6;
        CreateButton();
        Register();
    }

    private void CreateButton()
    {
        for(int i = 0; i < createCount; i++)
        {
            Button button = Instantiate(buttonPrefab);

            button.transform.SetParent(createPosition);

            buttons.Add(button);

            Debug.Log(button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = titleName[i]);
        }
    }

    private void Register()
    {
        buttons[0].onClick.AddListener(StartGame);
        buttons[1].onClick.AddListener(B);
        buttons[2].onClick.AddListener(Option);
        buttons[3].onClick.AddListener(Quit);
    }

    public void StartGame()
    {
        GameManager.instance.StartCoroutine(GameManager.instance.StartRoutine(3));
 
    }

    public void Option()
    {
        optionPanel.SetActive(true);
    }

    public void B()
    {
        Debug.Log("B");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
