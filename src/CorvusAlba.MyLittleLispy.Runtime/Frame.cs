using System.Collections.Generic;
using System.Linq;

namespace CorvusAlba.MyLittleLispy.Runtime
{
    public class Frame
    {
        private readonly Stack<Scope> _scopes;
        private readonly Frame _globalFrame;

        public bool IsGlobal
        {
            get
            {
                return _globalFrame == null;
            }
        }

        public Frame()
        {
            _scopes = new Stack<Scope>();
        }

        public Frame(Frame globalFrame)
            : this()
        {
            _globalFrame = globalFrame;
        }

        public Value Lookup(string name)
        {
            foreach (var scope in _scopes)
            {
                Value value = scope.Lookup(name);
                if (value != null)
                {
                    return value;
                }
            }

            if (_globalFrame != null)
            {
                return _globalFrame.Lookup(name);
            }

            return Undefined.Value;
        }

        public void Set(string name, Value value)
        {
            if (_scopes.Any(scope => scope.Set(name, value)))
            {
                return;
            }

            if (_globalFrame != null)
            {
                _globalFrame.Set(name, value);
            }
            else
            {
                throw new SymbolNotDefinedException(name);
            }
        }

        public IEnumerable<Scope> Export()
        {
            return _scopes.Reverse().ToArray();
        }

        public void Import(IEnumerable<Scope> scopes)
        {
            if (scopes != null)
            {
                foreach (var scope in scopes)
                {
                    _scopes.Push(scope);
                }
            }
        }

        public void Bind(string name, Value value)
        {
            _scopes.Peek().Bind(name, value);
        }

        public void Push()
        {
            _scopes.Push(new Scope(new string[] { }, new Value[] { }));
        }

        public void Push(IEnumerable<string> args, IEnumerable<Value> values)
        {
            _scopes.Push(new Scope(args, values));
        }

        public void Pop()
        {
            _scopes.Pop();
        }
    }
}