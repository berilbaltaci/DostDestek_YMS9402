﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
namespace DostDestekSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}