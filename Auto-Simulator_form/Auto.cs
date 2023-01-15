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

        /*
         * Accelerate berechnet die Beschleunigung von dem Auto
         */
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
        /*
        * Brake sorgt dafür, dass der Lastwagen bremst, es rechnet hp / 100 bis es auf 0 ist.
        * Das es dazu kommt muss der Lastwagen angeschaltet sein (Status == 1) und der Lastwagen
        * muss über 1 km/h fahren.
        */
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
        /*
         * StartEnigne startet das Auto, es setzt Status sowie Gear auf 1
         */
        override public void StartEngine()
        {
            status = 1;
            gear = 1;
        }

        /*
       * StopEngine setzt schaltet das Auto aus indem es Status Gear und Speed auf 0 setzt
       */
        override public void StopEngine()
        {
            status = 0;
            gear = 0;
            speed = 0;
        }
        /*
         * SetGear, berechnet wann der Gang von dem Lastwagen gewechselt werden muss
         * Der Erste Gang ist von begin eingeschalten
         * Es wird so gerechent: speed > (((hp / 3) + 100) / 7 * 1 , wenn dies Zutrifft
         * dann wird der Gang auf 2 gesetzt, es geht bis zu Gang 6.
         */
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
        /*
       * Honk sorgt dafür, dass wenn ich Hupe ein otn kommt
       */
        override public void Honk()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../honk.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../honk.wav"));
            player.Play();
        }
        /*
   * EngineSound sorgt dafür, dass ein Ton kommt wenn ich das Auto einschalte
   * 
   */
        override public void EngineSound()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../engine.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../engine.wav"));
            player.Play();
        }


    }
}
