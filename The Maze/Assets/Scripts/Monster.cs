using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseGameEntity 
{
    private State m_CurrentState;
    public int m_Health;
    public string m_Location;
    public int m_Symbol;

    public Monster(int ID) { }
    

    public void Update()
    {
        /*if (m_CurrentState)
        {
            m_CurrentState.Execute(this);
        }
        */
    }

    public Monster ChangeState(State NewState)
    {
        //Debug.Assert(m_CurrentState);

        //call the exit method of the existing state
        m_CurrentState.Exit(this);

        //change state to the new state
        m_CurrentState = NewState;

        //call the entry method of the new state
        m_CurrentState.Enter(this);

        return this;
    }
}
