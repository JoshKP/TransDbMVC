using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TransactionManagement.MVC.Models.ProductModels;
using TransactionManagement.MVC.Services;

namespace TransactionManagement.MVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        //private bool SetStarState(int productId, bool newState)
        //{
        //    // Create the service
        //    // var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new ProductService();

        //    // Get the note
        //    var detail = service.GetProductById(productId);

        //    // Create the NoteEdit model instance with the new star state
        //    var updatedProduct =
        //        new ProductEdit
        //        {
        //            ProductId = detail.ProductId,
        //            Name = detail.Name,
        //            SupplierId = detail.SupplierId,
        //            Category = detail.Category,
        //            Price = detail.Price,
        //            InventoryCount = detail.InventoryCount,
        //            Notes = detail.Notes,
        //            IsStarred = newState
        //        };

        //    // Return a value indicating whether the update succeeded
        //    return service.UpdateProduct(updatedProduct);
        //}

        //[Route("{id}/Star")]
        //[HttpPut]
        //public bool ToggleStarOn(int id) => SetStarState(id, true);

        //[Route("{id}/Star")]
        //[HttpDelete]
        //public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}
