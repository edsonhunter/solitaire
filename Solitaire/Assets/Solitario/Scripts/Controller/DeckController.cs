using System.Collections.Generic;
using DG.Tweening;
using Solitario.Service.Interface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solitario.Controller
{
    public class DeckController : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] private RectTransform DeckDealPosition { get; set; }

        private RectTransform DeckPosition { get; set; }
        private IList<CardController> CardControllers { get; set; }
        private ISettingsService SettingsService { get; set; }

        private void Start()
        {
            DeckPosition = GetComponent<RectTransform>();
        }

        public void Init(IList<CardController> cards, ISettingsService settingsService)
        {
            SettingsService = settingsService;
            CardControllers = cards;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            for (var cardIdx = 1; cardIdx < SettingsService.DrawAmount; cardIdx++)
            {
                var cardToMove = CardControllers[CardControllers.Count - cardIdx].RectTransform;
                var seq = DOTween.Sequence();
                seq.Insert(0, cardToMove.DOMove(new Vector3(DeckDealPosition.position.x, DeckDealPosition.position.y, 0), 1));
                seq.Insert(0, CardControllers[CardControllers.Count - cardIdx].Flip());
            }
        }
    }
}