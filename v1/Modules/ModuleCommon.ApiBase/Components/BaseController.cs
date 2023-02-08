﻿using CoreCommon.Data.Domain.Business;
using CoreCommon.ModuleBase.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ModuleCommon.ApiBase.Components
{
    /// <summary>
    /// Base controller for all controllers
    /// </summary>
    [ApiController]
    public abstract class BaseController : CommonBaseController
    {
    }
}
