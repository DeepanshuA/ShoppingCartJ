package com.ekart;

import com.ekart.model.AddressInfo;
import com.ekart.model.Card;
import com.ekart.service.ICartService;
import com.ekart.service.IPaymentService;
import com.ekart.service.IShipmentService;

public class CartController {

  private ICartService cartService;
  private IPaymentService paymentService;
  private IShipmentService shipmentService;

  public CartController(ICartService cartService, IPaymentService paymentService,
                        IShipmentService shipmentService) {
    this.cartService = cartService;
    this.paymentService = paymentService;
    this.shipmentService = shipmentService;
  }

  public String checkOut(Card card, AddressInfo addressInfo) {
    if(cartService.numberOfItems() == 0) {
      return "Cart Is Empty";
    }
    boolean result = paymentService.charge(cartService.total(), card);
    if(result) {
      cartService.clear();
      shipmentService.ship(addressInfo, cartService.items());
      return "Charged";
    } else {
      return "Not Charged";
    }
  }
}
