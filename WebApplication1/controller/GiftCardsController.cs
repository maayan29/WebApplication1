using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCardsController : ControllerBase
    {
        MyDataContext db = new MyDataContext();
        [HttpGet]
        public List<GiftCards> GatAllGiftCards()
        {
            return db.GiftCards.Where(x => x.Status == true).ToList();
        }
        [HttpPost]
        public void AddGiftCards(GiftCards GiftCards)
        {
            db.GiftCards.Add(GiftCards);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateGiftCards(GiftCards g)
        {
            GiftCards g2 = db.GiftCards.FirstOrDefault(x => x.GiftCardId == g.GiftCardId);
            g2.Amount = g.Amount;
            g2.Status = g.Status;
            g2.ExpirationDate = g.ExpirationDate;
            g2.IsUsed = g.IsUsed;
            db.GiftCards.Update(g2);
            db.SaveChanges();
        }
        //מחיקה מהמאגר ע"י שינוי הסטטוס מאמת לשקר
        [HttpPut("deleteGiftCards")]
        public void DelGiftCards(int id)
        {
            GiftCards g2 = db.GiftCards.FirstOrDefault(x => x.GiftCardId == id);
            g2.Status = false;
            db.GiftCards.Update(g2);
            db.SaveChanges();
        }


    }
}
