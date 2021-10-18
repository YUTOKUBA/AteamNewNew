using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;

    public RectTransform pauseCursor;

	[SerializeField]
	private GameObject pauseRestart;
	[SerializeField]
	private GameObject pauseTitle;
	[SerializeField]
	private GameObject pauseEnd;

    int Menu_Num = 0;

    bool Push_Flg = false;

    void Start()
    {
        pauseUI.SetActive(false);
    }

	void Update()
	{
        float lsh = Input.GetAxis("L_stick_h");
        float lsv = Input.GetAxis("L_stick_v");
        if (Input.GetButtonDown("Pause"))
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

        //コントローラーの操作
        if (pauseUI.activeSelf)
        {
            if (lsv == 1)
            {
                if (Push_Flg == false) {
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
                if (Push_Flg == false) {
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
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
