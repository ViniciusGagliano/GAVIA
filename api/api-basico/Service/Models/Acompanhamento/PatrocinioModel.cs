﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class PatrocinioModel
    {
        public int Id { get; set; }
        public int SeguradoraId { get; set; }
        public int RepresentanteId { get; set; }
    }
}