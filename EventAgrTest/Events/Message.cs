
namespace EventAgrTest.Events
{
    public abstract class Message {}

    public class MyMessage : Message
    {
        public int Number { get; set; }
    }
}