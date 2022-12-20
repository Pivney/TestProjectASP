﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chtoto.Domain.Enteties
{
    public class ServiceItem: EntityBase
    {
        [Required(ErrorMessage ="Заполните название услуги ")]
        [Display(Name ="Название услуги")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Краткое описание услуги")]
        public override string? Subtitle { get; set; } = "Информационная страница";

        [Display(Name = "Полное описание услуги")]
        public override string Text { get; set; } = "Заполняется";
    }
}
