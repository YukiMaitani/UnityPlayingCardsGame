using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestTweenDirector : MonoBehaviour
{
    [SerializeField] GameObject card1;
    [SerializeField] GameObject card2;

    private void Start()
    {
        Vector3 pos = card2.transform.position;
        card1.transform.DOMove(pos, 5);
        card1.transform.DORotate(Vector3.zero, 5)
            .OnComplete(() =>
            {
                print("回転完了！");
            });
    }
}
