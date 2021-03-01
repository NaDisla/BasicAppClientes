using System;
using System.Collections.Generic;

#nullable disable

namespace BasicClientsAPI.Models
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteCorreo { get; set; }
    }
}
