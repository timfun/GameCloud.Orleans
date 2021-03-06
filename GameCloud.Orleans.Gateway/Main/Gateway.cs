﻿// Copyright (c) Cragon. All rights reserved.

namespace GameCloud.Orleans.Gateway
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetty.Transport.Channels;
    using Autofac;
    using Autofac.Configuration;
    using Autofac.Core;
    using GameCloud.Unity.Common;

    public class Gateway
    {
        //---------------------------------------------------------------------
        private GatewayRunner gatewayRunner = new GatewayRunner();

        //---------------------------------------------------------------------
        public static Gateway Instance { get; private set; }
        public IContainer GatewaySessionListenerContainer { get; private set; }
        public string ConsoleTitle { get; set; }
        public string Version { get; set; }

        //---------------------------------------------------------------------
        public Gateway(string title, string version)
        {
            Instance = this;
            ConsoleTitle = title;
            Version = version;
        }

        //---------------------------------------------------------------------
        public Task Start(IPAddress ip_address, int port)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            this.GatewaySessionListenerContainer = builder.Build();

            var gatewaySessionFactory = new GatewaySessionFactory();

            return this.gatewayRunner.Start(ip_address, port, gatewaySessionFactory);
        }

        //---------------------------------------------------------------------
        public Task Stop()
        {
            return this.gatewayRunner.Stop();
        }

        //---------------------------------------------------------------------
        public void addSession(IChannelHandlerContext c, GatewaySession s)
        {
            this.gatewayRunner.addSession(c, s);
        }

        //---------------------------------------------------------------------
        public void removeSession(IChannelHandlerContext c)
        {
            this.gatewayRunner.removeSession(c);
        }
    }
}
