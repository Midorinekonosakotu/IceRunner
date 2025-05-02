using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Player player; プレイヤーが完成したら追加
    public static GameManager instance = null;
    public int Score = 0;

    private void Awake()
    {
        // シングルトン
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* 敵と当たった時の処理
        if(player.isHit == true)
        {
            GameOver();
        }*/
    }

    void GameOver()
    {
        // GameOver処理
        // GameOverアニメーションをここに入れる
        SceneManager.LoadScene("");
    }

    public void OpenSetting()
    {

    }

}
