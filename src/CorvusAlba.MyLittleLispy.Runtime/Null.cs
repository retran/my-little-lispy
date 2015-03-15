using System.Collections.Generic;

namespace CorvusAlba.MyLittleLispy.Runtime
{
    public class Null : Value
    {
        public static Null Value = new Null();

        public override string ToString()
        {
            return "()";
        }

        public override T To<T>()
        {
            if (typeof(T) == typeof(IEnumerable<Value>))
            {
                return (T) (object) (new Value[] { });
            }

            return base.To<T>();
        }
        
        public override Value Equal(Value arg)
        {
            if (object.ReferenceEquals(this, arg))
            {
                return new Bool(true);
            }

            var cons = arg as Cons;
            if (cons != null)
            {
                return new Bool(cons.IsNull());
            }

            return new Bool(false);
        }
        
        public override Node ToExpression()
        {
            return new Constant(this);
        }
    }
}