using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabSpades;
    [SerializeField] List<GameObject> prefabClubs;
    [SerializeField] List<GameObject> prefabDiamonds;
    [SerializeField] List<GameObject> prefabHearts;
    [SerializeField] List<GameObject> prefabJokers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // シャッフル
    public void ShuffleCards(List<CardController> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int rnd = Random.Range(0, cards.Count);
            CardController tmp = cards[i];

            cards[i] = cards[rnd];
            cards[rnd] = tmp;
        }
    }

    // カード作成
    List<CardController> createCards(SuitType suittype)
    {
        List<CardController> ret = new List<CardController>();

        // カードの種類(デフォルト)
        List<GameObject> prefabcards = prefabSpades;
        Color suitcolor = Color.black;

        if (SuitType.Club == suittype)
        {
            prefabcards = prefabClubs;
        }
        else if (SuitType.Diamond == suittype)
        {
            prefabcards = prefabDiamonds;
            suitcolor = Color.red;
        }
        else if (SuitType.Heart == suittype)
        {
            prefabcards = prefabHearts;
            suitcolor = Color.red;
        }
        else if (SuitType.Joker == suittype)
        {
            prefabcards = prefabJokers;
        }

        // カード生成
        for (int i = 0; i < prefabcards.Count; i++)
        {
            GameObject obj = Instantiate(prefabcards[i]);

            // 当たり判定追加
            BoxCollider bc = obj.AddComponent<BoxCollider>();
            // 当たり判定検知用
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            // カード同士の当たり判定と物理演算を使わない
            bc.isTrigger = true;
            rb.isKinematic = true;

            // カードにデータをセット
            CardController ctrl = obj.AddComponent<CardController>();

            ctrl.Suit = suittype;
            ctrl.SuitColor = suitcolor;
            ctrl.PlayerNo = -1;
            ctrl.No = i + 1;

            ret.Add(ctrl);
        }

        return ret;
    }
}
