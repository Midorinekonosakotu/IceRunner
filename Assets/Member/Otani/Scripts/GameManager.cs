using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] Player player; �v���C���[������������ǉ�
    public static GameManager instance = null;
    public int Score = 0;

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
        /* �G�Ɠ����������̏���
        if(player.isHit == true)
        {
            GameOver();
        }*/
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

}
