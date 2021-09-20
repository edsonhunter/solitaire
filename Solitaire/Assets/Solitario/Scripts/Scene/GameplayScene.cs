using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        [field: SerializeField] private DeckController DeckController { get; set; }

        [field: SerializeField] private List<RectTransform> TableauPositions { get; set; }
        [field: SerializeField] private List<RectTransform> DiscardPositions { get; set; }
        
        [field: SerializeField] private int DrawAmount { get; set; }
        
        private IGameService GameService { get; set; }
        private IList<CardController> CardControllers { get; set; }
        
        private void Start()
        {
            GameService = new GameService();
            GameService.StartGame();
            CreateDeck();
            StartCoroutine(DealCards());
            DeckController.Init(CardControllers, new SettingsService(DrawAmount));
        }

        private void CreateDeck()
        {
            CardControllers = new List<CardController>();
            foreach (var card in GameService.Deck.Cards)
            {
                var cardController = Instantiate(CardPrefab, DeckController.transform);
                cardController.Init(card);
                CardControllers.Add(cardController);
            }
        }

        private IEnumerator DealCards()
        {
            int cardIdx = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = i; j < 7; j++)
                {
                    yield return new WaitForSeconds(0.1f);
                    var seq = DOTween.Sequence();
                    seq.Append(CardControllers[cardIdx].RectTransform.DOMove(
                        new Vector3(TableauPositions[j].position.x, (TableauPositions[j].position.y - i) / 3, 0),
                        1));
                    if(j == i)  
                        seq.Append(CardControllers[cardIdx].Flip());
                   
                    CardControllers[cardIdx].transform.SetParent(TableauPositions[j]);
                    CardControllers[cardIdx].transform.SetAsLastSibling();
                    cardIdx++;
                }
            }
        }
    }
}