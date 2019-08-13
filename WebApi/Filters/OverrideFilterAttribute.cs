﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class OverrideFilterAttribute:FilterAttribute,IOverrideFilter
    {
        public Type FiltersToOverride
        {
            get { return typeof(IAuthorizationFilter); }
        }
    }
}