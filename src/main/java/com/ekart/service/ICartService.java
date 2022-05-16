package com.ekart.service;

import com.ekart.model.CartItem;

import java.util.List;

public interface ICartService
{
  void addItem(CartItem item);
  void clear();
  List<CartItem> items();
  int numberOfItems();
  double total();
}
