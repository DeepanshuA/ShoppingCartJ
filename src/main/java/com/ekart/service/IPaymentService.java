package com.ekart.service;

import com.ekart.model.Card;

public interface IPaymentService
{
  boolean charge(double total, Card card);
}
