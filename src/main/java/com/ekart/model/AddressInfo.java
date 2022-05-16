package com.ekart.model;

import lombok.Data;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class AddressInfo {

  public String street;
  public int apartment;
  public String city;
  public String postalCode;
  public String phoneNumber;
}
