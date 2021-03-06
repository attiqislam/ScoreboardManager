﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScoreboardManager.Common.Models;

namespace ScoreboardManager.Common.ViewModels
{
    public class PointViewModel : PointModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalPoints { get; set; }
    }
}
