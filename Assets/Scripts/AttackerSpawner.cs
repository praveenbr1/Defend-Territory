using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackerSpawner : MonoBehaviour {

    
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabArray;
    //[SerializeField] Slider spawnLimitSlider;
  
   // [SerializeField] GameObject LevelCompleteCanvas;
    
   bool spawn = true;


  
 public void StopSpawning()
    {
        spawn = false;
    }
  

  

    IEnumerator Start()
    {
        
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }
	
    private void SpawnAttacker()
    {
         int enemyIndex = Random.Range(0,attackerPrefabArray.Length);
        // Attacker newAttacker = attackerPrefabArray[enemyIndex];
        // Instantiate (newAttacker, transform.position, transform.rotation);
        // newAttacker.transform.parent = transform;
       SpawnIt(attackerPrefabArray[enemyIndex]);
 
    }

	private void SpawnIt(Attacker myAttacker)
    {
       Attacker newAttacker = Instantiate(myAttacker,transform.position,
                                   transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
       
       
    }

}
