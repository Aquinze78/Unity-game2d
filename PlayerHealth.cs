using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxLifePoints = 3;

    public int currentLifePoints;
    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    public void Hurt(int damage) {
        currentLifePoints = currentLifePoints - damage;
    }

   

}