using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float maxStamina;
    [SerializeField] private FloatEventChannel staminaChannel;
    private float currentStamina;
    
    void Awake(){
        currentStamina = maxStamina;
    }
    void Start()
    {
        PublishStaminaPercentage();
    }
    public void UpdateStamina(float value){
        currentStamina = value;
        PublishStaminaPercentage();
    }

    void PublishStaminaPercentage(){
        staminaChannel?.Invoke(currentStamina / maxStamina);
    }
}
