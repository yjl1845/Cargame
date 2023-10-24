using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

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

    public IEnumerator StartRoutine()
    {
        cameraAnimator.enabled = true;
        playerAnimator.SetTrigger("Start");

        // �ڷ�ƾ�� �ð��� ������ �ֱ� ������ ���� Time.Scale�� 0�̹Ƿ�, WaitForndsRealtime�� �����Ѵ�.
        yield return new WaitForSecondsRealtime(3f);

        Time.timeScale = 1.0f;
        playerAnimator.transform.rotation = Quaternion.identity;
        playerAnimator.SetLayerWeight(1,0);
  
    }
}