using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager GameInstance;
    List<string> PlayerCard;
    [SerializeField] Image[] Cards;
    [SerializeField] int PlayerIndex;

    private void Start()
    {
        GameInstance = GameObject.Find("GameManager").GetComponent<GameManager>();
        PlayerCard = GameInstance.SendCard(PlayerIndex);
        bool[] status = { false, false, false, false, false };

        if (PlayerCard != null )
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                Cards[i].color = i < 2 ? Color.cyan : Color.red;
                status[i] = i < 2 ? true : false;
            }
        }

        Debug.LogWarning($"Player cards: {string.Join(", ", PlayerCard)}");
        Debug.LogWarning($"Cards status: {string.Join(", ", status[0].ToString())}");
    }
}
