using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    public bool sawWater;

    private void OnTriggerEnter2D(Collider2D col)
    {
        sawWater = true;
    }

}
