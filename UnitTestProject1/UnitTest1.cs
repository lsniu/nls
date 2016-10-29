using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static Stack sk;
        public UnitTest1()
        {
            //Console.WriteLine();
            Console.WriteLine("1");
            sk = new Stack();
        }

        [TestMethod]
        public void TestMethod1()
        {
            //Assert.AreEqual(MaxValue.Max(3), new ArrayList() {3});
            CollectionAssert.AreEqual(MaxValue.Max(3), new ArrayList() {3});
            CollectionAssert.AreEqual(MaxValue.Max(5), new ArrayList() { 5 });
            
            CollectionAssert.AreEqual(MaxValue.Max(6), new ArrayList() { 2,3 });
            CollectionAssert.AreEqual(MaxValue.Max(7), new ArrayList() { 7 });
            CollectionAssert.AreEqual(MaxValue.Max(9), new ArrayList() { 3,3 });
            Console.WriteLine("ts1");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("ts2");
        }

        [TestMethod]
        public void Give_Stack_with_1_When_Peek_Then_1()
        {
            //give
            //when
            sk.Push(1);
            //then
            Assert.AreEqual(sk.Peek(), 1);
            
        }
        [TestMethod]
        public void Give_Stack_with_1_When_Clear_Then_IsEmpty()
        {
            //give
           
            //when
            sk.Push(1);
            sk.Clear();
            //then
            
            Assert.AreEqual(TestClass.EquaulObj(sk), true);
            
        }
    }

    public class TestClass
    {
        public static bool EquaulObj(Stack sk)
        {
            return sk.Count==0;
        }
    }

    public class MaxValue
    {
        public static ArrayList Max(int n)
        {
            ArrayList newList=new ArrayList();
            if (n<2)
            {
                return newList;
            }
            for (int i = 2; i < n; i++)
            {
                while (n != i)
                {
                    if (n%i != 0)
                    {
                        break;
                    }
                    newList.Add(i);
                    n = n/i;
                }
            }
            newList.Add(n);
            return newList;
        }
    }
}
