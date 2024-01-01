using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image eatBar;
    public Image HPBar;
    public Image sleepBar;

    public float eat_value;     // max = 100
    private float eat_max = 100f;
    
    public float wash_value;    // max = 100
    private float wash_max = 100f; 

    public float sleep_value;   // max = 100
    private float sleep_max = 100f;
    
    private int delay = 0;

    public Animator anim;
    public Animator eatindicator;
    public Animator washindicator;
    public Animator sleepindicator;

    public AudioSource eatsound;
    public AudioSource washsound;
    public AudioSource sleeepsound;

    void Start()
    {
        //eatBar = GetComponent<Image>();
        //HPBar = GetComponent<Image>();
        //sleepBar = GetComponent<Image>();

        eat_value = 50;
     
        wash_value = 50;
        
        sleep_value = 50;
    }
    
    void Update()
    {
        delay++;

        eatBar.fillAmount = eat_value / eat_max;
        HPBar.fillAmount = wash_value / wash_max;
        sleepBar.fillAmount = sleep_value / sleep_max;
        
        if(delay >= 550)
        {
            value_decay();

            delay = 0;
        }

        max_value();
    }

    void value_decay()
    {
        if (eat_value > 1)
        {
            eat_value -= Random.Range(1, 6);
        }

        if (wash_value > 1)
        {
            wash_value -= Random.Range(1, 6);
        }

        if (sleep_value > 1)
        {
            sleep_value -= Random.Range(1, 6);
        }
    }

    void max_value()
    {
        if (eat_value > 100)
        {
            eat_value = 100;
        }

        if (wash_value > 100)
        {
            wash_value = 100;
        }

        if (sleep_value > 100)
        {
            sleep_value = 100;
        }
    }

    public void eat()
    {
        eat_value += 20;
        Debug.Log("EEATTTTTTT");
        anim.SetTrigger("isEat");
        eatindicator.SetTrigger("eat");
        eatsound.Play();
    }

    public void wash()
    {
        wash_value += 20;
        anim.SetTrigger("isBath");
        washindicator.SetTrigger("wash");
        washsound.Play();
        Debug.Log("WASSSHHHH");
    }

    public void sleep()
    {
        sleep_value += 20;
        anim.SetTrigger("isSleep");
        sleepindicator.SetTrigger("sleep");
        sleeepsound.Play();
        Debug.Log("ZZZZZZZ");
    }
    
    public void exit()
    {
        Debug.Log("QUIIITTT");
        Application.Quit();
    }
}
