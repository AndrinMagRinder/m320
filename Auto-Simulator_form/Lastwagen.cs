using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Simulator_form
{
    public class Lastwagen : Vehicle
    {
        private static int weight = 0;
        public Lastwagen(string name, int hp) : base(name, hp)
        {
        }
        /*
      * Accelerate berechnet die Beschleunigung von dem Lastwagen
      */
        override public void Accelerate()
        {
            

            if (status == 1)
            {
                if (weight == 0)
                {
                    if (speed < (hp / 3))
                    {
                        speed += (hp / 200);
                    }
                }
                else
                {
                    if (speed < (hp / 3) / (weight / 10));
                    {
                        speed += (hp / 200 / (weight / 10));
                    }
                }
            }
        }
        /*
         * Brake sorgt dafür, dass der Lastwagen bremst, es rechnet hp / 60 bis es auf 0 ist.
         * Das es dazu kommt muss der Lastwagen angeschaltet sein (Status == 1) und der Lastwagen
         * muss über 1 fahren.
         */
        override public void Brake()
        {
            if (status == 1)
            {
                if (speed > 0)
                {
                    speed -= (hp / 60);
                    if (speed < 0)
                    {
                        speed = 0;
                    }
                }
            }
        }
        /*
        * Start Enigne schaltet den Lastwagen ein, indem sie Status und Gear auf 1 setzt
        */
        override public void StartEngine()
        {
            status = 1;
            gear = 1;
        }

        /*
       * Stopenigne schaltet den Lastwagen aus, indem sie Status, Gear und Speed auf 0 setzt
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
    * Es wird so gerechent: speed > (((hp / 3) + 25) / 7 * 1 , wenn dies Zutrifft
    * dann wird der Gang auf 2 gesetzt, es geht bis zu Gang 6.
    */
        override public void SetGear()
        {


            if (speed >= 0)
            {
                gear = 1;
            }

            if (speed > (((hp / 3) + 25) / 7 * 1))
            {
                gear = 2;
            }

            if (speed > (((hp / 3) + 25) / 7 * 2))
            {
                gear = 3;
            }

            if (speed > (((hp / 3) + 25) / 7 * 3))
            {
                gear = 4;
            }

            if (speed > (((hp / 3) + 25) / 7 * 4))
            {
                gear = 5;
            }

            if (speed > (((hp / 3) + 25) / 7 * 5))
            {
                gear = 6;
            }
        }
        /*
        * Honk sorgt dafür, dass der Lastwagen Hupen kann.
        */
        override public void Honk()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../honk.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../honk.wav"));
            player.Play();
        }
        /*
     * EngineSound sorgt dafür, dass es einen Ton gibt wenn der Motor angeschalten wird
     */
        override public void EngineSound()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../engine.wav"));
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../engine.wav"));
            player.Play();
        }
        /*
         * Set Weight,setzt das Gewicht für den Lastwagen
         */
        public static void SetWeight(int weightForm)
        {
            weight = weightForm;
        }
        /*
        * GetWeight holt das Gewicht für den Lastwagen
        */
        public int GetWeight()
        {
            return weight;
        }
    }
}
