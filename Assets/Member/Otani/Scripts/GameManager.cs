using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Player player; �v���C���[������������ǉ�
    [SerializeField] private TextMeshProUGUI _scoreText;
    public static GameManager instance = null;
    private int _score = 0;

    private void Awake()
    {
        // �V���O���g��
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
        //�G�Ɠ����������̏���
        //if (player.isHit == true)
        //{
        //    GameOver();
        //}
    }

    void GameOver()
    {
        // GameOver����
        // GameOver�A�j���[�V�����������ɓ����
        SceneManager.LoadScene("");
    }

    public void OpenSetting()
    {

    }

    public void AddScore(int _scoreAmount)
    {
        _score += _scoreAmount;
        _scoreText.text = $"Score : {_score}";
    }

}
