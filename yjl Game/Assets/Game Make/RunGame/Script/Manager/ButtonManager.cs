using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] Button buttonPrefab;
    [SerializeField] List<Button> buttons;
    [SerializeField] int createCount = 4;
    [SerializeField] Transform createPosition;

    TextMeshPro TextMesh;

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

            Debug.Log(button.transform.GetChild(0));
        }
    }

    private void Register()
    {
        buttons[0].onClick.AddListener(A);
        buttons[1].onClick.AddListener(B);
        buttons[2].onClick.AddListener(C);
        buttons[3].onClick.AddListener(D);
    }

    public void A()
    {
        Debug.Log("A");
        TextMesh Start;
    }

    public void B()
    {
        Debug.Log("A");
        TextMesh Shop;
    }

    public void C()
    {
        Debug.Log("A");
        TextMesh Option;
    }

    public void D()
    {
        Debug.Log("A");
        TextMesh Quit;
    }


}
