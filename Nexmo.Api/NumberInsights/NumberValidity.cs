﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Nexmo.Api.NumberInsights
{
    public enum NumberValidity
    {
        unknown,
        valid,
        not_valid,
        inferred,
        inferred_not_valid
    }
}
