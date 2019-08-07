﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DCNC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void TestMethod1()
        {
            var url = "http://localhost:3632";
            driver.Url = url;
            driver.Close();
        }
    }
}
