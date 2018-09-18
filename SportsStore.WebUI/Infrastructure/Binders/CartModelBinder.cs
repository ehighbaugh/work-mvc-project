using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // get the cart from session

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null )
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the cart if one does not exist
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null )
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            
            return cart;
        }
    }
}