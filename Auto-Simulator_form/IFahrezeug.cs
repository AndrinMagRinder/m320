using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Simulator_form
{
    public interface IFahrezeug
    {
        void Accelerate();
        void Brake();
        void StartEngine();
        void StopEngine();
        void SetGear();
        void Honk();
        void EngineSound();
    }
}
