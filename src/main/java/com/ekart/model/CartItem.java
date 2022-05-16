package com.ekart.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
public class CartItem {

  private String productId;

  private int quantity;

  private double price;

  public void add(int quantityToAdd, double priceIncrement)
  {
    if (quantityToAdd <= 0)
      throw new IllegalArgumentException("Quantity to add must be positive");

    if (priceIncrement <= 0)
      throw new IllegalArgumentException("Price increment must be positive");

    quantity += quantityToAdd;
    price += priceIncrement;
  }

  public void remove(int quantityToRemove, double priceDecrement)
  {
    if (quantityToRemove <= 0)
      throw new IllegalArgumentException("Quantity to remove Must be positive");

    if (quantityToRemove > quantity)
      throw new IllegalArgumentException("Quantity to remove must be less than or equal to total Quantity");

    if (priceDecrement <= 0)
      throw new IllegalArgumentException("Price decrement must be positive");

    if (priceDecrement > price)
      throw new IllegalArgumentException("Price decrement can not be more than original price");

    quantity -= quantityToRemove;
    price -= priceDecrement;
  }


}
