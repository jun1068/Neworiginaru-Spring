using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireScript : MonoBehaviour
{
    
    private FireCountManager anotherScript;
    public GameObject anotherObject;
    // Start is called before the first frame update
    void Start()
    {
        anotherScript = anotherObject.GetComponent<FireCountManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Destroy");
            
            int posix = (int)this.transform.position.x;
            int posiz = (int)this.transform.position.z;
            int posixs = posix + 6;
            int posizs = posiz + 5;

            int posix2 = (int)this.transform.position.x;
            int posiz2 = (int)this.transform.position.y;
            int posixs2 = posix2 + 6;
            int posizs2 = posiz2 - 9;

            anotherScript.NewNumber(posixs, posizs,0);
            anotherScript.NewNumber2(posixs2, posizs2, 0);


            Destroy(this.gameObject);
            //Debug.Log(posixs +","+posizs +"のfirecountは"+anotherScript.number[posixs, posizs]);
            //Debug.Log(anotherScript.number[2, 2]);

            //Debug.Log(posixs);
            //Debug.Log(posizs);
            //Debug.Log(posixs +","+posizs +"のfirecountは"+anotherScript.number[posixs, posizs]);



        }
    }
}
