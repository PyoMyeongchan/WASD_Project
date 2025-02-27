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

        IEnumerator FadeTextToFullAlpha() // ���İ� 0���� 1�� ��ȯ
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
                yield return null;
            }
            StartCoroutine(FadeTextToZero());
        }

        IEnumerator FadeTextToZero()  // ���İ� 1���� 0���� ��ȯ
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