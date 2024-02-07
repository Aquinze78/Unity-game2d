using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float maxTime = 5.6f;
        Debug.Log(maxTime);
        Debug.Log(DireBonjour("MMI"));
    }

    string DireBonjour(string name) {
        return "Bonjour " +name;
        }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)) {
            Debug.Log(DireBonjour("TC"));
        }
    }
}

