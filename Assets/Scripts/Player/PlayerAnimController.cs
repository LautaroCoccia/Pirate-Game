using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform characterMedium;
    [SerializeField] private Transform playerPosRef;
    Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = characterMedium.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveMovementAnim(int movementMagnitude)
    {
        anim.SetInteger("MovementVector", movementMagnitude);

    }
    public void SetActiveDigAnimation(bool isDigging, float digSpeed)
    {
        anim.SetBool("Dig", isDigging);
        anim.speed = anim.speed * digSpeed;
        if (!isDigging)
        {
            anim.speed = 1;
            characterMedium.position = new Vector3(playerPosRef.transform.position.x, 0f, playerPosRef.transform.position.z);
            characterMedium.localRotation = Quaternion.identity;
            
        }
    }
}
