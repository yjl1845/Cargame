using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public float speed = 15f;
    [SerializeField] GameObject layoutPanel;

    [SerializeField] Animator textAnimator;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator cameraAnimator;


    // Start is called before the first frame update
    void Start()
    {
        GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public IEnumerator StartRoutine(int count)
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        layoutPanel.SetActive(false);

        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������ ���� Time.Scale�� 0�̹Ƿ�, WaitForndsRealtime�� �����Ѵ�.
        while (count>0)
        {
            textAnimator.GetComponent<TextMeshProUGUI>().text = count.ToString();
            textAnimator.Play("Countdonw");
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        textAnimator.gameObject.SetActive(false);

        playerAnimator.SetLayerWeight(1, 0);
        Time.timeScale = 1.0f;
    }
}