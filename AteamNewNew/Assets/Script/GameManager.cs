using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //スタート画面
    [SerializeField] private GameObject start_UI;    //スタート画面
    bool Start_flg;                 //スタートフラグ

    //ポーズ画面
    [SerializeField]private GameObject pauseUI; //ポーズ画面
    public RectTransform pauseCursor;           //カーソル
    int Menu_Num = 0;   //メニュー選択時の番号　0:リスタート 1:タイトル 2:終了
    bool Push_Flg = false; //連続入力防止用スイッチ

    //スコア表示
    GameObject Ball;    //スコアが入っているオブジェクト
    coinkesu var;       //空箱
    public GameObject Score;    //表示用

    //クリア
    [SerializeField]private GameObject clear_UI;    //クリア画面
    bool Clear_flg;                 //クリアフラグ

    //アニメーション
    [SerializeField]Animator Clear_animator;
    [SerializeField]Animator Result_animator;

    //デバッグ用
    bool debug_mode = false;
    public GameObject x_object;
    public GameObject y_object;

    void Start()
    {
        //スタート条件の初期化
        Start_flg = true;
        //クリア条件の初期化
        Clear_flg = false;

        //表示設定
        pauseUI.SetActive(false);
        clear_UI.SetActive(false);
        x_object.SetActive(false);
        y_object.SetActive(false);
    }

    void Update()
    {
        //スタート時のアニメーション表示
        if (Start_flg == true)
        {
            Game_Start();
            Start_flg = false;
        }
        Pause_Controller();

        //スコアの取得と表示
        Ball = GameObject.Find("Ball");
        var = Ball.GetComponent<coinkesu>();
        Text score = Score.GetComponent<Text>();
        score.text = var.coin + " / 12";
        
        //ポーズの表示
        if (Input.GetButtonDown("Pause") && Clear_flg != true)
        {
            Game_Pause();
        }
        
        //クリア画面の表示
        if (var.coin == 12)
        {
            Game_Clear();
        }
    }

    void Game_Start()
    {

    }

    void Game_Pause()
    {
        //　ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);

        //　ポーズUIが表示されてる時は停止
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }

    void Pause_Controller()
    {
        //Lスティックの入力
        float lsh = Input.GetAxis("L_stick_h");
        float lsv = Input.GetAxis("L_stick_v");

        //カーソルのの操作
        if (pauseUI.activeSelf)
        {
            if (lsv == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num++;
                    if (Menu_Num >= 3)
                    {
                        Menu_Num = 0;
                        pauseCursor.position += new Vector3(0, 180, 0);
                    }
                    pauseCursor.position += new Vector3(0, -60, 0);
                    Debug.Log(Menu_Num);
                }
            }
            else if (lsv == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Menu_Num--;
                    if (Menu_Num <= -1)
                    {
                        Menu_Num = 2;
                        pauseCursor.position += new Vector3(0, -180, 0);
                    }
                    pauseCursor.position += new Vector3(0, 60, 0);
                    Debug.Log(Menu_Num);
                }
            }
            else
            {
                Push_Flg = false;
            }
        }

        //シーンの管理
        if (pauseUI.activeSelf) //ポーズ画面が表示されているとき
        {
            if (Input.GetButtonDown("X"))
            {
                if (debug_mode != true)
                {
                    debug_mode = true;
                }
                else
                {
                    debug_mode = false;
                    x_object.SetActive(false);
                    y_object.SetActive(false);
                }
            }
            if (Menu_Num == 0 && Input.GetButtonDown("A"))
            {
                Time.timeScale = 1f;
                Application.LoadLevel("Game");
            }
            else if (Menu_Num == 1 && Input.GetButtonDown("A"))
            {
                Time.timeScale = 1f;
                Application.LoadLevel("Title");
            }
            else if (Menu_Num == 2 && Input.GetButtonDown("A"))
            {
                Time.timeScale = 1f;
                pauseUI.SetActive(!pauseUI.activeSelf);
                // UnityEditor.EditorApplication.isPlaying = false;  //デバッグ用
                Application.Quit();
            }
        }

        //デバッグ用
        if (debug_mode != false)
        {
            x_object.SetActive(true);
            y_object.SetActive(true);
            Text x_text = x_object.GetComponent<Text>();
            Text y_text = y_object.GetComponent<Text>();
            x_text.text = "X = " + lsv;
            y_text.text = "Y = " + lsh;
        }

    }

    void Game_Clear()
    {

        clear_UI.SetActive(true);   //クリア画面の表示
        Clear_flg = true;           //クリアフラグをON
        Time.timeScale = 0f;        //ゲームを停止
        Clear_animator.SetBool("IsCenter", true);   //アニメーションの表示
        Result_animator.SetTrigger("IsZoom");      //

        if (Input.GetButtonDown("A"))
        {
            Clear_animator.SetBool("IsCenter", false);//アニメーションの非表示
            Time.timeScale = 1f;
            Clear_flg = false;
            Application.LoadLevel("Game");
        }
    }
}
