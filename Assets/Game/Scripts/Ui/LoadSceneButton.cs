using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    [SerializeField] private SceneReference _scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(_scene);
    }
}
