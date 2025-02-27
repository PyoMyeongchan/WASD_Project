using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
        public Text text;

        void Awake()
        {
            text = GetComponent<Text>();
            StartCoroutine(FadeTextToFullAlpha());
        }

        IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
                yield return null;
            }
            StartCoroutine(FadeTextToZero());
        }

        IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
                yield return null;
            }
            StartCoroutine(FadeTextToFullAlpha());
        }



}