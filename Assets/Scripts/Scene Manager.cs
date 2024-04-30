using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<SceneScriptableObject> sceneSO = new List<SceneScriptableObject>();
    private SceneScriptableObject currentScene;

    private void Start()
    {
        LoadScene(0);
    }

    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex >= sceneSO.Count)
        {
            Debug.LogError("Invalid scene index: " + sceneIndex);
            return;
        }

        currentScene = sceneSO[sceneIndex];
        SetSceneAdjustments();
    }

    private void SetSceneAdjustments()
    {
        if (currentScene == null)
        {
            Debug.LogError("Current scene is null.");
            return;
        }

        currentScene.collisionGridList.Clear();

        // Set collision grids based on scene-specific rules
        if (currentScene == sceneSO[0])
        {
            AddCollisionGridRange(21, 406, 32);
            AddCollisionGridRange(597, 1014, 32);
        }
        // Add other scenes' collision grid configurations here
    }

    private void AddCollisionGridRange(int start, int end, int step)
    {
        for (int i = start; i < end; i += step)
        {
            currentScene.collisionGridList.Add(i);
        }
    }
}
