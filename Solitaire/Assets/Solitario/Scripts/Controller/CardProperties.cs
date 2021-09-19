using System;
using System.Collections.Generic;
using UnityEngine;

namespace Solitario.Controller
{
    [CreateAssetMenu(fileName = "Card", menuName = "Solitaire/Cards")]
    public class CardProperties : ScriptableObject
    {
        [field: SerializeField] private List<Sprite> Ranks { get; set; }
        [field: SerializeField] private List<Sprite> Suit { get; set; }

        public Tuple<Sprite, Sprite> UpdateCardImage(int rankIdx, int suitIdx)
        {
            return new Tuple<Sprite, Sprite>(Ranks[rankIdx], Suit[suitIdx]);
        }
    }
}