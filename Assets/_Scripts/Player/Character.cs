using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] CharacterUI characterUI;
    public int maxHealth;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        characterUI.SetHearts( currentHealth );
    }
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
        characterUI.SetHearts( currentHealth );
    }
}
