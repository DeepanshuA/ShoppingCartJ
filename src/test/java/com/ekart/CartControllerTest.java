package com.ekart;

import com.ekart.model.AddressInfo;
import com.ekart.model.Card;
import com.ekart.service.CartServiceImpl;
import com.ekart.service.ICartService;
import com.ekart.service.IPaymentService;
import com.ekart.service.IShipmentService;
import com.ekart.service.PaymentServiceImpl;
import com.ekart.service.ShipmentServiceImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.mockito.Mock;
import org.mockito.Mockito;

import java.time.LocalDate;

import static org.junit.Assert.assertEquals;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.ArgumentMatchers.anyDouble;
import static org.mockito.ArgumentMatchers.anyList;
import static org.mockito.Mockito.when;

public class CartControllerTest {

  private IPaymentService paymentService;
  private ICartService cartService;
  private IShipmentService shipmentService;
  private CartController cartController;

  @Before
  public void setup() {
    paymentService = Mockito.mock(PaymentServiceImpl.class);
    cartService = Mockito.mock(CartServiceImpl.class);
    shipmentService = Mockito.mock(ShipmentServiceImpl.class);
    cartController = new CartController(cartService, paymentService, shipmentService);
  }

  @Test
  public void testSuccessfulCheckout() {
    when(paymentService.charge(anyDouble(), any(Card.class))).thenReturn(true);
    when(cartService.numberOfItems()).thenReturn(2);
    when(cartService.total()).thenReturn(235.0);
    when(shipmentService.ship(any(AddressInfo.class),anyList())).thenReturn(true);
    Card card = new Card("1111222233334444", "JACKIE JILL", LocalDate.of(2025, 1, 30), 100);
    AddressInfo addressInfo = new AddressInfo();
    String actual = cartController.checkOut(card, addressInfo);

    assertEquals("Charged", actual);
  }


}
