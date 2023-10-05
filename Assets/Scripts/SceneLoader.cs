using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneLoad(int index)
    {
        StartCoroutine(LoadScene(index));
    }


    IEnumerator LoadScene(int index) {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }
}
