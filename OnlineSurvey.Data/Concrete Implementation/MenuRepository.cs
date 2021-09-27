﻿using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurvey.Data.Concrete_Implementation
{
    public class MenuRepository:Repository<Menus>,IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
