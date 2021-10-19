using System;

namespace State
{
    public interface ILampState
    {
        public void OnOpen();
        public void OnClose();
    }
    class LambaOpenState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("Lampa Sondurulur");
        }

        public void OnOpen()
        {
            Console.WriteLine("Lampa Yanlidir Ama siz Yandirmaga calisirsiz");
        }
        public override string ToString()
        {
            return "Lampa Yanlidir";
        }
    }

    class LambaCloseState : ILampState
    {
        public void OnClose()
        {
            Console.WriteLine("Lampa Sonludur Ama siz Yandirmaga Sondurmeye");
        }

        public void OnOpen()
        {
            Console.WriteLine("Lampa Yandirilir");
        }
        public override string ToString()
        {
            return "Lampa Sonludur";
        }
    }


    class Context
    {
        private ILampState LampState { get; set; }


        public Context()
        {
            LampState = new LambaCloseState();
        }
        public void OnOpen()
        {
            LampState.OnOpen();
            LambaOpenState NewState =new LambaOpenState();
            SetLampState(NewState);

        }
        public void OnClose()
        {
            LampState.OnClose();
            LambaCloseState NewState = new LambaCloseState();
            SetLampState(NewState);
        }
        public ILampState GetLampState()
        {
            return LampState;
        }

        public void SetLampState(ILampState lampState)
        {
            this.LampState = lampState;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            Console.WriteLine(context.GetLampState());//Lampanin hal hazirkki veziyyetini ekrana cixardiriq
            Console.WriteLine();

            context.OnOpen();//lampani yandiririq
            Console.WriteLine();

            context.OnClose();//lampani Sondururuk
            Console.WriteLine();

            context.OnOpen();//yeniden lampani yandiririq
            Console.WriteLine();

            context.OnOpen();//yeniden lampani yandiririq
            Console.WriteLine();

            Console.WriteLine(context.GetLampState());
            

        }
    }
}
