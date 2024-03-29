using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationController : MonoBehaviour
{
    public GameObject baseSlot;
    public GameObject ingredientSlot;

    public GameObject resultSlot;

    private GameObject resultItem;

    public void Combination()
    {
        if (resultSlot.transform.childCount == 0)
        {
            if (baseSlot.transform.childCount == 1 && ingredientSlot.transform.childCount == 1)
            {
                if (baseSlot.transform.GetChild(0).GetComponent<BaseItem>() != null &&
                  ingredientSlot.transform.GetChild(0).GetComponent<IngredientItem>() != null)
                {
                    if (baseSlot.transform.GetChild(0).GetComponent<BaseItem>().baseItem == true &&
                                ingredientSlot.transform.GetChild(0).GetComponent<IngredientItem>().baseItem == false)
                    {
                        resultItem = baseSlot.transform.GetChild(0).GetComponent<BaseItem>().Combine(ingredientSlot.transform.GetChild(0).gameObject);
                        Instantiate(resultItem, resultSlot.transform);
                        Destroy(baseSlot.transform.GetChild(0).gameObject);
                        Destroy(ingredientSlot.transform.GetChild(0).gameObject);
                    }
                }
                else
                {

                }
            }
        }
    }
}
