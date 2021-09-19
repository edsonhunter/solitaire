using System;
using Solitario.Controller;
using Solitario.Scene.Interface;
using Solitario.Service;
using Solitario.Service.Interface;
using UnityEngine;

namespace Solitario.Scene
{
    public class GameplayScene : MonoBehaviour, IBaseScene
    {
        [field: SerializeField] private CardController CardPrefab { get; set; }
        [field: SerializeField] private RectTransform DeckPosition { get; set; }

        private IGameService GameService { get; set; }
        
        private void Start()
        {
            GameService = new GameService();
            GameService.StartGame();
            foreach (var card in GameService.Deck.Cards)
            {
                var cardController = Instantiate(CardPrefab, DeckPosition);
                cardController.Init(card);
                Debug.Log($"{card.Suit} | {card.Value}");
            }
        }
    }
}