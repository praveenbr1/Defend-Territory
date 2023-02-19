using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour {

    [SerializeField] Defender defenderPrefab;
    [SerializeField] TextMeshProUGUI resourceCostText;
 private void Start()
  {
    resourceCostText.text = defenderPrefab.GetStarCost().ToString();
 }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(142, 127, 127, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

}
