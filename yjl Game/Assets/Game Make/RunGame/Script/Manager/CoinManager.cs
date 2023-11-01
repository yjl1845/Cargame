using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Percentage))]

public class CoinManager : MonoBehaviour
{
    private Percentage percentage;

    [SerializeField] bool flag;
    [SerializeField] int itemCount;
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 20;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] GameObject rotatePrefab;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] List<GameObject> coins;


    // Start is called before the first frame update
    void Start()
    {
        percentage = GetComponent<Percentage>();

        CreateCoin();
    }


    private void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab);

            coin.transform.localPosition = new Vector3(0, 1, interval * i);

            coins.Add(coin);
        }
    }

    public void NewPosition()
    {
        ActiveCoin();

        RoadLine roadLine = (RoadLine)Random.Range(-1, 2);
        Debug.Log(roadLine);

        switch(roadLine)
        {
            case RoadLine.LEFT:
                coinPrefab.transform.localPosition = new Vector3(-positionX, 0, 0);
                break;
            case RoadLine.MIDDLE:
                coinPrefab.transform.localPosition = Vector3.zero;
                break;
            case RoadLine.RIGHT:
                coinPrefab.transform.localPosition = new Vector3 (+positionX, 0, 0);
                break;
        }
    }

    public void ActiveCoin()
    {
        foreach(var element in coins)
        {
            element.SetActive(true);
            element.transform.rotation = Quaternion.Euler(rotatePrefab.transform.rotation.eulerAngles.x, rotatePrefab.transform.rotation.eulerAngles.y, rotatePrefab.transform.rotation.eulerAngles.z);
        }

        bool flag = false;

        itemCount = percentage.Rand(10, out flag);

        if (flag == true)
        {
            coins[itemCount].SetActive(false);
        }
    }
}
