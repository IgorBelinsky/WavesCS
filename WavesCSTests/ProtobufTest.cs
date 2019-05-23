﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grpc.Core;
using Waves.Protobuf;
using WavesCS;

namespace WavesCSTests.Protobuf
{
    [TestClass]
    public class ProtobufTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Init()
        {
            Http.Tracing = true;
        }

        [TestMethod]
        public void TestGrpc()
        {
            Channel channel = new Channel("mainnet-aws-fr-3.wavesnodes.com:6870", ChannelCredentials.Insecure);
            BlocksApi.BlocksApiClient client = new BlocksApi.BlocksApiClient(channel);
            BlockWithHeight block = client.GetBlock(new BlockRequest() { Height = -1 });
            TestContext.WriteLine(block.ToString());           
        }
    }
}
