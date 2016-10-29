using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void CardTempTestMethod()
        {
            Assert.AreEqual("Love All",Cardtem.Gettemp(0,0));
            Assert.AreEqual("Fifteen Love",Cardtem.Gettemp(1, 0));
            Assert.AreEqual("Fifteen All", Cardtem.Gettemp(1, 1));
            Assert.AreEqual("Thirty Love", Cardtem.Gettemp(2, 0));
            Assert.AreEqual("Thirty Fifteen", Cardtem.Gettemp(2, 1));
            Assert.AreEqual("Thirty All", Cardtem.Gettemp(2, 2));
            Assert.AreEqual("Forty Love", Cardtem.Gettemp(3, 0));
            Assert.AreEqual("Forty Fifteen", Cardtem.Gettemp(3, 1));
            Assert.AreEqual("Forty Thirty", Cardtem.Gettemp(3, 2));
            Assert.AreEqual("Deuce", Cardtem.Gettemp(3, 3));
            Assert.AreEqual("Win", Cardtem.Gettemp(4, 0));
            Assert.AreEqual("Win", Cardtem.Gettemp(4, 1));
            Assert.AreEqual("Win", Cardtem.Gettemp(4, 2));
            Assert.AreEqual("Advantage", Cardtem.Gettemp(4, 3));
            Assert.AreEqual("Deuce", Cardtem.Gettemp(4, 4));
            Assert.AreEqual("Win", Cardtem.Gettemp(5, 3));
            Assert.AreEqual("Advantage", Cardtem.Gettemp(5, 4));
            Assert.AreEqual("Deuce", Cardtem.Gettemp(5, 5));
        }

        [TestMethod]
        public void GetIntsTestMethod()
        {
            CollectionAssert.AreEqual(MaxValue.Max(3), new ArrayList() { 3 });
            CollectionAssert.AreEqual(MaxValue.Max(5), new ArrayList() { 5 });

            CollectionAssert.AreEqual(MaxValue.Max(6), new ArrayList() { 2, 3 });
            CollectionAssert.AreEqual(MaxValue.Max(7), new ArrayList() { 7 });
            CollectionAssert.AreEqual(MaxValue.Max(9), new ArrayList() { 3, 3 });
        }
    }

    public class Cardtem
    {
        public static string Gettemp(int a,int b)
        {
            string[] carddic = new[] {"Love","Fifteen", "Thirty", "Forty"};
            string[] publicdic = new[] {"All","Advantage", "Win", "Deuce", "Deuce", "Deuce", "Deuce" };
            //如果a=b 在<3输出 比分差异 >=3 输出Deuce
            if (a==b)
            {
                if (a>=3)
                {
                    return publicdic[a];
                }
                else
                {
                    return carddic[a] + " " + publicdic[0];
                }
            }
           
            if (a>3)
            {
                if (a-b>2)
                {
                    return publicdic[2];
                }
                return publicdic[a-b];
            }
            
            return carddic[a] + " " + carddic[b];
        }
    }
}
