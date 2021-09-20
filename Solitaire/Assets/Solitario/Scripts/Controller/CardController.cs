using System;
using DG.Tweening;
using Solitario.Domain.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solitario.Controller
{
    public class CardController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [field: SerializeField] private Image RankSprite { get; set; }
        [field: SerializeField] private Image SuitSprite { get; set; }
        [field: SerializeField] private Image SuitSmallSprite { get; set; }
        [field: SerializeField] private RectTransform FrontSide { get; set; }
        [field: SerializeField] private RectTransform BackSide { get; set; }
        [field: SerializeField] private RectTransform Holder { get; set; }
        [field: SerializeField] private CardProperties Properties { get; set; }

        private Vector2 CurrentPosition { get; set; }
        private RectTransform Parent { get; set; }

        public RectTransform RectTransform { get; private set; }
        private Vector2 PointerOffset { get; set; }
        private ICard Card { get; set; }
        private bool Drag { get; set; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
            CurrentPosition = RectTransform.anchoredPosition;
            Parent = transform.parent.GetComponent<RectTransform>();
        }

        public void Init(ICard card)
        {
            Card = card;
            var (rank, suit) = Properties.UpdateCardImage((int) Card.Value, (int) Card.Suit);
            RankSprite.sprite = rank;
            SuitSprite.sprite = suit;
            SuitSmallSprite.sprite = suit;

            RankSprite.color =
                (int) Card.Suit % 2 == 0 ? Color.red : Color.black;
        }

        public Tween Flip()
        {
            Card.Flip();
            
            FrontSide.gameObject.SetActive(!Card.FaceUp);
            BackSide.gameObject.SetActive(Card.FaceUp);

            var seq = DOTween.Sequence();
            seq.Append(Holder.DOScaleX(0, 0.1f));
            seq.AppendCallback(() =>
            {
                FrontSide.gameObject.SetActive(Card.FaceUp);
                BackSide.gameObject.SetActive(!Card.FaceUp);
            });
            seq.Append(Holder.DOScaleX(1, 0.1f));
            return seq;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!Card.FaceUp)
                return;

            SetNewPosition(eventData);
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            if (!Card.FaceUp)
                return;
            
            DragCard(eventData);
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!Card.FaceUp)
                return;
            
            ResetMove();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!Card.Interactive)
                return;
            
            var otherCardController = other.gameObject.GetComponent<CardController>();
            if (otherCardController != null)
            {
                var otherCard = otherCardController.Card;
                if (otherCard.FaceUp && otherCard.Value == Card.Value + 1)
                {
                    Parent = otherCardController.RectTransform;
                }
            }
        }

        private void SetNewPosition(PointerEventData data)
        {
            transform.SetAsLastSibling();
            
            CurrentPosition = RectTransform.anchoredPosition;
            var clickPos = data.position;
            PointerOffset = RectTransform.anchoredPosition;
            var offsetY = clickPos.y - 1334 - PointerOffset.y;
            var offsetX = clickPos.x - 750 - PointerOffset.x;

            PointerOffset = new Vector2(offsetX, offsetY);
        }

        private void DragCard(PointerEventData data)
        {
            Drag = true;
            
            var dragPosition = data.position;
            dragPosition.y = data.position.y - 1334 - PointerOffset.y;
            dragPosition.x = data.position.x - 750 - PointerOffset.x;
            RectTransform.anchoredPosition = dragPosition;
        }

        private void ResetMove()
        {
            Drag = false;
            RectTransform.anchoredPosition = CurrentPosition;
            
            transform.SetParent(Parent);
            CurrentPosition = Parent.anchoredPosition - new Vector2(0, RectTransform.rect.height / 3);
        }
    }
}