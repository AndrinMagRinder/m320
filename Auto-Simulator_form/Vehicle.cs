using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Simulator_form
{
    public class Vehicle: IFahrezeug
    {
        public int speed;
        public int status;
        public int gear;

        public int hp { get; set; }
        public string name { get; set; }

        public Vehicle(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }


        public virtual void Accelerate()
        {
        }

        public virtual void Brake()
        {
        }

        public virtual void StartEngine()
        {
        }

        public virtual void StopEngine()
        {
        }

        public virtual void SetGear()
        {
        }

        public virtual void Honk()
        {
        }

        public virtual void EngineSound()
        {
        }
    }
}
