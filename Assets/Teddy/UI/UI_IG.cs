using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_IG : MonoBehaviour
{
   public static UI_IG Instance { get; private set; }
   
   public UI_Inhibitor uiInhibitor;
   public UI_Wave uiWave;
   public UI_PlayerUI player1;
   public UI_PlayerUI player2;

   private void Awake()
   {
      Instance = this;
   }


   public void InitializeInhibitor(int maxVitality)
   {
      uiInhibitor.Initialize(maxVitality);
   }
   
   public void InitializePlayer(int playernumber,int maxVitality)
   {
      if(playernumber == 1){player1.Initialize(maxVitality);}
      else if(playernumber == 2){player2.Initialize(maxVitality);}
   }
   
   public void InitializeWave(float percentDone, int numberWave)
   {
      uiWave.Initialize(percentDone,numberWave);
   }
   
   public void SetPlayerUI(int playernumber,int maxVitality)
   {
      if(playernumber == 1){player1.SetValues(maxVitality);}
      else if(playernumber == 2){player2.SetValues(maxVitality);}
   }

   public void SetWaveUI(float percentDone, int numberWave)
   {
      uiWave.SetValues(percentDone, numberWave);
   }
   
   public void SetInhibitorUI(int maxVitality)
   {
      uiInhibitor.SetValues(maxVitality);
   }
   
}
