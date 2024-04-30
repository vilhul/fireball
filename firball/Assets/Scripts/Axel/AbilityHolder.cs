using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    private float activeTime;

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    public AbilityState state = AbilityState.ready;

    public KeyCode key;

    private void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    activeTime = ability.activeTime;
                    ability.Activate(gameObject);
                    state = AbilityState.active;     
                }
            break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                    ability.Deactivate(gameObject);
                }
            break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
        
    }

    public float GetActiveTime() { return activeTime; }
}
