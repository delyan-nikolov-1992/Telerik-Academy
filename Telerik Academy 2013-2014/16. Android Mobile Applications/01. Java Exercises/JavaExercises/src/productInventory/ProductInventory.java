package productInventory;

import java.math.BigDecimal;

public class ProductInventory {
	public static void main(String[] args) {
		try {
			Product[] Products = new Product[] {
					new Product(new BigDecimal("14.99"), 1, 5),
					new Product(new BigDecimal("54.99"), 2, 15),
					new Product(new BigDecimal("104.99"), 3, 1),
					new Product(new BigDecimal("100"), 4, 101),
					new Product(new BigDecimal("991"), 5, 4) };

			Inventory CurrentInventory = new Inventory(Products);

			BigDecimal inventoryPrice = CurrentInventory.sumOfPrices();
			int inventoryQuantity = CurrentInventory.sumOfQuantities();

			System.out.println("The price of the inventory is: "
					+ inventoryPrice);
			System.out.println("The quantity of the inventory is: "
					+ inventoryQuantity);
		} catch (IndexOutOfBoundsException exc) {
			System.out.println(exc.getMessage());
		}
	}
}