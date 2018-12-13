﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Models
{
    class RegionalBlock
    {
        [JsonProperty(PropertyName = "acronym")]
        public string Acronym { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name{ get; set; }
    }
}
