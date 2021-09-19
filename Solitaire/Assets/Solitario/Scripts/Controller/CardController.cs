using System;
using Solitario.Domain.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solitario.Controller
{
    public class CardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [field: SerializeField] private Image RankSprite { get; set; }
        [field: SerializeField] private Image SuitSprite { get; set; }
        [field: SerializeField] private Image SuitSmallSprite { get; set; }
        [field: SerializeField] private RectTransform FrontSide { get; set; }
        [field: SerializeField] private RectTransform BackSide { get; set; }
        
        [field: SerializeField] private CardProperties Properties { get; set; }
        
        private Vector2 Position { get; set; }
        private ICard Card { get; set; }

        public void Init(ICard card)
        {
            Position = transform.position;
            Card = card;
            var (rank, suit) = Properties.UpdateCardImage((int) Card.Value, (int) Card.Suit);
            RankSprite.sprite = rank;
            SuitSprite.sprite = suit;
            SuitSmallSprite.sprite = suit;
            
            RankSprite.color = 
                (int) Card.Suit % 2 == 0 ? 
                    Color.red : Color.black;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            Position = eventData.position;
        }
    }
}