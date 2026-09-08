using UnityEngine;

public interface HeroineState {
    public void HandleInput(Heroine player);
    public void UpdateHeroine(Heroine player);
}
