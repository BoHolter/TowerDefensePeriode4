using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    
    
        public static int Money = 1000;
        public int StartMoney;
        void start()
        {
            Money = StartMoney;
        }
        // Update is called once per frame
        void Update()
    {
        
    }
}
