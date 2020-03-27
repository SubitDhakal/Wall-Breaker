using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    //Cached reference
    Scene_Loader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<Scene_Loader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }
    
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneloader.LoadNextScene();

        }
    }


}
