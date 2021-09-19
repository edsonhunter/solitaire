using System;
using System.Collections.Generic;
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

        [field: SerializeField] private List<RectTransform> TableauPositions { get; set; }
        [field: SerializeField] private List<RectTransform> DiscardPositions { get; set; }
        
        private IGameService GameService { get; set; }
        private IList<CardController> CardControllers { get; set; }
        
        private void Start()
        {
            GameService = new GameService();
            GameService.StartGame();
            CreateDeck();
            DealCards();
        }

        private void CreateDeck()
        {
            CardControllers = new List<CardController>();
            foreach (var card in GameService.Deck.Cards)
            {
                var cardController = Instantiate(CardPrefab, DeckPosition);
                cardController.Init(card);
                CardControllers.Add(cardController);
            }
        }

        private void DealCards()
        {
            int cardIdx = 0;
            for (int i = 0; i < 7; i++)
            {
                CardControllers[cardIdx].Flip();
                for (int j = i; j < 7; j++)
                {
                    CardControllers[cardIdx].RectTransform.position = 
                        new Vector3(TableauPositions[j].position.x, (TableauPositions[j].position.y - i) /3, 0);
                    cardIdx++;
                }
            }
        }
    }
}