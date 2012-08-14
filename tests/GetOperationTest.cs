﻿using Infinispan.DotNetClient.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Infinispan.DotNetClient.Protocol;
using Infinispan.DotNetClient;
using Infinispan.DotNetClient.Trans;
using Infinispan.DotNetClient.Util;

namespace tests
{
    [TestClass()]
    public class GetOperationTest : SingleServerAbstractTest
    {    
        [TestMethod()]
        public void getTest()
        {
            IRemoteCache<String, String> defaultCache = remoteManager.getCache();

            Assert.IsNull(defaultCache.get("key7"));

            defaultCache.put("key7", "carbon");
            Assert.AreEqual("carbon", defaultCache.get("key7"));
        }
    }
}
