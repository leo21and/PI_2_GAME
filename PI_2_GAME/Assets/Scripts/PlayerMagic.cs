 using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows.Speech;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] private Spell spellToCast;

    [SerializeField] private float maxPower = 100f;
    [SerializeField] private float currentPower;
    [SerializeField] private float powerRechargeRate = 2f;
    [SerializeField] private float timeToWaitForRecharge = 1f;
    private float currentPowerRechargeTimer;
    [SerializeField] private float timeBetweenCasts = 0.25f;
    private float currentCastTimer;

    [SerializeField] private Transform castPoint;

    private bool castingMagic = false;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        currentPower = maxPower;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        bool isSpellCastHeldDown = playerInput.Powers.Spell1.ReadValue<float>() > 0.1;
        bool hasEnoughPower = currentPower - spellToCast.SpellToCast.PowerCost >= 0f;

        if(!castingMagic && isSpellCastHeldDown && hasEnoughPower) 
        {
            castingMagic = true;
            currentPower -= spellToCast.SpellToCast.PowerCost;
            currentCastTimer = 0;
            currentPowerRechargeTimer = 0;
            CastSpell();
        }

        if(castingMagic )
        {
            currentCastTimer += Time.deltaTime;

            if(currentCastTimer > timeBetweenCasts)
            {
                castingMagic = false;
            }
        }

        if(currentPower < maxPower && !castingMagic && !isSpellCastHeldDown) {

            currentPowerRechargeTimer += Time.deltaTime;

            if(currentPowerRechargeTimer > timeToWaitForRecharge) {

                currentPower += powerRechargeRate * Time.deltaTime;

                if (currentPower > maxPower)
                {
                    currentPower = maxPower;
                }

            }
            
        }
    }

    public void CastSpell()
    {
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
}
