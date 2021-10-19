using System;
using System.Collections.Generic;

namespace Mediator
{
    public interface IAirport
    {
        void Register(AirlineBase airline);
        bool GiveLandingPermission(string flightCode);
    }
    public abstract class AirlineBase
    {
        public string FlightCode { get; set; }
        public IAirport Airport { get; set; }

        public AirlineBase(string flightCode)
        {
            FlightCode=flightCode;
        }

        public virtual void GetLandingPermission()
        {
            if (Airport != null)
                if (Airport.GiveLandingPermission(FlightCode))
                    Console.WriteLine("Enis izni verildi.");
                else
                    Console.WriteLine("Enis izni verilmedi!");
            else
                Console.WriteLine("Bu Air plane Qeydiyatta yoxdur ona gorede Enis Izni verilmedi");
        }
    }
    public class AtaturkAirport : IAirport
    {
        private Dictionary<string, AirlineBase> _planes;

        public AtaturkAirport()
        {
            _planes = new Dictionary<string, AirlineBase>();
        }

        public void Register(AirlineBase airline)
        {
            if (!_planes.ContainsValue(airline))
                _planes.Add(airline.FlightCode, airline);

            airline.Airport = this;
        }

        public bool GiveLandingPermission(string flightCode)
        {
            if (_planes.ContainsKey(flightCode))
                return true;
            else
                return false;
        }
    }
    public class THYAirline : AirlineBase
    {
        public THYAirline(string flightCode) : base(flightCode)
        {
        }

        public override void GetLandingPermission()
        {
            Console.WriteLine(FlightCode + " Nolu THY Airplane Enis izni Istedi.");

            base.GetLandingPermission();
        }
    }
    public class PegasusAirline : AirlineBase
    {
        public PegasusAirline(string flightCode) : base(flightCode)
        {
        }

        public override void GetLandingPermission()
        {
            Console.WriteLine(FlightCode + " Nolu Pegasus Airplane Enis izni Istedi.");
            base.GetLandingPermission();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            AtaturkAirport AtaturkAirport = new AtaturkAirport();//airportumuzu yaradiriq


            THYAirline thyAirline1 = new THYAirline("C234");

            THYAirline thyAirline2 = new THYAirline("C240");

            PegasusAirline pegasusAirline1 = new PegasusAirline("E250");

            //bu airport a aid Airplaneleri qeydiyata saliriq 
            AtaturkAirport.Register(thyAirline1);


            AtaturkAirport.Register(pegasusAirline1);

            thyAirline2.GetLandingPermission();// qeydiyattan kecmeyib deye icaze verilmir

            Console.WriteLine();
            thyAirline1.GetLandingPermission();//Icaze verildi
            Console.WriteLine();

            pegasusAirline1.GetLandingPermission();//icaze verildi
            Console.WriteLine();


        }
    }
}
