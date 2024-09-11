using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChancePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject fistChance, secondChance, thirdChance;

    public void ChanceControl(int chance)
    {
        switch(chance)
        {
            case 3:
                fistChance.SetActive(true);
                secondChance.SetActive(true);
                thirdChance.SetActive(true);
                break;

            
            case 2:
                fistChance.SetActive(true);
                secondChance.SetActive(true);
                thirdChance.SetActive(false);
                break;

            
            case 1:
                fistChance.SetActive(true);
                secondChance.SetActive(false);
                thirdChance.SetActive(false);
                break;

            
            case 0:
                fistChance.SetActive(false);
                secondChance.SetActive(false);
                thirdChance.SetActive(false);
                break;
        }
    }
}