using System;

     interface ICharacter
    {
        void LoseHealth();
        void Move();
        void Move(float moveInput, float speed);
    }
