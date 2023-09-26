using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScaneManagement : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Image progressUI;

    public void NextScene()
    {
        StartCoroutine(LoadScene("Scene Battle"));
    }

    private IEnumerator LoadScene(string name)
    {
        screen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        progressUI.fillAmount = 0;

        // allowSceneActivation : 씬 이동을 제어하는 변수

        // true -> 씬을 이동한다.
        // false -> 씬을 이동하지 않는다.

        operation.allowSceneActivation = false;

        float progress = 0;

        // isDone : 씬 로딩이 다 끝났는지 확인하는 함수
        // true -> 씬 로딩이 다 끝난 상태
        // false -> 씬 로딩이 다 끝나지 않은 상태

        while(!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);
            progressUI.fillAmount = progress;

            // 0.9f에서 씬 로딩이 끝난다.

            if(progress>=0.9f)
            {
                progressUI.fillAmount = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
