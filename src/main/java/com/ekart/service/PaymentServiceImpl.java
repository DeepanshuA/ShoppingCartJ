package com.ekart.service;

import com.ekart.model.Card;

import java.time.LocalDate;
import java.time.chrono.ChronoLocalDate;
import java.util.Date;

public class PaymentServiceImpl implements  IPaymentService {

  @Override
  public boolean charge(double total, Card card) {
    if(card == null) {
      throw new IllegalArgumentException("Card is not provided");
    }
    if(card.getValidTo().isBefore(LocalDate.now())) {
      return false;
    }
    return card.charge(total);
  }
}
