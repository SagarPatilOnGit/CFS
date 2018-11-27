using System;

namespace CFSClient.OOP
{
    class Token
    {
        public string Display()
        { return "base\n"; }

        public virtual string Display1()
        { return "base\n"; }
    }
    class IdentifierToken : Token
    {
        public new string Display()
        { return "derive\n"; }

        public override string Display1()
        { return "derive\n"; }

        public static void Method1(Token t)
        {
            Console.Write(t.Display());
            Console.Write(t.Display1());
        }
        public static void Method2(IdentifierToken t)
        {
            Console.Write(t.Display());
            Console.Write(t.Display1());
        }
    }
}
