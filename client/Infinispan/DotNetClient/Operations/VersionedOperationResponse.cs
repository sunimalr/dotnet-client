﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infinispan.DotNetClient.Operations
{
    /// <summary>
    /// Keeps information on the version of the data present in the server.
    /// </summary>
    public class VersionedOperationResponse
    {
        public enum RspCode
        {
            SUCCESS,
            NO_SUCH_KEY,
            MODIFIED_KEY,
        }

        private bool isModified;
        private byte[] value;
        private RspCode code;

        public void RespCode(bool modified)
        {
            isModified = modified;
        }

        public bool IsUpdated()
        {
            return isModified;
        }

        public VersionedOperationResponse(byte[] value, RspCode code)
        {
            this.value = value;
            this.code = code;
        }

        public byte[] GetValue()
        {
            return value;
        }

        public RspCode GetCode()
        {
            return code;
        }
    }
}
