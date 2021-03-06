﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infinispan.DotNetClient;
using Infinispan.DotNetClient.Util;
using Infinispan.DotNetClient.Protocol;
using Infinispan.DotNetClient.Impl;
using System;


namespace InfinispanDotnetClientSample
{
    class SampleInfinispanClientApplication
    {
        /// <summary>
        /// This is the Sample Application that uses the Infinispan .NET client library.
        /// </summary>
        /// <param name="args">string</param>
        static void Main(string[] args)
        {
            //Important! Make sure that the hotrod server is started before running the line below.
            //Create new Configuration, overriding the setting in the App.config file.
            ClientConfig conf = new ClientConfig("127.0.0.1", 11222, "default", false);

            //Here we are using a custom Serializer
            ISerializer s = new StringSerializer();

            //Create a new RemoteCacheManager
            RemoteCacheManager manager = new RemoteCacheManager(conf, s);

            //Get hold of a cache from the remote cache manager
            IRemoteCache<String, String> cache = manager.GetCache<String, String>();

            //First Check Whether the cache exists
            Console.WriteLine("Ping Result : " + cache.Ping());

            //Put a new value "germanium" with key "key 1" into cache
            cache.Put("key 1", "germanium", 0, 0);

            //Get the value of entry with key "key 1"
            Console.WriteLine("key 1 value : " + cache.Get("key 1"));

            //Put if absent is used to add entries if they are not existing in the cache
            cache.PutIfAbsent("key 1", "trinitrotoluene", 0, 0);
            cache.PutIfAbsent("key 2", "formaldehyde", 0, 0);
            Console.WriteLine("key 1 value after PutIfAbsent: " + cache.Get("key 1"));
            Console.WriteLine("Key 2 value after PutIfAbsent: " + cache.Get("key 2"));

            cache.Replace("key 1", "fluoride", 0, 0);
            Console.WriteLine("key 1 value after replace: " + cache.Get("key 1"));  

            //Check whether a particular key exists
            Console.WriteLine("key 1 is exist ?: " + cache.ContainsKey("key 1"));

            //Remove a particular entry from the cache
            cache.Remove("key 1");
            Console.WriteLine("key 1 is exist after remove?: " + cache.ContainsKey("key 1"));

            Console.WriteLine("Hit enter to exit!");
            Console.ReadLine();
        }
    }
}
