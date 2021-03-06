﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infinispan.DotNetClient.Protocol;
using Infinispan.DotNetClient.Trans;
using NLog;

namespace Infinispan.DotNetClient.Operations
{
    /*
    * Parent class of all Hot Rod operations
    *  
    * Author: sunimalr@gmail.com
    * 
    */
    public abstract class HotRodOperation : HotRodConstants
    {
        private static Logger logger;
        protected readonly Flag[] flags;
        protected readonly byte[] cacheName;
        private readonly Codec codec;
        private static readonly byte NO_TX = 0;
        private static readonly byte XA_TX = 1;
        private OperationsFactory operationsFactory;

        protected HotRodOperation()
        { }

        protected HotRodOperation(Codec codec, Flag[] flags, byte[] cacheName)
        {
            this.flags = flags;
            this.cacheName = cacheName;
            this.codec = codec;
            logger = LogManager.GetLogger("Hot Rod Operation");
        }

        protected HeaderParams WriteHeader(ITransport transport, byte operationCode)
        {
            HeaderParams param = new HeaderParams().OpCode(operationCode).CacheName(cacheName).flags(flags).ClientIntel(HotRodConstants.CLIENT_INTELLIGENCE_TOPOLOGY_AWARE).TxMarker(NO_TX);
            if (logger.IsTraceEnabled)
            {
                if (logger.IsTraceEnabled)
                {
                    string msg = ("headerparams created " + operationCode + " " + cacheName + " " + flags + " " + HotRodConstants.CLIENT_INTELLIGENCE_TOPOLOGY_AWARE + " " + NO_TX);
                    logger.Trace(msg);
                }
            }
            return codec.WriteHeader(transport, param, HotRodConstants.VERSION_11);
        }

        /**
         * Magic	| Message Id | Op code | Status | Topology Change Marker
         */
        protected byte ReadHeaderAndValidate(ITransport transport, HeaderParams param)
        {
                
                return codec.ReadHeader(transport, param,this.operationsFactory,this);
        }
    }
}
