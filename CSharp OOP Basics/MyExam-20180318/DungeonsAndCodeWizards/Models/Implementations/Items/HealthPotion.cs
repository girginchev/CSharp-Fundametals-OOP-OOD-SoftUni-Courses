﻿using DungeonsAndCodeWizards.Common;
using DungeonsAndCodeWizards.Models.Implementations.Characters;
using System;

namespace DungeonsAndCodeWizards.Models.Implementations.Items
{
    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;

        public HealthPotion() 
            : base(InitialWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.CharacterIsNotAlive);
            }

            character.Health += 20;
        }
    }
}
