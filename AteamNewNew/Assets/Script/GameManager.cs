using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
	[SerializeField]
	private GameObject pauseCursor;

	[SerializeField]
	private GameObject pauseRestart;
	[SerializeField]
	private GameObject pauseTitle;
	[SerializeField]
	private GameObject pauseEnd;

	void Start()
    {
        pauseUI.SetActive(false);
    }

	void Update()
	{
		//if (Input.GetButtonDown("Pause"))
		//{
		//	//　ポーズUIのアクティブ、非アクティブを切り替え
		//	pauseUI.SetActive(!pauseUI.activeSelf);

		//	//　ポーズUIが表示されてる時は停止
		//	if (pauseUI.activeSelf)
		//	{
		//		Time.timeScale = 0f;
		//		//　ポーズUIが表示されてなければ通常通り進行
		//	}
		//	else
		//	{
		//		Time.timeScale = 1f;
		//	}
			
		//}
		float lsh = Input.GetAxis("L_stick_h");
		float lsv = Input.GetAxis("L_stick_v");
		if ((lsh != 0) || (lsv != 0))
		{
			Debug.Log("L stick:" + lsh + "," + lsv);

		}
	}
}
