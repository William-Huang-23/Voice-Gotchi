using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int eat_value;     // max = 100

    public int wash_value;    // max = 100

    public int sleep_value;   // max = 100

    private int delay = 0;

    void Start()
    {
        eat_value = 50;

        wash_value = 50;

        sleep_value = 50;
    }
    
    void Update()
    {
        delay++;

        if(delay >= 200)
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
    }

    public void wash()
    {
        wash_value += 20;
        Debug.Log("WASSSHHHH");
    }

    public void sleep()
    {
        sleep_value += 20;
        Debug.Log("ZZZZZZZ");
    }
}
