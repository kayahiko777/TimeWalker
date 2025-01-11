using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHp;

    private int currentHp;

    [SerializeField]
    private Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        InitialHealth(maxHp);
    }

    
    public void InitialHealth(int initialHp)
    {
        maxHp = initialHp;
        currentHp = maxHp;

        healthSlider.maxValue = currentHp;
        healthSlider.value = currentHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp = Mathf.Max(currentHp - damage, 0);

        healthSlider.DOValue(currentHp, 0.5f);

        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
