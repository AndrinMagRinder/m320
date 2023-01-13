using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Simulator_form
{
    internal class FireTruck : Lastwagen
    {
        public FireTruck(string name, int hp) : base(name, hp)
        {
        }
        override public void Honk()
        {
            Console.WriteLine(System.IO.Path.GetFullPath("../../../siren.wav"));
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer(System.IO.Path.GetFullPath("../../../siren.wav"));
            player2.Play();
        }
    }
}
