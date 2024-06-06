using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string _sceneToLoad;
   public void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
