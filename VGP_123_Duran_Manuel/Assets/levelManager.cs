using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    ManageLives life;
    public string sceneName;
    public string deathSceneName;
    
    void Start()
    {
        life = GetComponent<ManageLives>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) changeScene();
        
    }
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void deathScene()
    {
        SceneManager.LoadScene(deathSceneName);
    }
}
