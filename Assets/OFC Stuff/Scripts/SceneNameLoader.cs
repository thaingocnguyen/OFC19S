using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNameLoader : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
