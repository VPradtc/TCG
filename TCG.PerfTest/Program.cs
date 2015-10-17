using System.Runtime.InteropServices;
using TCG.Core.Cards;

namespace TCG.PerfTest
{
    class PerformanceTest
    {
        private const int INVOKE_COUNT = 100000000;
        private int _target;

        private void PrivateMethod(int i)
        {
            _target = i;
        }

        protected void ProtectedMethod(int i)
        {
            _target = i;
        }

        protected internal void ProtectedInternalMethod(int i)
        {
            _target = i;
        }

        internal void InternalMethod(int i)
        {
            _target = i;
        }

        public void PublicMethod(int i)
        {
            _target = i;
        }

        public void TestPrivateMethod()
        {
            for (int i = 0; i < INVOKE_COUNT; i++)
            {
                PrivateMethod(i);
            }
        }

        public void TestProtectedMethod()
        {
            for (int i = 0; i < INVOKE_COUNT; i++)
            {
                ProtectedMethod(i);
            }
        }

        public void TestProtectedInternalMethod()
        {
            for (int i = 0; i < INVOKE_COUNT; i++)
            {
                ProtectedInternalMethod(i);
            }
        }

        public void TestInternalMethod()
        {
            for (int i = 0; i < INVOKE_COUNT; i++)
            {
                InternalMethod(i);
            }
        }

        public void TestPublicMethod()
        {
            for (int i = 0; i < INVOKE_COUNT; i++)
            {
                PublicMethod(i);
            }
        }

        public class InnerClass
        {
            private int _target;
            private void PrivateMethod(int i)
            {
                _target = i;
            }

            protected void ProtectedMethod(int i)
            {
                _target = i;
            }

            protected internal void ProtectedInternalMethod(int i)
            {
                _target = i;
            }

            internal void InternalMethod(int i)
            {
                _target = i;
            }

            public void PublicMethod(int i)
            {
                _target = i;
            }

            public void TestPrivateMethod()
            {
                for (int i = 0; i < INVOKE_COUNT; i++)
                {
                    PrivateMethod(i);
                }
            }

            public void TestProtectedMethod()
            {
                for (int i = 0; i < INVOKE_COUNT; i++)
                {
                    ProtectedMethod(i);
                }
            }

            public void TestProtectedInternalMethod()
            {
                for (int i = 0; i < INVOKE_COUNT; i++)
                {
                    ProtectedInternalMethod(i);
                }
            }

            public void TestInternalMethod()
            {
                for (int i = 0; i < INVOKE_COUNT; i++)
                {
                    InternalMethod(i);
                }
            }

            public void TestPublicMethod()
            {
                for (int i = 0; i < INVOKE_COUNT; i++)
                {
                    PublicMethod(i);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new PerformanceTest();
            test.TestPrivateMethod();
            test.TestProtectedMethod();
            test.TestProtectedInternalMethod();
            test.TestInternalMethod();
            test.TestPublicMethod();

            var innerClass = new PerformanceTest.InnerClass();
            innerClass.TestPrivateMethod();
            innerClass.TestProtectedMethod();
            innerClass.TestProtectedInternalMethod();
            innerClass.TestInternalMethod();
            innerClass.TestPublicMethod();
        }
    }
}
