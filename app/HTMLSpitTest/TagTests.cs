using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTMLSpitterLib.Tags;

namespace HTMLSpitTest
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        public void TestTagBuilding()
        {
            // var EmptyBasicHtmlStructure = "<html><head><meta charset=\"utf-8\" /></head><body></body></html>";
            var html = new ContentTag("html");
            Assert.AreEqual("<html></html>", html.Spit());
        }

        [TestMethod]
        public void TestTagAddChild()
        {
            var html = new ContentTag("html");
            
            var head = new ContentTag("head");
            
            var body = new ContentTag("body");
            
            html.AddChild(head);
            html.AddChild(body);
            Assert.AreEqual("<html><head></head><body></body></html>", html.Spit());
        }
    }
}
