using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Issue.Entities.Tables
{


	[Table("Table1")]
	public class Table1
	{
		[Column("ID")] 
		public int? Id { get; set; }
		
		
		[Column("STATE_ID")] 
		public int? Stateid { get; set; }
		
	}





}
