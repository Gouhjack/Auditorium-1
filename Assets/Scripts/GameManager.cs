using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Exposed

    [SerializeField] public int sceneName;
    [SerializeField] public IntVariables musicboxes;

    #endregion

    #region Unity LifeCycle
    void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MusicBox"))
        { musicboxes.value++; }
         
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }


    #endregion

    #region Methods

    public void Win()
    {
        Debug.Log("Victory");
        if (SceneManager.GetActiveScene().buildIndex != 1) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else SceneManager.LoadScene(0);
    }

    //Debug.Log($"{numberBarsToEnabled}");
    //    if (numberBarsToEnabled > 6)
    //    {
    //        _gameManager.Win();
    //    }

    #endregion

    #region Private & Protected

    #endregion
}
