using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour
{
    public int hp;
    void Start()
    {
        if (this.CompareTag("CastleHuman") || this.CompareTag("CastleOrc"))
            hp = 200;        
        if (this.CompareTag("TowerHuman") || this.CompareTag("TowerOrc"))
            hp = 60;        
        if (this.CompareTag("ResourcesHuman") || this.CompareTag("ResourcesOrc"))
            hp = 40;        
        if (this.CompareTag("HouseHuman") || this.CompareTag("HouseOrc"))
            hp = 30;        
        if (this.CompareTag("FactoryHuman") || this.CompareTag("FactoryOrc"))
            hp = 50;
    }
    
}
