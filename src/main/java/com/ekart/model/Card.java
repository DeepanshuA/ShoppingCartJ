package com.ekart.model;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDate;
import java.util.Date;

@Getter
@Setter
@AllArgsConstructor
public class Card {

  private String cardNumber;
  private String name;
  private LocalDate validTo;

  private double balance;

  public boolean charge(double total)
  {
    if (total < 0)
      throw new IllegalArgumentException("Total charge Must be non-negative");

    if (total > balance)
      return false;

    balance -= total;
    return true;
  }

  public void addCredit(double credit)
  {
    if (credit < 0)
      throw new IllegalArgumentException("Credit must be non-negative");

      balance += credit;
  }

}
