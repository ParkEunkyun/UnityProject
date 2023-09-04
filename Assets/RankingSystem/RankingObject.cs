using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ranking", menuName = "Ranking System/Ranking")]

public class RankingObject : ScriptableObject
{
    [SerializeField]
    private Ranking container = new Ranking();
    
    public RankingSlot[] Slots => container.slots;
}
