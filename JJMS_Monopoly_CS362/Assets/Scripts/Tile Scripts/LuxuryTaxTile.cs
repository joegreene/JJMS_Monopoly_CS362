using UnityEngine;
using System.Collections;

public class LuxuryTaxTile : GameTile {
  void PlayerLanded(ref Player p)
  {
    //deduct from player's cash amount by 10% of total property value
    p.DecreaseCashAmount(.10*p.GetTotalWorth());
  }
}
