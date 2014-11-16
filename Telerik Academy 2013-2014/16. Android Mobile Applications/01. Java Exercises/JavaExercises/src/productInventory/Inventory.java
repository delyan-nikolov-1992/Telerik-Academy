package productInventory;

import java.math.BigDecimal;

public class Inventory {
	private Product[] products;

	public Inventory(Product[] products) {
		this.products = products;
	}

	public Product[] getProducts() {
		return this.products;
	}

	public void setProducts(Product[] products) {
		this.products = products;
	}

	public BigDecimal sumOfPrices() {
		BigDecimal sum = BigDecimal.ZERO;

		for (Product product : products) {
			sum = sum.add(product.getPrice());
		}

		return sum;
	}

	public int sumOfQuantities() {
		int sum = 0;

		for (Product product : products) {
			sum += product.getQuantity();
		}

		return sum;
	}
}