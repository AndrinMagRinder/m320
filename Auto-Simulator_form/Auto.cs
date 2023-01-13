using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Auto_Simulator_form
{
    public class Auto : Vehicle
    {


        public Auto(string name, int hp) : base(name, hp)
        {

        }


        override public void Accelerate()
        {
            if (status == 1)
            {
                if (speed < ((hp / 3) + 100))
                {
                    speed += (hp / 200);
                }
            }
        }

        override public void Brake()
        {
            if (status == 1)
            {
                if (speed > 0)
                {
                    speed -= (hp / 100);
                    if (speed < 0)
                    {
                        speed = 0;
                    }
                }
            }
        }

        override public void StartEngine()
        {
            status = 1;
            gear = 1;
        }


        override public void StopEngine()
        {
            status = 0;
            gear = 0;
            speed = 0;
        }

        override public void SetGear()
        {

            if (speed >= 0)
            {
                gear = 1;
            }

            if (speed > (((hp / 3) + 100) / 7 * 1))
            {
                gear = 2;
            }

            if (speed > (((hp / 3) + 100) / 7 * 2))
            {
                gear = 3;
            }

            if (speed > (((hp / 3) + 100) / 7 * 3))
            {
                gear = 4;
            }

            if (speed > (((hp / 3) + 100) / 7 * 4))
            {
                gear = 5;
            }

            if (speed > (((hp / 3) + 100) / 7 * 5))
            {
                gear = 6;
            }
        }

        override public void Honk()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../honk.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../honk.wav"));
            player.Play();
        }

        override public void EngineSound()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../engine.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../engine.wav"));
            player.Play();
        }


    }
}
