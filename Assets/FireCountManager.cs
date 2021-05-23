using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCountManager : MonoBehaviour
{
    public int[,] number = new int[9, 12];

    public GameObject anotherObject;
    private PlayerScript anotherScript;

    // Start is called before the first frame update
    void Start()
    {
        anotherScript = anotherObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewNumber(int x,int y,int z)
    {
        
        number[x, y] = z;
        anotherScript.number = number;
        
    }
}
