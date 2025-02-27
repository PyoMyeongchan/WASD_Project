using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Image progerssBar;
    public Text loadingText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    { 
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Uiscene");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progerssBar.fillAmount < 0.9f)
            {
                progerssBar.fillAmount = Mathf.MoveTowards(progerssBar.fillAmount, 0.9f, Time.deltaTime);
            }

            if (progerssBar.fillAmount >= 0.9f)
            {
                progerssBar.fillAmount = Mathf.MoveTowards(progerssBar.fillAmount, 1f, Time.deltaTime);
            }

            if (progerssBar.fillAmount >=1f)
            {
                loadingText.text = "Press Space to START";
            
            }

            if (Input.GetKeyDown(KeyCode.Space) && progerssBar.fillAmount >=1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
                SceneManager.LoadScene("Ascene");
            }
        }
         

    }


}
