using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class RememberLevel:MonoBehaviour
{
    [SerializeField] private int _levelIndex;
    
    private void Awake()
    {
        NextLevel nextLevel=NextLevel.Load();
        nextLevel.ChangeLevel(_levelIndex);
        nextLevel.Save();  
    }
}