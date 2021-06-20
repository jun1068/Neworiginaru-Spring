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
    public int turn = 2;
    public GameObject target;
    bool turnkeeper1 = true;
    bool turnkeeper2 = true;
    public int goal = 0;
    bool goalkeeper = true;
    public int[,] number = new int[9, 12];
    int posix;
    int posiz;
    int posix3;
    int posiz3;
    public GameObject token;
    int Fire;
    public Material Fire1;
    public Material Fire2;
    public Material Fire3;
    public int Firecount;
    public int Firecount2;
    public int Firecount3;
    public int Firecount4;
    int posixs = 0;
    int posizs = 0;
    int posixs3 = 0;
    int posizs3 = 0;
    int createCount = 0;

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
            for (int i = 0; i < 4; i++)
            {
                FireCreate();
                createCount++;
            }

            if (Firecount >= 4)
            {
                Instantiate(token, new Vector3(posix, 0.75f, posiz), Quaternion.identity);
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

            createCount = 0;
            turn = 2;
        }

    }

    void TurnKeep()
    {
        turn--;
        turnkeeper1 = true;
    }

    void FireCreate()
    {
        if (createCount < 2)
        {
            posix = Random.Range(-6, 3);
            posiz = Random.Range(-5, 1);
            transform.position = new Vector3(posix, 0.75f, posiz);
            posixs = posix + 6;
            posizs = posiz + 5;
            Firecount = number[posixs, posizs];
            Firecount++;

            anotherScript.NewNumber(posixs, posizs, Firecount);
            //Debug.Log(posixs +","+posizs +"のfirecountは"+number[posixs, posizs]);
            if (Firecount == 1)
            {
                Instantiate(target, transform.position, transform.rotation);
                transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(1, 7));
                target.GetComponent<Renderer>().material = Fire1;
            }
            else if (Firecount == 2)
            {
                target.GetComponent<Renderer>().material = Fire2;
            }
            else if (Firecount == 3)
            {
                target.GetComponent<Renderer>().material = Fire3;
            }
        }

        if (createCount >= 2 && createCount <= 3)
        {
            Debug.Log("奥の処理を実行");
            posix3 = Random.Range(-6, 3);
            posiz3 = Random.Range(1, 7);
            transform.position = new Vector3(posix3, 0.75f, posiz3);
            posixs3 = posix3 + 6;
            posizs3 = posiz3 + 5;
            Firecount3 = number[posixs3, posizs3];
            Firecount3++;
            anotherScript.NewNumber(posixs3, posizs3, Firecount3);
            if (Firecount3 == 1)
            {
                Instantiate(target, transform.position, transform.rotation);
                transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(1, 7));
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
        }
    }
}