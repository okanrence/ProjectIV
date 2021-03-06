﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIV.Core.Domain
{
    public class Case : baseDomain
    {
        [Key]
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public string CaseNumber { get; set; }
        public int CaseTypeId { get; set; }

        [ForeignKey("CaseTypeId")]
        public virtual CaseType CaseType { get; set; }
        public string CaseName { get; set; }
        public string CaseDescription { get; set; }
        public int CaseStatusId { get; set; }
            
        [ForeignKey("CaseStatusId")]
        public virtual CaseStatus CaseStatus { get; set; }

        public DateTime DateOpened { get; set; }
        public string CreatedBy { get; set; }
    }

    public class CaseType
    {
        public int CaseTypeId { get; set; }
        public string CaseTypeName { get; set; }
    }

    public class CaseStatus
    {
        public int CaseStatusId { get; set; }
        public string CaseStatusName { get; set; }
    }
}
