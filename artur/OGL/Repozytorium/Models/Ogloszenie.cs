﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repozytorium.Models
{
    public class Ogloszenie
    {
        public Ogloszenie()
        {
            this.Ogloszenie_Kategoria = new HashSet<Ogloszenie_Kategoria>();
        }
        [Display(Name="Id:")]
        public int Id { get; set; }
        [Display(Name ="Treść ogłoszenia:")]
        [MaxLength(500)]
        public string Tresc { get; set; }
        [Display(Name ="Tytuł:")]
        [MaxLength(72)]
        public string Tytul { get; set; }
        [Display(Name ="Data dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:yyyy-MM-dd",ApplyFormatInEditMode =true)]
        public DateTime DataDodania { get; set; }
        public string UzytkownikId { get; set; }
        public virtual ICollection<Ogloszenie_Kategoria> Ogloszenie_Kategoria { get; set; }
        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}