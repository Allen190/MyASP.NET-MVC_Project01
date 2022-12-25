using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Allen190Prj01.Models
{
    public class AdoMember
    {
        [DisplayName("會員編號")]
        [Required]
        public int MemId { get; set; }
        [DisplayName("會員姓名")]
        [Required]
        public string MemName { get; set; }
        [DisplayName("會員性別")]
        [Required]
        public string MemGender { get; set; }
        [DisplayName("會員電話")]
        [Required]
        public string MemPhone { get; set; }
        [DisplayName("會員Email")]
        [Required]
        public string MemEmail { get; set; }
        [DisplayName("會員生日")]
        [Required]
        public string MemBirthaay { get; set; }
        [DisplayName("會員帳號")]
        [Required]
        public string MemAccount { get; set; }
        [DisplayName("會員密碼")]
        [Required]
        public string MemPassword { get; set; }
    }
}