using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.MapObjects
{

    public interface IMapObject
    {
        void Interact(Player p);
    }

    public interface IArmy
    {
        Army Army { get; set; }
    }

    public interface IOwner
    {
        int Owner { get; set; }
    }

    public interface ITreasure
    {
        Treasure Treasure { get; set; }
    }

    public class Dwelling : IMapObject
    {
        public int Owner { get; set; }
        public void Interact(Player p)
        {
            Owner = p.Id;
        }
    }

    public class Mine : IMapObject, IArmy, IOwner
    {
        public int Owner { get; set; }
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }
        public void Interact(Player p)
        {
            if (p.CanBeat(Army))
            {
                Owner = p.Id;
                p.Consume(Treasure);
            }
            else p.Die();
        }
    }

    public class Creeps : IMapObject, IArmy
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Interact(Player p)
        {
            if (p.CanBeat(Army))
            {
                p.Consume(Treasure);
            }
            else
            {
                p.Die();
            }
        }
    }

    public class Wolves : IMapObject
    {
        public Army Army { get; set; }
        public void Interact(Player p)
        {
            if (!p.CanBeat(Army))
            {
                p.Die();
            }
        }
    }

    public class ResourcePile : IMapObject
    {
        public Treasure Treasure { get; set; }
        public void Interact(Player p)
        {
            p.Consume(Treasure);
        }
    }

    public static class Interaction
    {
        public static void Make(Player player, IMapObject obj)
        {
            obj.Interact(player);
        }
    }
}