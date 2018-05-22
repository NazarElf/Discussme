﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussme.BLL.ServiceInterfaces
{
    public interface IServiceCreator
    {
        IForumService CreateForumService(string connection);
        IForumService CreateForumService();
    }
}