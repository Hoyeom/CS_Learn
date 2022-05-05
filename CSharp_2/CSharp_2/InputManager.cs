using System;

namespace CSharp_2
{
    // Observer Pattern
    public class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey InputKey;
        public event Action InputKeyTest;
        
        public void Update()
        {
            if(!Console.KeyAvailable) return;
            
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.A)
            {
                // 알려준다! 이벤트로!
                InputKey?.Invoke();
                InputKeyTest?.Invoke();
            }
        }
    }
}