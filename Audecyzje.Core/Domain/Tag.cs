﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Audecyzje.Core.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        [DisplayFormat(NullDisplayText = "{Brak nazwy dla taga}")]
        public string TagName { get; set; }
        public string RegExp { get; set; }
        public IEnumerable<DecisionTag> LinkedDecisions { get; set; }

        public int LinkedDecisionsCount
        {
            get
            {
                if (LinkedDecisions == null)
                {
                    return 0;
                }
                return new List<DecisionTag>(LinkedDecisions).Count;
            }
        }
    }
}