using System;

public class Game
{
 public static IInputSystem InputSystem;

 public Game()
 {
  InputSystem = new InputSystem();
 }
}