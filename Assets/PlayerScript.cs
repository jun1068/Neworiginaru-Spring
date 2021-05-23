using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    public Text gameText;
    public Text goaltext;
    public GameObject Player;
    public Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;
    public int turn =2;
    public GameObject target;
    bool turnkeeper1 = true;
    bool turnkeeper2 = true;
    public int goal = 0;
    bool goalkeeper=true;
    public int[,] number = new int[9,12];
    int posix;
    int posiz;
    int posix2;
    int posiz2;
    int posix3;
    int posiz3;
    int posix4;
    int posiz4;
    public GameObject token;
    int Fire;
    public Material Fire1;
    public Material Fire2;
    public Material Fire3;
    public int Firecount;
    public int Firecount2;
    public int Firecount3;
    public int Firecount4;

    public GameObject anotherObject;
    private FireCountManager anotherScript;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        anotherScript = anotherObject.GetComponent<FireCountManager>();
        goaltext.text = "";
        gameText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info = new RaycastHit();
            bool is_hit = Physics.Raycast(ray, out hit_info, 100f);
            
            if (is_hit)
            {
                Vector3 pos = hit_info.transform.position;
                var mousePosition = new Vector3(pos.x, 0.8f, pos.z);
                
                
                if ((Player.transform.position.x - mousePosition.x) * (Player.transform.position.x - mousePosition.x) + (Player.transform.position.z - mousePosition.z) * (Player.transform.position.z - mousePosition.z) <= 1)
                {
                    
                    currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                    Player.transform.position = mousePosition;
                    
                    if (turnkeeper1)
                    {
                        //瞬間移動防止
                        Invoke("TurnKeep", 0.35f);
                        turnkeeper1 = false;
                    }
                }
                if (Player.transform.position.z == 6)
                {
                    //一度のみ処理を実行
                    if (goalkeeper)
                    {
                        goal++;
                        goalkeeper = false;
                        Debug.Log("対岸についた");
                       
                    }
                    
                }
                if (goal >= 1)
                {
                    if (Player.transform.position.z == -5)
                    {
                        goaltext.text = "GOAL";
                    }
                }
            } 
            
            
        }

        //Fireの発生条件
        if (turn == 0)
        {
            posix = Random.Range(-6, 3);
            posiz = Random.Range(-5, 1);
            transform.position = new Vector3(posix, 0.75f, posiz);
            //原点が(-6,-5)なので、場所と行列を合わせる
            int posixs = posix　+ 6;
            int posizs = posiz + 5;
            Firecount = number[posixs, posizs];
            Firecount++;
            
            anotherScript.NewNumber(posixs,posizs,Firecount);
            //Debug.Log(posixs +","+posizs +"のfirecountは"+number[posixs, posizs]);
            if (Firecount == 1) {
                target.GetComponent<Renderer>().material = Fire1;
            }else if (Firecount == 2){
                target.GetComponent<Renderer>().material = Fire2;
            }else if (Firecount == 3)
            {
                target.GetComponent<Renderer>().material = Fire3;
            }

            //火を生成
            Instantiate(target, transform.position, transform.rotation);

            transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(1, 7));
            
            posix2 = Random.Range(-6, 3);
            posiz2 = Random.Range(-5, 1);
            transform.position = new Vector3(posix2, 0.75f, posiz2);
            int posixs2 = posix2 + 6;
            int posizs2 = posiz2 + 5;
            Firecount2 = number[posixs2, posizs2];
            Firecount2++;
            anotherScript.NewNumber(posixs2, posizs2, Firecount2);
            if (Firecount2 == 1)
            {
                target.GetComponent<Renderer>().material = Fire1;
            }
            else if (Firecount2 == 2)
            {
                target.GetComponent<Renderer>().material = Fire2;
            }
            else if (Firecount2 == 3)
            {
                target.GetComponent<Renderer>().material = Fire3;
            }
            Instantiate(target, transform.position, transform.rotation);
            transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(-1, 7));
            

            posix3 = Random.Range(-6, 3);
            posiz3 = Random.Range(1, 7);
            transform.position = new Vector3(posix3, 0.75f, posiz3);
            int posixs3 = posix3 + 6;
            int posizs3 = posiz3 + 5;
            Firecount3 = number[posixs3, posizs3];
            Firecount3++;
            anotherScript.NewNumber(posixs3, posizs3, Firecount3);
            if (Firecount3 == 1)
            {
                target.GetComponent<Renderer>().material = Fire1;
            }
            else if (Firecount3 == 2)
            {
                target.GetComponent<Renderer>().material = Fire2;
            }
            else if (Firecount3 == 3)
            {
                target.GetComponent<Renderer>().material = Fire3;
            }
            Instantiate(target, transform.position, transform.rotation);
            transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(1, 7));
            
            posix4 = Random.Range(-6, 3);
            posiz4 = Random.Range(1, 7);
            transform.position = new Vector3(posix4, 0.75f, posiz4);
            int posixs4 = posix4 + 6;
            int posizs4 = posiz4 + 5;
            Firecount4 = number[posixs4, posizs4];
            Firecount4++;
            anotherScript.NewNumber(posixs4, posizs4, Firecount4);
            if (Firecount4 == 1)
            {
                target.GetComponent<Renderer>().material = Fire1;
            }
            else if (Firecount4 == 2)
            {
                target.GetComponent<Renderer>().material = Fire2;
            }
            else if (Firecount4 == 3)
            {
                target.GetComponent<Renderer>().material = Fire3;
            }
            Instantiate(target, transform.position, transform.rotation);
            transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(1, 7));
               
            if (Firecount >= 4)
            {
                Instantiate(token,new Vector3(posix, 0.75f, posiz), Quaternion.identity);
                Fire++;

            }
            if (Firecount3 >= 4)
            {
                Instantiate(token, new Vector3(posix3, 0.75f, posiz3), Quaternion.identity);
                Fire++;
            }

            if (Fire >= 4) 
            {
                Debug.Log("GameOver");
                gameText.text = "GameOver";
            }

            turn = 2;

        }
       
    }

    void TurnKeep()
    {
        turn--;
        turnkeeper1 = true;
    }
    

}

    