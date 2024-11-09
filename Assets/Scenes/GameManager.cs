using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameManager setting
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

        List<string> ShuffleCardList = Shuffle();
        PlayerCards(ShuffleCardList);
    }



    [Header("Set Play")]
    public Dictionary<string, int> Card = new Dictionary<string, int>()
    {
        {"A", 1},
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
        {"J", -11 }, {"Q", -12 }, {"K", -13 }
    };
    public Dictionary<string, int> Joker = new Dictionary<string, int>()
    {
        {"ColorJoker", 0 }, {"BlackJoker", 1/2 }
    };

    public List<string> CardList;

    protected List<string> Shuffle()
    {
        //카드 세팅
        CardList = new List<string>(Card.Keys);
        for (int i = 0; i < 8; i++)
        {
            CardList.AddRange(Card.Keys);
            if (i >= 4) { CardList.AddRange(Joker.Keys); }
        }

        //카드 재배열
        int CardCount = CardList.Count;
        int k = 0;

        for (int i = 0; i < CardCount; i++, k++)
        {
            int j = Random.Range(0, CardCount);

            string temp = CardList[i];
            CardList[i] = CardList[j];
            CardList[j] = temp;
        }

        return CardList;
    }

    List<List<string>> PlayerCard;

    protected void PlayerCards(List<string> CardList)
    {
        PlayerCard = new List<List<string>>();   
        for (int i = 0; i < 4; i++)
        {
            PlayerCard.Add(new List<string>());
        }

        int CardIndex = 0;
        for (int RoundCount = 0; RoundCount < 5; RoundCount++)
        {
            for (int PlayerIndex = 0; PlayerIndex < 4; PlayerIndex++)
            {
                if (CardIndex < CardList.Count)
                {
                    PlayerCard[PlayerIndex].Add(CardList[CardIndex]);
                    CardIndex++;
                }
            }
        }

        for (int i = 0; i < PlayerCard.Count; i++)
        {
            Debug.Log($"Player {i + 1} cards: {string.Join(", ", PlayerCard[i])}");
        }
    }

    public List<string> SendCard(int Playerindex)
    {
        List<string> Card = PlayerCard[Playerindex];
        return Card;
    }
}
