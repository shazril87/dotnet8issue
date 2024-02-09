using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using Microsoft.Data.SqlClient;
using Issue.Entities.Tables;
using Issue.Entities;


namespace Issue.Controllers
{
    [Route("isu")]
    public class Issue1Controller : ControllerBase
    {        
        private readonly SomedbContext _somedbcontext;

        public Issue1Controller()
        {
            _somedbcontext = new SomedbContext();
        }




         [Route("zzz")]  //ni zzz
         [HttpGet]
         public async Task<dynamic> Form_marine_htmlformat_forpdf2(string? zzz, DateTime? aaa, DateTime? recorddtprev, DateTime? recorddt)   //dulu JsonNode?
         {

            var q_sp = _somedbcontext.Database.GetDbConnection().CreateCommand();
            q_sp.Parameters.Add(new SqlParameter("zzzz", zzz ?? ""));

            List<object> rez = new List<object>();

            q_sp.CommandText = $@"
                Some query  
            ";

            //Console.WriteLine(q.CommandText);

            await _somedbcontext.Database.OpenConnectionAsync();

            var reader = await q_sp.ExecuteReaderAsync();
            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();  //cek duplicate param
            if (columns.Distinct().Count() != columns.Count()) { return BadRequest("Query failed due to param duplicate error"); }
            //return columns;

            while (await reader.ReadAsync())
            {
                Dictionary<string, dynamic> myobj = new Dictionary<string, dynamic>();

                for (int i = 0; i < columns.Count(); i++)
                {
                    myobj.Add(columns[i], reader.IsDBNull(i) ? null : reader.GetFieldValueAsync<dynamic>(i).Result);
                }
                rez.Add(myobj);
            }
            _somedbcontext.Database.CloseConnection();

            dynamic? sp_json = null;

            if(rez.Count > 0)
            {
                sp_json = rez[0];
            }
              
            var q = await _somedbcontext.Table1.FirstOrDefaultAsync(x => x.Id == 123);
            var r = "EXCEED";
             if (q == null) return new ContentResult
             {
                 ContentType = "text/html",
                 Content = @"No data available"
             };
            
            
            var zzzz = sp_json?["zzzz"].Contains(r) ? "#cf5953" : "white";




            //return td;
            return new ContentResult
             {
                 ContentType = "text/html",
                 Content = @"
 <!DOCTYPE html>

 <meta charset='utf-8' />
 <meta name='viewport'  content='initial -scale=1,maximum-scale=1,user-scalable=no'/>

 <head>

 <style>
     body { font-family: Arial, Helvetica, sans-serif; font-size: small;}
     td { border: 1px solid grey; padding: 5px;}
     .tdnoborder { border: 0px }
     .tdcolorred { bgcolor: red }
     .tdcolorwhite { bgcolor: yellow }
     table { border-collapse: collapse; width: 100%}
 </style>

 </head>

 <body>
 <center>
 <table>
     <tr>
         <td rowspan='4'><center><img src='zzzzzzz' height=70></center></td>
         <td rowspan='4'><center><b><i> Borang <br>zzzzz <br> LEVEL 2</i></b></center></td>
     </tr>
     <tr>
     <td>Dokumen</td>
     <tdzzzz</td>
     </tr>
     <tr>
     <td>Tarikh</td>
     <td>zzzzz/td>
     </tr>
     <tr>
     <td>zzz</td>
     <td>Page 1 of 2</td>
     </tr>
 </table>

 <br>
 <br>
 <div align='center'><b>Maklumat zz</b></div><br>

 <table>
     <tr>
         <td colspan='1'><b>zzz</b></td>
         <td colspan='2'>zzzz</td>
         <td colspan='1'><b>zzz & Masa <br>zzz</b></td>
         <td colspan='2'>zzzz</td>
     </tr>  
 </table>    

 <br>
 <br>

 <table>
     <tr> 
         <td colspan='1'><b>No. zzz</b></td>
         <td colspan='2'>zzzz/td> 
         <td><b>*Kategory zz</b></td>
         <td>zzzz</td>
     </tr>
     <tr> 
         <td><b>zzz</b></td>
         <td colspan='2'>zzzzz</td> 
         <td><b>*zz</b></td>
         <td>zzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr> 
         <td><b>zzz</b></td>
         <td>zzzzzzzzzzzzzzzzz</td> 
         <td>zzzzzzzzzzzzzzzzz</td> 
         <td><b>Status</b></td>
         <td>zzzzzzzzzzzzzzzzz</td>
     </tr>    
 </table>

 <br><br>

 <div align='center'><b>zzz zz</b></div>

 <br>
 <br>

 <table>
     <tr> 
         <td rowspan='3' colspan='1' align='center'><b>zzzz. </b></td>
         <td rowspan='3' colspan='1' align='center'><b>zzzz </b></td>
         <td rowspan='3' colspan='1' align='center'><b>zzzz </b></td> 
         <td rowspan='1' colspan='2' align='center'><b>zzzzz</b></td>
         <td rowspan='3' colspan='1' align='center'><b>zzzz<br>(Kelaszzzzzzzzzzzzzzzzz) </b></td>
     </tr>
     <tr> 
         <td align='center'><b>Tarikh zzz</b></td>
         <td align='center'><b>Tarikh zzzz</b></td> 
     </tr>
     <tr> 
         <td align='center'>zzzzzzzzzzzzzzzzztd>
         <td align='center'>zzzzzzzzzzzzzzzzz/td> 
     </tr>
     <tr>
         <td align='center'><b>A)</b></td>
         <td colspan='5'><b>Data in-situ</b></td>
     </tr>
     <tr>
         <td align='center'><b>1</b></td>
         <td><b>zzzz zzzz</b></td>
         <td align='center'>mg/l</td>
         <td align='center' style='background-color: zzzzzzzzzzzzzzzzz/td>
         <td align='center' style='background-color:zzzzzzzzzzzzzzzzz</td>
         <td align='centerzzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>2</b></td>
         <td><b>pH</b></td>
         <td align='center'>-</td>
         <td align='center' style='background-color:zzzzzzzzzzzzzzzzz</td>
         <td align='center' style='background-color:zzzzzzzzzzzzzzzzz</td>
         <td align='center'zzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>3</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>&deg;C</td>
         <td align='center'zzzzzzzzzzzzzzzzz/td>
         <td align='center'zzzzzzzzzzzzzzzzz/td>
         <td align='center'zzzzzzzzzzzzzzzzz/td>
     </tr>
     <tr>
         <td align='center'><b>4</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>&micro;s/cm</td>
         <td align='center'zzzzzzzzzzzzzzzzz/td>
         <td align='centerzzzzzzzzzzzzzzzzz/td>
         <td align='center'zzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>5</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>NTU</td>
         <td align='center'zzzzzzzzzzzzzzzzz</td>
         <td align='centerzzzzzzzzzzzzzzzzz/td>
         <td align='centerzzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>6</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>Ppt</td>
         <td align='center'zzzzzzzzzzzzzzzzz</td>
         <td align='centerzzzzzzzzzzzzzzzzz</td>
         <td align='centerzzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>B)</b></td>
         <td colspan='5'><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
     </tr>
     <tr>
         <td align='center'><b>7</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>mg/l</td>
         <td align='center' style='background-color:zzzzzzzzzzzzzzzzz</td>
         <td align='center' style='background-colorzzzzzzzzzzzzzzzzz/td>
         <td align='center'zzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>8</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-color:zzzzzzzzzzzzzzzzz</td>
         <td align='center' style='background-color: zzzzzzzzzzzzzzzzz</td>
         <td align='centezzzzzzzzzzzzzzzzz</td>
     </tr>
     <tr>
         <td align='center'><b>9</b></td>
         <td><b>Cnzzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-colzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz</td>
         <td align='center' style='" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>10</b></td>
         <td><b>Azzzzzzzzzzzzzzzzzzzzzzzs</b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center' style='background-" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>11</b></td>
         <td><b>Pb</b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center' style='" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='" + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>12</b></td>
         <td><b>Zn</b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='backgrcolzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>13</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz<sub>3</sub></b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>14</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz<sub>zzzzzzzzzzzzzzzzzzzzzzz</sub></b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzz"] + @"</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzzz"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>15</b></td>
         <td><b>PO<sub>4</sub></b></td>
         <td align='center'>&micro;g/l</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["PO4_PREV"] + @"</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["PO4"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
     </tr>
     <tr>
         <td align='center'><b>16</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>CFU/100ml</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzz"] + @"</td>
         <td align='center' style='background-color: " + zzzz + "'>" + sp_json?["zzzzz"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
     </tr>
         <tr>
         <td align='center'><b>17</b></td>
         <td><b>zzzzzzzzzzzzzzzzzzzzzzz</b></td>
         <td align='center'>CFU/100ml</td>

         <td align='center'>" + sp_json?["zzzz"] + @"</td>
         <td align='center'>" + sp_json?["zzzz"] + @"</td>
         <td align='center'>" + "-" + @"</td>
     </tr>

 </table>


 <!---------page break utk pdf mase print---------->
 <div style='page-break-after: always'></div>

 <br><br>
 <table>
     <tr>
         <td rowspan='4'><center><img src='hzzzzzzzzz' height=70></center></td>
         <td rowspan='4'><center><b><i> Borang <br>zzzzzzzzzzzzzzzzzzzzzzz <br> LEVEL 2  </i></b></center></td>
     </tr>
     <tr>
         <td>Dokumen</td>
         <td>" + "zzzzzzzzzzzzzzzzzzzzzzz" + q?.Stateid + "-M" + @"</td>
     </tr>
     <tr>
         <td>Tarikh</td>
         <td>" + (q?.Stateid != null ? q?.Stateid.Value.ToString("dd/MM/yyyy") : "") + @"</td>
     </tr>
     <tr>
         <td>Mukasurat</td>
         <td>Page 2 of 2</td>
     </tr>

 </table>

 <br>
 <br><br>

 <div align='left'>

     <div style='border: 1px solid black; height: 500px'><br>
         <b>&emsp;zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz&emsp;" + q?.Stateid + @"

     </div>
 </div>


 <br><br><br><br>

 <!---------page break utk pdf zzzzzzzzzzzzzzzzzzzzzzz--------->
 <div style='page-break-after: always'></div>

 <div align='left'><b>zzzzzz Document</b></div><br><br>
 <div align='left'><b>" + (q.Stateid) + @"</b></div><br>
 <img src='" + q?.Stateid + @"'>
<div style='page-break-after: always'></div>
<div align='left'><b>" + (q.Stateid) + @"</b></div><br>
<img src='" + (q?.Stateid) + @"'>

 <br><br>

 <table>
     <tr>
         <td rowspan='2'>zzzzzzz :</td>
         <td>Nama:</td>
         <td colspan=3>" + q?.Stateid + @"</td>
         </tr>
     <tr>
         <!-- <td>zzzzzzzzzzzzzzzzzzzzzzz</td> -->
         <td>Jawzzzzzzzzzzzzzzzzzzzzzzztan:</td>
         <td>" + q?.Stateid + @"</td>
         <td>zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz & Masa:</td>
         <td>" + q?.Stateid + @"</td>
     </tr>
     <tr>
         <td rowspan='2'>zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz :<br>OLEH</td>
         <td>Nama:</td>
         <td colspan=3>" + q?.Stateid + @"</td>
         </tr>
         <tr>
         <!-- <td>zzzzzzzzzzzzzzzzzzzzzzz</td> -->
         <td>Jawatan:</td>
         <td>" + q?.Stateid + @"</td>
         <td>Tarikh & Masa:</td>
         <td>" + q?.Stateid + @"</td>
     </tr>
 </table>
  <br><br><br>


 </center>
 </body>
 </html>

             "
             };

         }



    }
}