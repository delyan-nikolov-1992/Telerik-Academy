package productInventory;

import java.math.BigDecimal;

public class Product {
	private BigDecimal price;
	private int id;
	private int quantity;

	public Product(BigDecimal price, int id, int quantity) {
		setPrice(price);
		setId(id);
		setQuantity(quantity);
	}

	public BigDecimal getPrice() {
		return this.price;
	}

	public void setPrice(BigDecimal price) {
		if (price.compareTo(BigDecimal.ZERO) <= 0) {
			throw new IndexOutOfBoundsException(
					"The price of the product should be positive!");
		}

		this.price = price;
	}

	public int getId() {
		return this.id;
	}

	public void setId(int id) {
		if (id <= 0) {
			throw new IndexOutOfBoundsException(
					"The id of the product should be positive!");
		}

		this.id = id;
	}

	public int getQuantity() {
		return this.quantity;
	}

	public void setQuantity(int quantity) {
		if (quantity < 0) {
			throw new IndexOutOfBoundsException(
					"The quantity of the product should not be negative!");
		}

		this.quantity = quantity;
	}
}