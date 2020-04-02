using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService.Extensions;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IActionResult Post([FromBody]PaymentDetails paymentDetails)
        {
            try
            {
                CreatePaymentRequest request = new CreatePaymentRequest();
                request.Locale = Locale.TR.ToString();
                request.ConversationId = "123456789";
                request.Price = "1";
                request.PaidPrice = "1.2";
                request.Currency = Currency.TRY.ToString();
                request.Installment = 1;
                request.BasketId = paymentDetails.Basket.Id.ToString();
                request.PaymentChannel = PaymentChannel.WEB.ToString();
                request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

                PaymentCard paymentCard = new PaymentCard();
                paymentCard.CardHolderName = paymentDetails.CardHolderName;
                paymentCard.CardNumber = paymentDetails.CardNumber;
                paymentCard.ExpireMonth = paymentDetails.ExpireMonth;
                paymentCard.ExpireYear = paymentDetails.ExpireYear;
                paymentCard.Cvc = paymentDetails.Cvc;
                paymentCard.RegisterCard = 0;
                request.PaymentCard = paymentCard;

                Buyer buyer = new Buyer();
                buyer.Id = "BY789";
                buyer.Name = "John";
                buyer.Surname = "Doe";
                buyer.GsmNumber = "+905350000000";
                buyer.Email = "email@email.com";
                buyer.IdentityNumber = "74300864791";
                buyer.LastLoginDate = "2015-10-05 12:43:35";
                buyer.RegistrationDate = "2013-04-21 15:12:09";
                buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                buyer.Ip = "85.34.78.112";
                buyer.City = "Istanbul";
                buyer.Country = "Turkey";
                buyer.ZipCode = "34732";
                request.Buyer = buyer;

                Address shippingAddress = new Address();
                shippingAddress.ContactName = "Jane Doe";
                shippingAddress.City = "Istanbul";
                shippingAddress.Country = "Turkey";
                shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                shippingAddress.ZipCode = "34742";
                request.ShippingAddress = shippingAddress;

                Address billingAddress = new Address();
                billingAddress.ContactName = "Jane Doe";
                billingAddress.City = "Istanbul";
                billingAddress.Country = "Turkey";
                billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
                billingAddress.ZipCode = "34742";
                request.BillingAddress = billingAddress;

                List<BasketItem> basketItems = new List<BasketItem>();
                decimal totalPrice = 0;

                paymentDetails.Basket.OrderProducts.ForEach(orderProduct =>
                {
                    BasketItem basketItem = new BasketItem();
                    basketItem.Id = orderProduct.Product.Id.ToString();
                    basketItem.Name = orderProduct.Product.Name;
                    basketItem.Category1 = "None";
                    basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                    basketItem.Price = (orderProduct.Product.UnitPrice * orderProduct.Quantity).ToString();
                    basketItems.Add(basketItem);
                    totalPrice += (orderProduct.Product.UnitPrice * orderProduct.Quantity);
                });

                request.BasketItems = basketItems;

                request.PaidPrice = totalPrice.ToString();
                request.Price = totalPrice.ToString();

                Payment payment = Payment.Create(request, new Iyzipay.Options()
                {
                    ApiKey = "sandbox-199V3uqSW4tFDOSxgQPEdolv6ho3sPWy",
                    BaseUrl = "https://sandbox-api.iyzipay.com",
                    SecretKey = "sandbox-Bf26JOJMykdIECpeen0fYGDte5IYyRA9"
                });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.ToString() });
            }
        }
    }
}