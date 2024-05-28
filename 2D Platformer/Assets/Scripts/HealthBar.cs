using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//access to ui
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    //access to rect tranform component for changing health size bar
    private RectTransform bar;
    // Start is called before the first frame update
    void Start()
    {//same for this
        bar = GetComponent<RectTransform>();
        SetSize(Health.totalHealth);
    }

    public void Damage(float damage)
    {
        //check if damage has been subtracted, if that value is 0 or more that amount will be taken from health but if its less than 0 itll become zero, not a -#
        if((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
        else 
        {
             Health.totalHealth = 0f;
        }

        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }
}
