package com.ekart.integration;

import com.ekart.CartController;
import com.ekart.model.AddressInfo;
import com.ekart.model.Card;
import com.ekart.model.CartItem;
import com.ekart.service.CartServiceImpl;
import com.ekart.service.ICartService;
import com.ekart.service.IPaymentService;
import com.ekart.service.IShipmentService;
import com.ekart.service.PaymentServiceImpl;
import com.ekart.service.ShipmentServiceImpl;
import org.junit.Before;
import org.junit.Test;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import static org.junit.Assert.assertEquals;

public class CartTest {

  private IPaymentService paymentService;
  private ICartService cartService;
  private IShipmentService shipmentService;
  private CartController cartController;
  private List<CartItem> itemsList = new ArrayList<>();

  @Before
  public void setup() {
    paymentService = new PaymentServiceImpl();
    itemsList.add(new CartItem("P001", 1, 1.0));
    itemsList.add(new CartItem("P002", 2, 10));
    cartService = new CartServiceImpl(itemsList);
    shipmentService = new ShipmentServiceImpl();
    cartController = new CartController(cartService, paymentService, shipmentService);
  }

  @Test
  public void testSuccessfulCheckout() {
    Card card = new Card("1111222233334444", "JACKIE JILL", LocalDate.of(2025, 1, 30), 100);
    AddressInfo addressInfo = new AddressInfo();
    String actual = cartController.checkOut(card, addressInfo);

    assertEquals("Charged", actual);
  }

  @Test
  public void testAddCreditAndRepay() {
    itemsList.add(new CartItem("P001", 1, 200.0));
    Card card = new Card("1111222233334444", "JACKIE JILL", LocalDate.of(2025, 1, 30), 100);
    AddressInfo addressInfo = new AddressInfo();
    String actualFirstTime = cartController.checkOut(card, addressInfo);

    assertEquals("Not Charged", actualFirstTime);

    card.addCredit(500.0);
    String actualSecondTime = cartController.checkOut(card, addressInfo);
    assertEquals("Charged", actualSecondTime);
  }

}
