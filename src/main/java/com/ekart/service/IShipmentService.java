package com.ekart.service;

import com.ekart.model.AddressInfo;
import com.ekart.model.CartItem;

import java.util.List;

public interface IShipmentService
{
  boolean ship(AddressInfo info, List<CartItem> items);
}
