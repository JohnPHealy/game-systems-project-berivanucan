using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameEntity
{

    int m_ID; // unique number for every entity

    static int m_iNextValidID; //for new entities instantiated

    void SetID(int val) { }

    public BaseGameEntity(int id)
    {
        SetID(id);
    }
    public BaseGameEntity() { }
    public int ID() { return m_iNextValidID; } 


}
