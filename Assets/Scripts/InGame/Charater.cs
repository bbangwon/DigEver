using UnityEngine;
using System.Collections;

public enum CharacterState
{
    idle,
    attack
}
public class Charater : MonoBehaviour
{
    private Animator ani;
    public CharacterState state;

    void Awake()
    {
        ani = GetComponent<Animator>();
    }
    public void SetAnimation(CharacterState _state)
    {
        ani.SetInteger("AnimationIndex",(int)_state);
    }
}
