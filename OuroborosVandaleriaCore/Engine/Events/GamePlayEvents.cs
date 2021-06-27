using System;
using System.Collections.Generic;
using System.Text;

using OuroborosVandaleriaCore.Engine.GameState;
using OuroborosVandaleriaCore.GameObjects;

namespace OuroborosVandaleriaCore.Engine.Events
{
    class GamePlayEvents : BaseGameStateEvent
    {
        public class PlayerCasts : GamePlayEvents { }
        public class PlayerAttacks : GamePlayEvents { }
        public class PlayerPasues : GamePlayEvents { }
        public class PlayerOpenInventory : GamePlayEvents { }
        public class ActorHitBy : GamePlayEvents
        {
            public IGameObjectWithDamage HitBy { get; private set; }
            public ActorHitBy(IGameObjectWithDamage gameObject)
            {
                HitBy = gameObject;
            }
        }

        public class EnemyDie : GamePlayEvents
        {
            public int CurrentLife { get; private set; }
            public EnemyDie(int currentLife)
            {
                CurrentLife = currentLife;
            }
        }
    }
}
