using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OederDetailController : ControllerBase
    {
        MyDataContext db = new MyDataContext();
        [HttpGet]
        public List<OederDetail> GatAllOederDetail()
        {
            return db.OederDetail.Where(x => x.Status == true).ToList();
        }
        [HttpPost]
        public void AddOederDetail(OederDetail OederDetail)
        {
            db.OederDetail.Add(OederDetail);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateOederDetail(OederDetail od)
        {
            OederDetail od2 = db.OederDetail.FirstOrDefault(x => x.CodeOrder == od.CodeOrder);
            od2.CodeProdect = od.CodeProdect;
            od2.PriceAddition = od.PriceAddition;
            od2.DiscibeAddition = od.DiscibeAddition;
            db.OederDetail.Update(od2);
            db.SaveChanges();
        }
        //מחיקה מהמאגר ע"י שינוי הסטטוס מאמת לשקר
        [HttpPut("deleteOederDetail")]
        public void DelOederDetail(int id)
        {
            OederDetail od2 = db.OederDetail.FirstOrDefault(x => x.CodeOrder == id);
            od2.Status = false;
            db.OederDetail.Update(od2);
            db.SaveChanges();
        }




    }
}
