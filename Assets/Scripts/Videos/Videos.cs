using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Videos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextLevel());
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }
}
