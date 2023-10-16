using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum CoinLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1,
}

public class CoinManager : MonoBehaviour
{
    [SerializeField] int interval = 2;
    [SerializeField] int createCount = 15;

    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform createPosition;

    // Start is called before the first frame update
    void Start()
    {
        CreateCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateCoin()
    {
        for(int i = 0; i < createCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab);

            coin.transform.SetParent(createPosition);

            coin.transform.localPosition = new Vector3(coin.transform.position.x, coin.transform.position.y, interval * i);
        }
    }
}
