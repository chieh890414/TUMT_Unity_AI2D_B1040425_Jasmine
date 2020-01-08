using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class npc : MonoBehaviour
{


    public enum state
    {
        normal, notComplete, complete
    }

    public state _state;

    [Header("對話內容")]
    public string saystart = "嗨囉Jasmine! 妳現在要去尋找傳說中的生命樹 這是妳的宿命 記得只有一個樹是真的";
    public string saynotcomplete = "生命樹呢?";
    public string saycomplete = "妳終於成功了 現在妳將成為新的生命樹守護神";

    [Header("對話速度")]
    public float speed = 0.01f;

    [Header("任務相關")]
    public bool missingcomplete;
    public int countPlayer;
    public int countFinish = 1;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    public GameObject final;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Jasmine")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Jasmine")
            SayClose();
    }

    /// <summary>
    /// 對話:打字效果
    /// </summary>
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;

        switch (_state)
        {
            case state.normal:
                StartCoroutine(ShowDialog(saystart));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(saynotcomplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(saycomplete));
                final.SetActive(true);
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            yield return new WaitForSeconds(speed);
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    /// <summary>
    /// 玩家取得道具
    /// </summary>
    public void PlayerGet()
    {
        countPlayer++;
    }
}
