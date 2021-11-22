using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //スタート画面
    public bool Start_flg;                 //スタートフラグ

    [SerializeField] private AudioSource victory_sound;      //クリア時のSE
    [SerializeField] private AudioSource BGM_Audio;          //BGM用のオーディオソース
    public bool BGM_flg;

    //時間経過
    [SerializeField]private int minute;
    [SerializeField] private int Clear_minute;
    [SerializeField]private float seconds;
    [SerializeField] private float Clear_seconds;

    //ポーズ画面
    [SerializeField]private GameObject pauseUI; //ポーズ画面
    public RectTransform pauseCursor;           //カーソル
    int Menu_Num = 0;   //メニュー選択時の番号　0:リスタート 1:タイトル 2:終了
    bool Push_Flg = false; //連続入力防止用スイッチ

    [SerializeField] private AudioClip cursor_sound;    //カーソルのSE
    [SerializeField] private AudioClip select_sound;    //セレクト時のSE
    [SerializeField] private AudioSource cursorAudio;   //SE用のオーディオソース


    //スコア表示
    GameObject Ball;    //スコアが入っているオブジェクト
    coinkesu var;       //空箱
    public GameObject Score;    //表示用

    //クリア
    [SerializeField]private GameObject clear_UI;    //クリア画面
    [SerializeField] private ParticleSystem Clear_particle; //紙吹雪のパーティクル
    bool Clear_particle_flg;        //パーティクルのフラグ
    public bool Clear_flg;                 //クリアフラグ

    //リザルト画面
    public GameObject Score_coin;    //表示用
    public GameObject Score_time;    //表示用

    //リトライ画面
    [SerializeField] private GameObject retryUI; //ポーズ画面
    public RectTransform retryCursor;           //カーソル
    bool Retry_flg = false;
    int Retry_Num = 0;   //メニュー選択時の番号　0:リスタート 1:タイトル 2:終了

    //アニメーション
    [SerializeField] Animator Start_animator;
    [SerializeField] Animator Clear_animator;

    //デバッグ用
    bool debug_mode = false;
    public GameObject x_object;
    public GameObject y_object;

    void Start()
    {
        //スタート条件の初期化
        Start_flg = true;
        BGM_flg = false;

        //経過時間の初期化
        minute = 0;
        Clear_minute = 0;
        seconds = 0f;
        Clear_seconds = 0f;

        //クリア条件の初期化
        Clear_flg = false;
        Clear_particle_flg = false;

        Retry_flg = false;

        //表示設定
        pauseUI.SetActive(false);
        clear_UI.SetActive(false);
        retryUI.SetActive(false);
        x_object.SetActive(false);
        y_object.SetActive(false);
    }

    
    void Update()
    {
        //スタート時のアニメーション表示
        if (Start_flg == true)
        {
            Game_Start();
        }

        if (BGM_flg == true)
        {
            BGM_Audio.Play();
            BGM_flg = false;
        }

        Pause_Controller();

        //スコアの取得と表示
        Ball = GameObject.Find("Ball");
        var = Ball.GetComponent<coinkesu>();
        Text score = Score.GetComponent<Text>();
        score.text = var.coin + " / 12";

        //経過時間の計測
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        //ポーズの表示
        if (Input.GetButtonDown("Pause") && Clear_flg != true && Start_flg != true)
        {
            Game_Pause();
        }
        
        //クリア画面の表示
        if (var.coin == 12 && Retry_flg == true)
        {
            Retry_menu();
        }
        else if (var.coin == 12)
        {
            BGM_Audio.Stop();
            Clear_minute = minute;
            Clear_seconds = seconds;
            Game_Clear();
        }
        Retry_Controller();
    }

    public void Game_Start()
    {
        Start_animator.SetBool("Count_Start",true);
    }

    public void Game_Pause()
    {
        //　ポーズUIのアクティブ、非アクティブを切り替え
        pauseUI.SetActive(!pauseUI.activeSelf);

        //　ポーズUIが表示されてる時は停止
        if (pauseUI.activeSelf)
        {
            BGM_Audio.Pause();
            Time.timeScale = 0f;
            //　ポーズUIが表示されてなければ通常通り進行
        }
        else
        {
            BGM_Audio.UnPause();
            Time.timeScale = 1f;
        }
        
    }

    public void Pause_Controller()
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

                    cursorAudio.PlayOneShot(cursor_sound);
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

                    cursorAudio.PlayOneShot(cursor_sound);
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
                cursorAudio.PlayOneShot(select_sound);
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Game");
            }
            else if (Menu_Num == 1 && Input.GetButtonDown("A"))
            {
                cursorAudio.PlayOneShot(select_sound);
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Title");
            }
            else if (Menu_Num == 2 && Input.GetButtonDown("A"))
            {
                cursorAudio.PlayOneShot(select_sound);
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

    public void Game_Clear()
    {

        clear_UI.SetActive(true);   //クリア画面の表示
        Clear_flg = true;           //クリアフラグをON
        Time.timeScale = 0f;        //ゲームを停止
        Clear_animator.SetBool("IsCenter", true);   //アニメーションの表示
        if (Clear_particle_flg == false)    //紙吹雪を一度だけ呼び出す
        {
            victory_sound.Play();
            Clear_particle.Play();
            Clear_particle_flg = true;
        }
        //リザルト画面の表示
        Text score_time = Score_time.GetComponent<Text>();//クリアタイムの表示
        if ((int)Clear_seconds < 10)
        {
            score_time.text = Clear_minute + " : 0" + (int)Clear_seconds;
        }
        else
        {
            score_time.text = Clear_minute + " : " + (int)Clear_seconds;
        }

        Text score_coin = Score_coin.GetComponent<Text>();//コインの枚数
        score_coin.text = var.coin + "枚";

        //ReStart
        if (Input.GetButtonDown("A"))
        {
            cursorAudio.PlayOneShot(select_sound);
            clear_UI.SetActive(false);
            Retry_flg = true;
        }
    }

    public void Retry_menu()
    {
        //リトライUIのアクティブに切り替え
        retryUI.SetActive(true);
        //リトライUI表示中は停止
        Time.timeScale = 0f;
    }

    public void Retry_Controller()
    {
        //Lスティックの入力
        float lsh = Input.GetAxis("L_stick_h");
        float lsv = Input.GetAxis("L_stick_v");

        //カーソルのの操作
        if (retryUI.activeSelf)
        {
            if (lsv == 1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Retry_Num++;
                    if (Retry_Num >= 3)
                    {
                        Retry_Num = 0;
                        retryCursor.position += new Vector3(0, 180, 0);
                    }
                    retryCursor.position += new Vector3(0, -60, 0);

                    cursorAudio.PlayOneShot(cursor_sound);
                    Debug.Log(Retry_Num);
                }
            }
            else if (lsv == -1)
            {
                if (Push_Flg == false)
                {
                    Push_Flg = true;
                    Retry_Num--;
                    if (Retry_Num <= -1)
                    {
                        Retry_Num = 2;
                        retryCursor.position += new Vector3(0, -180, 0);
                    }
                    retryCursor.position += new Vector3(0, 60, 0);

                    cursorAudio.PlayOneShot(cursor_sound);
                    Debug.Log(Retry_Num);
                }
            }
            else
            {
                Push_Flg = false;
            }
        }

        //シーンの管理
        if (retryUI.activeSelf) //ポーズ画面が表示されているとき
        {
            
            if (Retry_Num == 0 && Input.GetButtonDown("A"))
            {
                cursorAudio.PlayOneShot(select_sound);
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Game");
            }
            else if (Retry_Num == 1 && Input.GetButtonDown("A"))
            {
                cursorAudio.PlayOneShot(select_sound);
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Title");
            }
            else if (Retry_Num == 2 && Input.GetButtonDown("A"))
            {
                cursorAudio.PlayOneShot(select_sound);
                Time.timeScale = 1f;
                // UnityEditor.EditorApplication.isPlaying = false;  //デバッグ用
                Application.Quit();
            }
        }
    }
}
