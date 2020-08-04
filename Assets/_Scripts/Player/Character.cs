using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public void EffectHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if( currentHealth <= 0 )
        {
            currentHealth = 0;
            // dies
        }
    }
}
