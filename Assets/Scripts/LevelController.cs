using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int currentSceneIndex;
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    LoadScenes loadScenes;
   
    private void Start()
    {
        winLabel.SetActive(false);
        loadScenes = GetComponent<LoadScenes>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished == true)
        { 
            if(HandleWinCondition() == null){return;}
            if(numberOfAttackers >0){return;}
            if(this.gameObject == null) { return;}
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
      
       if(currentSceneIndex < 7)
        {
          winLabel.SetActive(true);
       // GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        loadScenes.LoadNextScene();
        }

        else 
        {
        winLabel.SetActive(true);
        yield return new WaitForSeconds(waitToLoad);
         SceneManager.LoadScene("Start Screen");
        }
        

        
        
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
