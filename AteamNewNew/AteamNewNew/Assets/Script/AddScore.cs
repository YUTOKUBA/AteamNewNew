using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    int score = 0;

    //メッセージを受け取る
    void OnScore(int num)
    {
        //scoreに受け取った値を追加する
        score += num;

        //Textコンポーネントを取得する
        Text scoreText = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        scoreText.text = score.ToString();
    }
}
