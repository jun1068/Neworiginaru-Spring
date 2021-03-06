using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
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
    public int[,] number2 = new int[9, 12];
    int posix;
    int posiz;
    int posix3;
    int posiz3;
    //
    int posix2;
    int posiz2;
    int posix4;
    int posiz4;
    //
    public GameObject token;
    int Fire;
    public Material Fire1;
    public Material Fire2;
    public Material Fire3;
    //public Material Fire10;//試験用
    public int Firecount;
    public int spreadFireCount;
    public int Firecount3;
    public int Firecount2;
    public int Firecount4;
    int posixs = 0;
    int posizs = 0;
    int posixs3 = 0;
    int posizs3 = 0;
    //
    int posixs2 = 0;
    int posizs2 = 0;
    int posixs4 = 0;
    int posizs4 = 0;
    //
    int createCount = 0;
    int tokenPositionX;
    int tokenPositionZ;
    private Vector3 firePosition;
    int researchX = 0;
    int researchZ = 0;

    public GameObject anotherObject;
    private FireCountManager anotherScript;

    public int FireCount0 { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        anotherScript = anotherObject.GetComponent<FireCountManager>();
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

                if ((Player.transform.position.x - mousePosition.x) * (Player.transform.position.x - mousePosition.x) + (Player.transform.position.z - mousePosition.z) * (Player.transform.position.z - mousePosition.z) <=1)
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
                        SceneManager.LoadScene("goal");
                    }
                }
            }

        }

        //Fireの発生条件
        if (turn == 0)
        {
            if (Fire <= 2)
            {
                createCount = 0;
                for (int i = 0; i < 8; i++)
                {
                    FireCreate();
                    createCount++;
                }
            }
            else if (Fire >= 3)
            {
                createCount = 0;
                for (int i = 0; i < 6; i++)
                {
                    FireCreate();
                    createCount++;
                }
            }
            if (Firecount >= 4)
            {
                Instantiate(token, new Vector3(posix, 0.75f, posiz), Quaternion.identity);
                Fire++;
                //今後の行列で使うためにpositionにそれぞれ計算を加える
                tokenPositionX = posix + 6;
                tokenPositionZ = posiz + 5;
                SpreadFire();
            }
            if (Firecount3 >= 4)
            {
                Instantiate(token, new Vector3(posix3, 0.75f, posiz3), Quaternion.identity);
                Fire++;
                tokenPositionX = posix3 + 6;
                tokenPositionZ = posiz3 + 5;
                SpreadFire();
            }
            if (Firecount2 >= 4)
            {
                Instantiate(token, new Vector3(posix2, 0.75f, posiz2), Quaternion.identity);
                Fire++;
                tokenPositionX = posix2 + 6;
                tokenPositionZ = posiz2 - 9;
                SpreadFire();
            }
            if (Firecount4 >= 4)
            {
                Instantiate(token, new Vector3(posix4, 0.75f, posiz4), Quaternion.identity);
                Fire++;
                tokenPositionX = posix4 + 6;
                tokenPositionZ = posiz4 - 9;
                SpreadFire();
            }

            if (Fire >= 4)
            {
                Debug.Log("GameOver");
                SceneManager.LoadScene("gameover"); 
            }

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
        if (createCount >=4 && createCount <= 5)
            {
                posix2 = Random.Range(-6, 3);
                posiz2 = Random.Range(9, 15);
                transform.position = new Vector3(posix2, 0.75f, posiz2);
                posixs2 = posix2 + 6;
                posizs2 = posiz2 - 9;
                Firecount2 = number2[posixs2, posizs2];
                Firecount2++;
                //anotherScript.NewNumber2(posixs2, posizs2, Firecount2);
                if (Firecount2 == 1)
                {
                    Instantiate(target, transform.position, transform.rotation);
                    transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(9, 15));
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
            }
            if (createCount >= 6 && createCount <= 7)
            {
                posix4 = Random.Range(-6, 3);
                posiz4 = Random.Range(15, 21);
                transform.position = new Vector3(posix4, 0.75f, posiz4);
                posixs4 = posix4 + 6;
                posizs4 = posiz4 - 9;
                Firecount4 = number2[posixs4, posizs4];
                Firecount4++;
                //anotherScript.NewNumber2(posixs4, posizs4, Firecount4);
                if (Firecount4 == 1)
                {
                    Instantiate(target, transform.position, transform.rotation);
                    transform.position = new Vector3(Random.Range(-6, 3), 0.75f, Random.Range(15, 21));
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
            }
        }
    }

    void SpreadFire()
    {
        //全部の行列について揃っているのかを調べる
        for (researchX = 0; researchX < 9; researchX++)
        {
            for (researchZ = 0; researchZ < 12; researchZ++)
            {
                //8方向1マス以内である時
                if (researchX - tokenPositionX <= 1 && researchX - tokenPositionX >= -1 && researchZ - tokenPositionZ <= 1 && researchZ - tokenPositionZ >= -1)
                {
                    //同じマスの時は処理を除外
                    if (researchX - tokenPositionX != 0 || researchZ - tokenPositionZ != 0)
                    {
                        spreadFireCount = number[researchX, researchZ];
                        spreadFireCount++;
                        anotherScript.NewNumber(researchX, researchZ, spreadFireCount);
                        //行列の位置からtransformの位置に戻す
                        firePosition = new Vector3(researchX - 6, 0.75f, researchZ - 5);
                        newFire();//作成時とは別にFirecountの処理を実行
                    }

                }
            }
        }
    }

    void newFire()
    {
        if (spreadFireCount == 1)
        {
            Instantiate(target, firePosition, transform.rotation);
            target.GetComponent<Renderer>().material = Fire1;
        }
        else if (spreadFireCount == 2)
        {
            target.GetComponent<Renderer>().material = Fire2;
        }
        else if (spreadFireCount == 3)
        {
            target.GetComponent<Renderer>().material = Fire3;
        }
    }

}