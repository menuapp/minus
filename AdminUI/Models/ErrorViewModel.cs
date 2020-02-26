using System;
using System.ComponentModel.DataAnnotations;

namespace AdminUI.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        [Required]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}