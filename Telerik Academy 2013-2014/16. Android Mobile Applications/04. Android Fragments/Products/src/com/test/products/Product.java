package com.test.products;

import java.math.BigDecimal;

public class Product {
	private String name;
	private int id;
	private Category category;
	private int quantity;
	private BigDecimal price;

	public Product(String name, int id, Category category, int quantity,
			BigDecimal price) {
		setName(name);
		setId(id);
		setCategory(category);
		setQuantity(quantity);
		setPrice(price);
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		if (name == null || name.isEmpty()) {
			throw new NullPointerException(
					"The name of the product should not be null or empty!");
		}

		this.name = name;
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

	public Category getCategory() {
		return this.category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

	public int getQuantity() {
		return this.quantity;
	}

	public void setQuantity(int quantity) {
		if (quantity <= 0) {
			throw new IndexOutOfBoundsException(
					"The quantity of the product should be positive!");
		}

		this.quantity = quantity;
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
}