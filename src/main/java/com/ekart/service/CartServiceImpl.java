package com.ekart.service;

import com.ekart.model.CartItem;

import java.util.List;

public class CartServiceImpl implements ICartService {

  private List<CartItem> cartItems;

  public CartServiceImpl (List<CartItem> cartItems) {
    this.cartItems = cartItems;
  }

  @Override
  public void addItem(CartItem item) {
    this.cartItems.add(item);
  }

  @Override
  public void clear() {
    this.cartItems.clear();
  }

  @Override
  public List<CartItem> items() {
    return this.cartItems;
  }

  @Override
  public int numberOfItems() {
    return items().size();
  }

  @Override
  public double total() {
    double total = 0.0;
    for(CartItem item: this.cartItems) {
      total += (item.getPrice() * item.getQuantity());
    }
    return total;
  }
}
