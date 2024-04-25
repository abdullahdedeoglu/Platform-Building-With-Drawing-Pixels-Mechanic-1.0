using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<SceneScriptableObject> sceneSO = new List<SceneScriptableObject>();
    private SceneScriptableObject currentScene;

    private void Start()
    {
        SetCurrentScene(0, false);
        SetSceneAdjustments();
    }

    public void SetCurrentScene(int sceneIndex, bool isChanging) //Get current scene by index
    {
        currentScene = sceneSO[sceneIndex];

        if(isChanging) //Just for security, i know script can be better. Will change. 
        {
            SetSceneAdjustments();
        }
    }
    private void SetSceneAdjustments() // Add Details Of Scriptable Objects By Hand But in Code Because Of Laziness
    {
        currentScene.collisionGridList.Clear();

        // Attach which grids will has collider by their sorting order in grid, very static system,
        // either coder will set things or graphic designer draw scenes by code rules because it depends on scene

        if (currentScene == sceneSO[0])
        {
            
            for (int i = 21; i < 406; i += 32) //21-405
            {
                currentScene.collisionGridList.Add(i);
            }
            
            for (int j = 597; j < 1014; j += 32) //597-1013
            {
                currentScene.collisionGridList.Add(j);
            }
        }
    }
}
