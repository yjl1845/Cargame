using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    // 프라이빗 속성을 유지하면서 외부에 공개

    [SerializeField] Rect rect;
    [SerializeField] RawImage rawImage;

    [SerializeField] float speed = 0.25f;

    private void Update()
    {
        rect = rawImage.uvRect;
        rect.x += Time.deltaTime * speed;

        rawImage.uvRect = rect;
    }
}
