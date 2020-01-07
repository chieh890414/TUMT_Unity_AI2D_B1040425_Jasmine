﻿using UnityEngine;
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
    public string saystart = "嗨囉Jasmine 妳需要玩成任務!";
    public string saynotcomplete = "還沒完成哦!";
    public string saycomplete = "恭喜妳過關!";

    [Header("對話速度")]
    public float speed = 0.01f;

    [Header("任務相關")]
    public bool missingcomplete;
    public int countPlayer;
    public int countFinish = 10;

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;

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
